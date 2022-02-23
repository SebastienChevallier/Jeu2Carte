using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class MouseManage : MonoBehaviour
{
    public Camera camera;

    private GameObject GO_cible = null;
    private Vector3 posCardDrag;

    void Update()
    {      
       
    }

    void HoverCards()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, LayerMask.NameToLayer("HandCards")))
        {
            if (GO_cible != null && GO_cible != hit.transform.gameObject)
            {
                GO_cible.transform.localScale = new Vector3(1, 1, 1);
                GO_cible = hit.transform.parent.gameObject;

            }
            else
            {
                GO_cible = hit.transform.parent.gameObject;
            }

            hit.transform.parent.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            
        }
    }

}
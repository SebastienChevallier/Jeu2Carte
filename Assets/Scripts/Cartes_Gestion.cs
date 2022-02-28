using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartes_Gestion : MonoBehaviour
{
    public List<SO_Cartes> cartes;
    public List<GameObject> GO_Cartes;
    public GameObject prefab_Cartes;

    private GameObject container;
    
   
    
    private void Start()
    {
        container = GameObject.Find("Container");

        Load_Hand();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Load_Hand();
        }
    }

    void Load_Hand()
    {
        float distance = Vector3.Distance(GameObject.Find("Min").transform.position, GameObject.Find("Max").transform.position);
        float distIntercarte = distance / (cartes.Count +1);
        distance = distIntercarte;

        foreach (GameObject card in GO_Cartes)
        {
            Destroy(card);
        }

        foreach (SO_Cartes card in cartes)
        { 
            var prefCartes = Instantiate(prefab_Cartes, GameObject.Find("Min").transform.position + new Vector3(distance, 0, 0), new Quaternion(0,0,0,0), container.transform);
            prefCartes.transform.localRotation = Quaternion.Euler(0, 2, 0);
            distance += distIntercarte;
            prefCartes.GetComponent<_CartesManager>().carteRef = card;            
            GO_Cartes.Add(prefCartes);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartes_Gestion : MonoBehaviour
{
    public List<SO_Cartes> cartes;
    public List<GameObject> GO_Cartes;
    public GameObject prefab_Cartes;

    private GameObject container;
    private float padding = 0f;
    
    
    private void Start()
    {
        container = GameObject.Find("Container");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadHand();
        }
    }

    void LoadHand()
    {
        foreach (GameObject card in GO_Cartes)
        {
            Destroy(card);
        }

        foreach (SO_Cartes card in cartes)
        {            
            var prefCartes = Instantiate(prefab_Cartes, container.transform.position + new Vector3(padding, 0, 0), new Quaternion(0,0,0,0), container.transform);
            prefCartes.transform.localRotation = Quaternion.Euler(90, 0, 0);
            prefCartes.GetComponent<_CartesManager>().carteRef = card;
            padding += 5f / cartes.Count;
            GO_Cartes.Add(prefCartes);
        }
        padding = 0;
    }
}

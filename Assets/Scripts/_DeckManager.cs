using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _DeckManager : MonoBehaviour
{
    public GameObject prefab_Cartes;

    public List<SO_Cartes> cartes;
    public List<GameObject> deck;

    private Transform hand, minHand, maxHand;
    
   
    
    void Start()
    {
        hand = GameObject.Find("Main").transform;
        minHand = GameObject.Find("Min").transform;
        maxHand = GameObject.Find("Max").transform;

        Load_Hand();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Load_Hand();
        }
    }

    void Load_Hand()
    {
        float distance = Vector3.Distance(minHand.position, maxHand.position);
        float distIntercarte = distance / (cartes.Count +1);
        distance = distIntercarte;

        foreach (GameObject card in deck)
        {
            Destroy(card);
        }

        foreach (SO_Cartes card in cartes)
        { 
            var prefCartes = Instantiate(prefab_Cartes, GameObject.Find("Min").transform.position + new Vector3(distance, 0, 0), new Quaternion(0,0,0,0), hand);
            prefCartes.transform.localRotation = Quaternion.Euler(0, 2, 0);
            distance += distIntercarte;
            prefCartes.GetComponent<_CartesManager>().carteRef = card;            
            deck.Add(prefCartes);
        }
    }
}

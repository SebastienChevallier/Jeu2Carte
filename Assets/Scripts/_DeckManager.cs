using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _DeckManager : MonoBehaviour
{
    public GameObject prefab_Cartes;

    public List<SO_Cartes> cartes;

    public List<_CartesManager> hand = new List<_CartesManager>();
    public List<_CartesManager> deck = new List<_CartesManager>();

    private Transform handPos, minHand, maxHand, deckPos;

    [Header("Battle")]
    [Range(3, 7)]
    public int startHandSize = 5;
    private int handSize;
    
   
    
    void Start()
    {
        handPos = GameObject.Find("Main").transform;
        minHand = GameObject.Find("Min").transform;
        maxHand = GameObject.Find("Max").transform;
        deckPos = GameObject.Find("Deck").transform;

        Load_Hand(startHandSize);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Load_Hand(hand.Count);
        }
    }

    private void Get_Deck()
    {
        float distance = Vector3.Distance(minHand.position, maxHand.position);
        float distIntercarte = distance / (handSize + 1);
        distance = distIntercarte;

        foreach (SO_Cartes card in cartes)
        {
            _CartesManager newCard = 
            deck.Add(card.)
        }
    }

    void Load_Hand(int handSize)
    {
        foreach (_CartesManager card in hand)
            Destroy(card.gameObject);

        foreach (_CartesManager card in )
        {
            var prefCartes = Instantiate(prefab_Cartes, minHand.position + new Vector3(distance, 0, 0), new Quaternion(0, 0, 0, 0), handPos);
            prefCartes.transform.localRotation = Quaternion.Euler(0, 2, 0);
            prefCartes.GetComponent<_CartesManager>().carteRef = card;
            distance += distIntercarte;
            hand.Add(prefab_Cartes.GetComponent<_CartesManager>());
        }
    }
}

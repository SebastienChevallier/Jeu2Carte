using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CartesManager : MonoBehaviour
{
	[Header("Proprieté de la carte : ")]
	public string _name;
	public int price;
	public string type;
	public int rarete;

	[Header("Scripts Refs")]
	public SO_Cartes carteRef;
	public EnumEffets scriptEffet;
	public GameObject cible;

	[Header("Value Effet 1 : ")]
	public EnumEffets.enumEffets effet1;
	public int valeur1;
	public int duree1;

	[Header("Value Effet 2 : ")]
	public EnumEffets.enumEffets effet2;	
	public int valeur2;	
	public int duree2;	

	

	// Start is called before the first frame update
	void Start()
    {
		scriptEffet = GameObject.Find("GAMEMANAGER").GetComponent<EnumEffets>();
		CreateCard(carteRef);

		scriptEffet.DoEffect(effet1, valeur1, duree1, rarete, cible);
		scriptEffet.DoEffect(effet2, valeur2, duree2, rarete, cible);
    }

	public void CreateCard(SO_Cartes carte)
    {
		_name = carte.name;
		price = carte.price;
		type = carte.type;
		effet1 = carte.effet1;
		effet2= carte.effet2;
		
		valeur1 = carte.valeur1;
		valeur2 = carte.valeur2;
		duree1 = carte.duree1;
		duree2 = carte.duree2;
		rarete = carte.rarete;
    }
}

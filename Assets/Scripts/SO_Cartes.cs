using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cartes", menuName = "ScriptableObjects/Cartes", order = 1)]
public class SO_Cartes : ScriptableObject
{
	[Header("Proprieté de la carte : ")]
	public string _name;
	public int price;
	public string type;
	public int rarete;
	public string classe;
	public Sprite image;
	public string description;

	[Header("Valeur Effet 1")]
	public EnumEffets.enumEffets effet1;
	public int valeur1;
	public int duree1;

	[Header("Valeur Effet 2")]
	public EnumEffets.enumEffets effet2;	
	public int valeur2;	
	public int duree2;
	


}

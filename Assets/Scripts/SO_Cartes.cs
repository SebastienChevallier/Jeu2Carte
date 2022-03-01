using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cartes", menuName = "ScriptableObjects/Cartes", order = 1)]
public class SO_Cartes : ScriptableObject
{
	[Header("Propriétés")]
	public string _name;
	public Sprite image;
	[Range(0, 100)]
	public int cost;
	public EnumPerso.types type;
	public EnumPerso.categories category;
	public EnumPerso.classes classe;
	public EnumPerso.elements element;
	public EnumPerso.rarities rarete;

	[Header("Effet 1")]
	public EnumEffets.enumEffets effet1;
	public int valeur1;
	public int duree1;

	[Header("Effet 2")]
	public EnumEffets.enumEffets effet2;	
	public int valeur2;	
	public int duree2;

	[Header("Effet 3")]
	public EnumEffets.enumEffets effet3;
	public int valeur3;
	public int duree3;

	[Header("Effet bonus de classe")]
	public EnumEffets.enumEffets effet4;
	public int valeur4;
	public int duree4;
}

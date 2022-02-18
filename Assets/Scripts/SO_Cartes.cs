using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cartes", menuName = "ScriptableObjects/Cartes", order = 1)]
public class SO_Cartes : ScriptableObject
{
	public string _name;
	public int price;
	public string type;
	public EnumEffets.enumEffets effet1;
	public EnumEffets.enumEffets effet2;
	
	public int valeur1;
	public int valeur2;
	public int duree1;
	public int duree2;
	public int rarete;
	public string classe;
}

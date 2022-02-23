using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class _CartesManager : MonoBehaviour
{
	[HideInInspector]
	public string _name;
	[HideInInspector]
	public int price;
	[HideInInspector]
	public string type;
	[HideInInspector]
	public int rarete;
	[HideInInspector]
	public string classe;

	[Header("Textes Infos cartes : ")]
	public TextMeshPro t_Nom;
	public TextMeshPro t_Type;
	public TextMeshPro t_Rarete;
	public TextMeshPro t_Effet1;
	public TextMeshPro t_Effet2;
	public TextMeshPro t_Classe;

	public LayerMask layer;

	[Header("Scripts Refs")]
	public SO_Cartes carteRef;
	private EnumEffets scriptEffet;
	public GameObject cible;

	[HideInInspector]
	public EnumEffets.enumEffets effet1;
	[HideInInspector]
	public int valeur1;
	[HideInInspector]
	public int duree1;


	[HideInInspector]
	public EnumEffets.enumEffets effet2;
	[HideInInspector]
	public int valeur2;
	[HideInInspector]
	public int duree2;
	[HideInInspector]

	// Start is called before the first frame update
	void Start()
    {

		scriptEffet = GameObject.Find("GAMEMANAGER").GetComponent<EnumEffets>();

		CreateCard(carteRef);

		scriptEffet.DoEffect(effet1, valeur1, duree1, rarete, cible);
		scriptEffet.DoEffect(effet2, valeur2, duree2, rarete, cible);
		savePos = transform.position;
	}

	public void CreateCard(SO_Cartes carte)
    {

		_name = carte._name;

		price = carte.price;
		type = carte.type;
		effet1 = carte.effet1;
		effet2= carte.effet2;
		classe = carte.classe;

		
		valeur1 = carte.valeur1;
		valeur2 = carte.valeur2;
		duree1 = carte.duree1;
		duree2 = carte.duree2;
		rarete = carte.rarete;

		t_Nom.text = _name;
		t_Type.text = type;
		t_Rarete.text = rarete.ToString();
		t_Effet1.text = effet1.ToString() + " : inflige " + valeur1 + " pts de degats sur " + duree1 + " tours.";
		t_Effet2.text = effet2.ToString() + " : inflige " + valeur2 + " pts de degats sur " + duree2 + " tours.";
		t_Classe.text = classe;
    }

	private Vector3 savePos;
    private void OnMouseDown()
    {
		
	}

    private void OnMouseOver()
    {
		
	}

    private void OnMouseExit()
    {
		transform.localScale = new Vector3(1, 1, 1);
	}

    private void OnMouseEnter()
    {
		transform.localScale = new Vector3(1.5f,1.5f,1.5f);
    }

    private void OnMouseDrag()
	{
		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);

		Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

		
		transform.position = objPosition;		

	}

	private void OnMouseUp()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		

		if (Physics.Raycast(ray, out hit, 100, layer))
		{
						
        }
        else
        {
			transform.position = savePos;
		}
        
			
		
		
	}

}

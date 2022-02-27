using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class _CartesManager : MonoBehaviour
{
	[Header("Infos")]
	public string _name;
	public Sprite image;
	public int cost;
	public EnumPerso.types type;
	public EnumPerso.classes classe;
	public EnumPerso.elements element;
	public EnumPerso.rarities rarete;

	public EnumEffets.enumEffets effet1;
	public int valeur1;
	public int duree1;

	public EnumEffets.enumEffets effet2;
	public int valeur2;
	public int duree2;

	public EnumEffets.enumEffets effet3;
	public int valeur3;
	public int duree3;

	public EnumEffets.enumEffets effet4;
	public int valeur4;
	public int duree4;

	[Header("UI")]
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

	public Camera carteCam;
	public _SystemManager scriptSystem;

	//UI
	private Vector3 savePos;



	void Start()
    {
		scriptSystem = GameObject.Find("Canvas").GetComponent<_SystemManager>();

		scriptEffet = GameObject.Find("GAMEMANAGER").GetComponent<EnumEffets>();
		carteCam = GameObject.Find("CameraCarte").GetComponent<Camera>();

		CreateCard(carteRef);

		savePos = transform.position;
	}

	public void CreateCard(SO_Cartes carte)
    {
		_name = carte._name;
		image = carte.image;
		cost = carte.cost;
		type = carte.type;
		classe = carte.classe;
		element = carte.element;
		rarete = carte.rarete;

		effet1 = carte.effet1;
		valeur1 = carte.valeur1;
		duree1 = carte.duree1;

		effet2 = carte.effet2;
		valeur2 = carte.valeur2;
		duree2 = carte.duree2;

		effet3 = carte.effet3;
		valeur3 = carte.valeur3;
		duree3 = carte.duree3;

		effet4 = carte.effet4;
		valeur4 = carte.valeur4;
		duree4 = carte.duree4;

		t_Nom.text = _name;
		t_Type.text = type.ToString();
		t_Classe.text = classe.ToString();
		t_Rarete.text = rarete.ToString();
		t_Effet1.text = effet1.ToString() + " : inflige " + valeur1 + " pts de degats sur " + duree1 + " tours.";
		t_Effet2.text = effet2.ToString() + " : inflige " + valeur2 + " pts de degats sur " + duree2 + " tours.";
    }


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
		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -carteCam.transform.position.z + savePos.z);

		Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
		
		transform.position = objPosition;		
	}

	private void OnMouseUp()
	{
		RaycastHit hit;
		Ray ray = carteCam.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit, 100, layer))
		{
			scriptSystem.Player_Attack(valeur1, cost, true, EnumPerso.elements.Air, scriptSystem.scriptPersoAttacker, scriptSystem.scriptPersoTarget);
		}
        else
        {
			transform.position = savePos;
		}	
	}
}

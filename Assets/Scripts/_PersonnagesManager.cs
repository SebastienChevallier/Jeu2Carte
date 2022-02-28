using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _PersonnagesManager : MonoBehaviour
{
    [Header("R�f�rence")]
    public SO_Personnages persoRef;

    [Header("Infos")]
	public string _name;
    public EnumPerso.classes classe;
    public EnumPerso.races race;

    [Header("Stats")]
    public int basePV;
    public int actualPV;
    public int baseMana;
    public int actualMana;

    public float attackBar;

    [HideInInspector]
    public float fillAmountPV, fillAmountMana;

    public int attPhys;
    public int attMag;
    public int defPhys;
    public int defMag;
    public int vitesse;
    public float tauxCC;

    public EnumPerso.elements weakness;
    public EnumPerso.elements resistance;

    public bool zoneOffensive;

    [HideInInspector]
    public bool hasPlayed;

    [Header("Capacit�s")]
	public EnumCapacites.enumCapacite capacite;
	public int valeur1;
    public int valeur2;
    public int duree;

    [HideInInspector]
    public EnumCapacites scriptCapacites;

    public Camera myCamera;
    private Vector3 mOffset;
    private float mZCoord;

    public _SystemManager scriptSystem;



    void Start()
    {
		scriptCapacites = GameObject.Find("GAMEMANAGER").GetComponent<EnumCapacites>();
		CreateCharacter(persoRef);

        mZCoord = myCamera.WorldToScreenPoint(transform.position).z;
    }

	public void CreateCharacter(SO_Personnages personnage)
    {
		_name = personnage._name;
        classe = personnage.classe;
        race = personnage.race;

        basePV = personnage.basePV;
        actualPV = personnage.actualPV;
        fillAmountPV = personnage.fillAmountPV;

        baseMana = personnage.baseMana;
        actualMana = personnage.actualMana;
        fillAmountMana = personnage.fillAmountMana;

        attackBar = personnage.attackBar;

        attPhys = personnage.attPhys;
        attMag = personnage.attMag;
        defPhys = personnage.defPhys;
        defMag = personnage.defMag;
        vitesse = personnage.vitesse;
        tauxCC = personnage.tauxCC;

        weakness = personnage.weakness;
        resistance = personnage.resistance;

        zoneOffensive = personnage.zoneOffensive;

        hasPlayed = personnage.hasPlayed;

        capacite = personnage.capacite;	
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Offensive")
            zoneOffensive = true;
        else if (col.tag == "Defensive")
            zoneOffensive = false;
    }

    void OnMouseDown()
    {
        Debug.Log(this);
        if (tag == "Enemy")
            scriptSystem.scriptPersoTarget = transform.gameObject.GetComponent<_PersonnagesManager>(); ;
    }

    void OnMouseDrag()
    {
        if (tag == "Ally")
        {
            Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mZCoord);
            Vector3 NewWorldPosition = myCamera.ScreenToWorldPoint(ScreenPosition);
            transform.position = NewWorldPosition;
        }
    }
}

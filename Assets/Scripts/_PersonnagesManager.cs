using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PersonnagesManager : MonoBehaviour
{
    [Header("Reference")]
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

    public float fillAmountPV, fillAmountMana;

    public int attPhys;
    public int attMag;
    public int defPhys;
    public int defMag;
    public int vitesse;
    public float tauxCC;

    public bool zoneOffensive;

    public EnumPerso.elements weakness;
    public EnumPerso.elements resistance;

    public bool hasPlayed;

    [Header("Capacites")]
	public EnumCapacites.enumCapacite capacite;
	public int valeur1;
    public int valeur2;
    public int duree;

    [HideInInspector]
    public EnumCapacites scriptCapacites;

    //Script
    private _SystemManager scriptSystem;

    private Camera _camera;



    void Start()
    {
		scriptCapacites = GameObject.Find("GAMEMANAGER").GetComponent<EnumCapacites>();
        scriptSystem = GameObject.Find("Canvas").GetComponent<_SystemManager>();
        _camera = GameObject.Find("CameraCarte").GetComponent<Camera>();

        CreateCharacter(persoRef);
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

    private void OnMouseDown()
    {
        if (tag == "Enemy")
        {
            scriptSystem.scriptPersoTarget = transform.gameObject.GetComponent<_PersonnagesManager>();
            scriptSystem.Damage_Calculation(scriptSystem.card.valeur1, scriptSystem.card.category, scriptSystem.card.element, scriptSystem.scriptPersoAttacker, scriptSystem.scriptPersoTarget);
            scriptSystem.Load_Previsu();
        }
    }
}

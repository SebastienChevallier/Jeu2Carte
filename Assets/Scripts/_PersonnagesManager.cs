using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PersonnagesManager : MonoBehaviour
{
   
   [Header("Infos")]
	public string _name;
    public string classe;
    public string race;

    [Header("Stats")]
    public int basePV;
    public int actualPV;
    public int baseMana;
    public int actualMana;

    [HideInInspector]
    public float fillAmountPV, fillAmountMana;

    public int attPhys;
    public int attMag;
    public int defPhys;
    public int defMag;
    public int vitesse;
    public float tauxCC;

    [HideInInspector]
    public float attackBar;

    [Header("Scripts Refs")]
	public SO_Personnages persoRef;
	public EnumCapacites scriptCapacites;

	[Header("Value Skill : ")]
	public EnumCapacites.enumCapacite capacite;
	public int valeur1;
    public int valeur2;
    public int duree;


	void Start()
    {
		scriptCapacites = GameObject.Find("GAMEMANAGER").GetComponent<EnumCapacites>();
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

        attPhys = personnage.attPhys;
        attMag = personnage.attMag;
        defPhys = personnage.defPhys;
        defMag = personnage.defMag;
        vitesse = personnage.vitesse;
        tauxCC = personnage.tauxCC;

        attackBar = personnage.attackBar;

        capacite = personnage.capacite;	
    }
}

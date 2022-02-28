using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Personnage", menuName = "ScriptableObjects/Personnage", order = 1)]
public class SO_Personnages : ScriptableObject
{
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
    public float fillAmountPV = 1, fillAmountMana = 1;

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

    [Header("Capacités")]
    public EnumCapacites.enumCapacite capacite;
}

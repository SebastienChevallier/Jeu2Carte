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
    [Range(0, 1000)]
    public int basePV;
    [Range(0, 1000)]
    public int actualPV;
    [Range(0, 200)]
    public int baseMana;
    [Range(0, 200)]
    public int actualMana;

    [HideInInspector]
    public float attackBar;

    [HideInInspector]
    public float fillAmountPV = 1, fillAmountMana = 1;

    [Range(30, 50)]
    public int attPhys;
    [Range(30, 50)]
    public int attMag;
    [Range(30, 50)]
    public int defPhys;
    [Range(30, 50)]
    public int defMag;
    [Range(30, 50)]
    public int vitesse;
    [Range(0f, 1f)]
    public float tauxCC;

    public EnumPerso.elements weakness;
    public EnumPerso.elements resistance;

    public bool zoneOffensive;

    [HideInInspector]
    public bool hasPlayed;

    [Header("Capacités")]
    public EnumCapacites.enumCapacite capacite;
}

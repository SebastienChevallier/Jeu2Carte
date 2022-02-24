using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Personnage", menuName = "ScriptableObjects/Personnage", order = 1)]
public class SO_Personnages : ScriptableObject
{
    public string _name;

    public string classe;
    public string race;

    public int basePV;
    public int actualPV;
    public float fillAmountPV;
    public int baseMana;
    public int actualMana;
    public float fillAmountMana;
    public float attackBar;
    public bool hasPlayed;
    public int attPhys;
    public int attMag;
    public int defPhys;
    public int defMag;
    public int vitesse;
    public float tauxCC;

    public EnumCapacites.enumCapacite capacite;
}

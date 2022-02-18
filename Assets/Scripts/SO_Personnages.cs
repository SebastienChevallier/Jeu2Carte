using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Personnage", menuName = "ScriptableObjects/Personnage", order = 1)]
public class SO_Personnages : ScriptableObject
{
    public string name;

    public string classe;

    public int PV;
    public int attPhys;
    public int attMag;
    public int defPhys;
    public int defMag;

    public EnumCapacites.enumCapacite capacite;
}

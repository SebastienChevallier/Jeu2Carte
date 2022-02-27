using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumPerso : MonoBehaviour
{
    public enum classes
    {
        Voleur,
        Barbare,
        Magicien,
        Ranger,
        Necromancien,
        Paladin,
        Aucune
    }

    public enum races
    {
        Humain,
        Nain,
        Gnome,
        ElfeDesBbois,
        ElfeNoir,
        Orc,
        Troll
    }

    public enum elements
    {
        Feu,
        Eau,
        Terre,
        Air,
        Aucun
    }

    public enum types
    {
        Sort,
        Objet,
        Evénement,
        Invocation
    }

    public enum rarities
    {
        Commun,
        Rare,
        Légendaire,
    }
}

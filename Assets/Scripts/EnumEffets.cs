using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumEffets : MonoBehaviour
{
   public enum enumEffets
    {
        Attaque,
        Defense,
        Brule,
        Poison,
        Aucun
    }

    public void DoEffect(enumEffets effet, int Val, int duree, EnumPerso.rarities rarete, _PersonnagesManager target)
    {
        switch (effet)
        {
            case enumEffets.Attaque:
                break;
            case enumEffets.Defense:
                break;
            case enumEffets.Brule:
                break;
            case enumEffets.Poison:
                break;
            case enumEffets.Aucun:
                break;
            default:
                break;
        }
    }

   public void Attaque(int Val1, int Val2, int duree1, int duree2, int rarete)
    {
        Debug.Log("Attaque : " + Val1 + " " + Val2 + " " + duree1 + " " + duree2 + " " + rarete);
    }

    public void Defense(int Val1, int Val2, int duree1, int duree2, int rarete)
    {
        Debug.Log("Defense " + Val1 + " " + Val2 + " " + duree1 + " " + duree2 + " " + rarete);
    }

    public void Brule(int Val1, int Val2, int duree1, int duree2, int rarete)
    {
        Debug.Log("Brule " + Val1 + " " + Val2 + " " + duree1 + " " + duree2 + " " + rarete);
    }

    public void Poison(int Val1, int Val2, int duree1, int duree2, int rarete)
    {
        Debug.Log("Poison " + Val1 + " " + Val2 + " " + duree1 + " " + duree2 + " " + rarete);
    }

    public void Aucun(int Val1, int Val2, int duree1, int duree2, int rarete)
    {
        Debug.Log("Aucun " + Val1 + " " + Val2 + " " + duree1 + " " + duree2 + " " + rarete);
    }
}

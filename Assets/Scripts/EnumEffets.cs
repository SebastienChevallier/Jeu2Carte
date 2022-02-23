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
        Poison
    }

    public void DoEffect(enumEffets effet, int Val, int duree, int rarete, GameObject cible)
    {
        switch (effet)
        {
            case enumEffets.Attaque:
                //Debug.Log("Attaque : " + Val + " " + duree + " " + rarete);
                break;
            case enumEffets.Defense:
                //Debug.Log("Defense : " + Val + " " + duree + " " + rarete);
                break;
            case enumEffets.Brule:
                //Debug.Log("Brule : " + Val + " " + duree + " " + rarete);
                break;
            case enumEffets.Poison:
                //Debug.Log("Poison : " + Val + " " + duree + " " + rarete);
                break;
            default:
                //Debug.Log("Incorrect intelligence level.");
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
}

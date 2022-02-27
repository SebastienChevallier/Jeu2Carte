using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumCapacites : MonoBehaviour
{
    public enum enumCapacite
    {
        Capacite1,
        Capacite2,
        Capacite3
    }
   
    public void DoSkill (enumCapacite capacite, int Val1, int Val2, int duree)
    {
        switch (capacite)
        {
            case enumCapacite.Capacite1:
                Capacite1(Val1, Val2, duree);
                break;
            case enumCapacite.Capacite2:
                Capacite2(Val1, Val2, duree);
                break;
            case enumCapacite.Capacite3:
                Capacite3(Val1, Val2, duree);
                break;
        }
    }

    public void Capacite1(int Val1, int Val2, int duree)
    {
        Debug.Log("Capacite1 : " + Val1 + " " + Val2 + " " + duree);
    }

    public void Capacite2(int Val1, int duree, int Val2)
    {
        Debug.Log("Capacite2 : " + Val1 + " " + Val2 + " " + duree);
    }

    public void Capacite3(int Val1, int duree, int Val2)
    {
        Debug.Log("Capacite3 : " + Val1 + " " + Val2 + " " + duree);
    }
}

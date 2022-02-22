using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class _SystemManager : MonoBehaviour
{
    //usefull for damage calculator
    public float modifier = 1f;
    private float rand;
    public float DCC = 2;
    public float minRand = 0.9f;
    public float maxRand = 1.1f;
    private float previsuMaxPV, previsuMinPV;
    private float previsuMana;

    //Stats Characters
    public _PersonnagesManager scriptPersoAttacker;
    public _PersonnagesManager scriptPersoTarget;
    public GameObject target;

    //UI var
    public Image pvBar, pvBarMin, pvBarMax, manaBar, manaBarPrevisu;
    private TextMeshProUGUI tmp_name, tmp_pv, tmp_mana, tmp_attphys, tmp_attmag, tmp_defphys, tmp_defmag, tmp_vitesse, tmp_tauxcc;
    void Start() 
    {
        PhysicalAtt(50, 10, scriptPersoAttacker.attMag, scriptPersoTarget.defMag, scriptPersoAttacker.tauxCC);

        //UI
        tmp_name = GameObject.Find("PrevisuPlayer").transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_pv = GameObject.Find("PrevisuPlayer").transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_mana = GameObject.Find("PrevisuPlayer").transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_attphys = GameObject.Find("PrevisuPlayer").transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_defphys = GameObject.Find("PrevisuPlayer").transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_attmag = GameObject.Find("PrevisuPlayer").transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_defmag = GameObject.Find("PrevisuPlayer").transform.GetChild(6).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_vitesse = GameObject.Find("PrevisuPlayer").transform.GetChild(7).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_tauxcc = GameObject.Find("PrevisuPlayer").transform.GetChild(8).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate() 
    {  

        //UI
        pvBarMax.fillAmount = 1 - (previsuMaxPV / scriptPersoTarget.basePV);
        pvBarMin.fillAmount = 1 - (previsuMinPV / scriptPersoTarget.basePV);
        manaBarPrevisu.fillAmount = 1 - (previsuMana / scriptPersoAttacker.baseMana);

        tmp_name.text = scriptPersoAttacker._name;
        tmp_pv.text = scriptPersoAttacker.actualPV.ToString();
        tmp_mana.text = previsuMana.ToString();
        tmp_attphys.text = scriptPersoAttacker.attPhys.ToString();
        tmp_defphys.text = scriptPersoAttacker.defPhys.ToString();
        tmp_attmag.text = scriptPersoAttacker.attMag.ToString();
        tmp_defmag.text = scriptPersoAttacker.defMag.ToString();
        tmp_vitesse.text = scriptPersoAttacker.vitesse.ToString();
        tmp_tauxcc.text = (scriptPersoAttacker.tauxCC * 100).ToString() + " %";
    }
    public void PhysicalAtt (int power, int cost, int Att, int Def, float tauxCC) 
    {
        rand = Random.Range(minRand, maxRand);
        float minDegats = (power * Att * modifier * minRand) / Def;
        float maxDegats = (power * Att * modifier * maxRand) / Def;
        float actualDegats;

        float checkCC = Random.Range(0.0f, 1.0f);
        if (checkCC <= tauxCC)
        {
            actualDegats = (power * Att * modifier * rand * DCC) / Def; 
            Debug.Log("Crit !!!");
        }
        else actualDegats = (power * Att * modifier * rand) / Def;

        previsuMinPV = (scriptPersoTarget.actualPV - minDegats);
        previsuMaxPV = (scriptPersoTarget.actualPV - maxDegats);

        previsuMana = (scriptPersoAttacker.actualMana - cost);

        //if validation
        scriptPersoTarget.actualPV -= Mathf.RoundToInt(actualDegats);
        if (scriptPersoTarget.actualPV <= 0) Death(target); 
    }
    //MagicalAtt!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    private void Death (GameObject target) 
    {
        GameObject.Destroy(target);
    }
}

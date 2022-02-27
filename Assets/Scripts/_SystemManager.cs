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
    private float actualDegats;
    private float cost;

    //Stats Characters
    public _PersonnagesManager scriptPersoAttacker;
    public _PersonnagesManager scriptPersoTarget;
    public GameObject target;

    //UI var
    public Image pvBar, pvBarMin, pvBarMax, manaBar, manaBarPrevisu;
    private TextMeshProUGUI tmp_name, tmp_pv, tmp_mana, tmp_attphys, tmp_attmag, tmp_defphys, tmp_defmag, tmp_vitesse, tmp_tauxcc;
    private TextMeshProUGUI tmp_nameEnemy, tmp_pvEnemy, tmp_manaEnemy, tmp_attphysEnemy, tmp_attmagEnemy, tmp_defphysEnemy, tmp_defmagEnemy, tmp_vitesseEnemy, tmp_tauxccEnemy;
    void Start() 
    {
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

        tmp_nameEnemy = GameObject.Find("PrevisuEnemy").transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_pvEnemy = GameObject.Find("PrevisuEnemy").transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_manaEnemy = GameObject.Find("PrevisuEnemy").transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_attphysEnemy = GameObject.Find("PrevisuEnemy").transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_defphysEnemy = GameObject.Find("PrevisuEnemy").transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_attmagEnemy = GameObject.Find("PrevisuEnemy").transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_defmagEnemy = GameObject.Find("PrevisuEnemy").transform.GetChild(6).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_vitesseEnemy = GameObject.Find("PrevisuEnemy").transform.GetChild(7).GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp_tauxccEnemy = GameObject.Find("PrevisuEnemy").transform.GetChild(8).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate() 
    {  
        //UI
        tmp_name.text = scriptPersoAttacker._name;
        tmp_pv.text = scriptPersoAttacker.actualPV.ToString();
        tmp_mana.text = scriptPersoAttacker.actualMana.ToString();
        tmp_attphys.text = scriptPersoAttacker.attPhys.ToString();
        tmp_defphys.text = scriptPersoAttacker.defPhys.ToString();
        tmp_attmag.text = scriptPersoAttacker.attMag.ToString();
        tmp_defmag.text = scriptPersoAttacker.defMag.ToString();
        tmp_vitesse.text = scriptPersoAttacker.vitesse.ToString();
        tmp_tauxcc.text = (scriptPersoAttacker.tauxCC * 100).ToString() + " %";

        tmp_nameEnemy.text = scriptPersoTarget._name;
        tmp_pvEnemy.text = scriptPersoTarget.actualPV.ToString();
        tmp_manaEnemy.text = scriptPersoTarget.actualMana.ToString();
        tmp_attphysEnemy.text = scriptPersoTarget.attPhys.ToString();
        tmp_defphysEnemy.text = scriptPersoTarget.defPhys.ToString();
        tmp_attmagEnemy.text = scriptPersoTarget.attMag.ToString();
        tmp_defmagEnemy.text = scriptPersoTarget.defMag.ToString();
        tmp_vitesseEnemy.text = scriptPersoTarget.vitesse.ToString();
        tmp_tauxccEnemy.text = (scriptPersoTarget.tauxCC * 100).ToString() + " %";

        pvBarMax.fillAmount = 1 - (previsuMaxPV / scriptPersoTarget.basePV);
        pvBarMin.fillAmount = 1 - (previsuMinPV / scriptPersoTarget.basePV);
        manaBarPrevisu.fillAmount = 1 - (previsuMana / scriptPersoAttacker.baseMana);
    }

    public void Attack (int power, int cost, int Att, int Def, float tauxCC) 
    {
        rand = Random.Range(minRand, maxRand);
        float minDegats = (power * Att * modifier * minRand) / Def;
        float maxDegats = (power * Att * modifier * maxRand) / Def;

        float checkCC = Random.Range(0.0f, 1.0f);
        if (checkCC <= tauxCC)
        {
            actualDegats = (power * Att * modifier * rand * DCC) / Def; 
            Debug.Log("CRIT !!!");
        }
        else actualDegats = (power * Att * modifier * rand) / Def;

        previsuMinPV = scriptPersoTarget.actualPV - minDegats;
        previsuMaxPV = scriptPersoTarget.actualPV - maxDegats;

        previsuMana = scriptPersoAttacker.actualMana - cost;
    }
    
    public void OnClickValidate ()
    {
        if (scriptPersoAttacker.actualMana >= cost)
        {
            scriptPersoAttacker.actualMana -= Mathf.RoundToInt(cost);
            scriptPersoTarget.actualPV -= Mathf.RoundToInt(actualDegats);
            if (scriptPersoTarget.actualPV <= 0) Death(target);

            //UI
            pvBar.fillAmount -= actualDegats / scriptPersoTarget.basePV;
            manaBar.fillAmount -= cost / scriptPersoAttacker.baseMana;
            pvBarMax.fillAmount = 0;
            pvBarMin.fillAmount = 0;
            manaBarPrevisu.fillAmount = 0;
        }
    }

    public void OnClickCancel () 
    {
        pvBarMax.fillAmount = 0;
        pvBarMin.fillAmount = 0;
        manaBarPrevisu.fillAmount = 0;
    }

    public void OnClickTest ()
    {
        cost = 6;

        Attack(10, Mathf.RoundToInt(cost), scriptPersoAttacker.attMag, scriptPersoTarget.defMag, scriptPersoAttacker.tauxCC);

        pvBarMax.fillAmount = 1 - (previsuMaxPV / scriptPersoTarget.basePV);
        pvBarMin.fillAmount = 1 - (previsuMinPV / scriptPersoTarget.basePV);
        manaBarPrevisu.fillAmount = 1 - (previsuMana / scriptPersoAttacker.baseMana);
    }

    private void Death (GameObject target) 
    {
        GameObject.Destroy(target);
    }
}

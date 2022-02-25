using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class _SystemManager : MonoBehaviour
{
    [Header("Paramètres de combat")]
    public float modifier = 1f;
    public float DCC = 2;
    public float minRand = 0.9f;
    public float maxRand = 1.1f;

    [Header("Equipes")]
    public _PersonnagesManager[] team = new _PersonnagesManager[3];
    public List<_PersonnagesManager> enemyTeam = new List<_PersonnagesManager>();
    public List<_PersonnagesManager> everybody = new List<_PersonnagesManager>();

    [HideInInspector]
    public _PersonnagesManager scriptPersoAttacker, scriptPersoTarget;

    [Header("UI")]
    public Image pvBarAlly;
    public Image pvBarEnemy;
    public Image pvBarMin;
    public Image pvBarMax;
    public Image manaBarAlly;
    public Image manaBarEnemy;
    public Image manaBarPrevisu;

    private float previsuMaxPV, previsuMinPV, previsuMana;

    private TextMeshProUGUI tmp_name, tmp_pv, tmp_mana, tmp_attphys, tmp_attmag, tmp_defphys, tmp_defmag, tmp_vitesse, tmp_tauxcc;
    private TextMeshProUGUI tmp_nameEnemy, tmp_pvEnemy, tmp_manaEnemy, tmp_attphysEnemy, tmp_attmagEnemy, tmp_defphysEnemy, tmp_defmagEnemy, tmp_vitesseEnemy, tmp_tauxccEnemy;


    //Battle
    private int persoStart = 0, enemyStart = 0;

    private bool cardPlayed = false;
    private bool playerPlaying = false, enemyPlaying = false;

    private float minDegats, maxDegats, actualDegats, cost;


    void Start()
    {
        //Initialize battle
        Transform allEnemies = GameObject.Find("EnemyTeam").transform;
        foreach (_PersonnagesManager perso in team)
        {
            if (perso.vitesse > persoStart)
            {
                persoStart = perso.vitesse;
                scriptPersoAttacker = perso;
            }
            everybody.Add(perso);
        }
        foreach (Transform enemy in allEnemies)
        {
            if (enemy.gameObject.GetComponent<_PersonnagesManager>().vitesse > enemyStart)
            {
                enemyStart = enemy.gameObject.GetComponent<_PersonnagesManager>().vitesse;
                scriptPersoTarget = enemy.gameObject.GetComponent<_PersonnagesManager>();
            }
            enemyTeam.Add(enemy.gameObject.GetComponent<_PersonnagesManager>());
        }
        everybody.AddRange(enemyTeam);

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

    void Update()
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

        pvBarAlly.fillAmount = scriptPersoAttacker.fillAmountPV;
        manaBarAlly.fillAmount = scriptPersoAttacker.fillAmountMana;
        pvBarEnemy.fillAmount = scriptPersoTarget.fillAmountPV;
        manaBarEnemy.fillAmount = scriptPersoTarget.fillAmountMana;

        //PLAY
        Play();
    }

    private void Play()
    {
        if (!playerPlaying && !enemyPlaying)
            Load_AttackBar();
        else if (enemyPlaying)
            Enemy_Attack(20, 5, false, scriptPersoTarget, scriptPersoAttacker);
    }

    private void Load_AttackBar()
    {
        foreach (_PersonnagesManager perso in everybody)
        {
            perso.attackBar += perso.vitesse / 100.0f;
            if (perso.attackBar >= 100)
            {
                if (perso == team[0] || perso == team[1] || perso == team[2])
                {
                    Debug.Log(perso._name);
                    playerPlaying = true;
                    scriptPersoAttacker = perso;
                }
                else
                {
                    Debug.Log(perso._name);
                    enemyPlaying = true;
                    scriptPersoTarget = perso;
                }
            }
        }
    }

    private void Player_Attack(int power, int cost, bool phys, _PersonnagesManager attacker, _PersonnagesManager target)
    {
        float rand = Random.Range(minRand, maxRand);
        float checkCC = Random.Range(0.0f, 1.0f);

        if (phys)
        {
            minDegats = (power * attacker.attPhys * modifier * minRand) / target.defPhys;
            maxDegats = (power * attacker.attPhys * modifier * maxRand) / target.defPhys;
            if (checkCC <= attacker.tauxCC)
            {
                actualDegats = (power * attacker.attPhys * modifier * rand * DCC) / target.defPhys;
                Debug.Log("CRIT !!!");
            }
            else actualDegats = (power * attacker.attPhys * modifier * rand) / target.defPhys;
        }
        else
        {
            minDegats = (power * attacker.attMag * modifier * minRand) / target.defMag;
            maxDegats = (power * attacker.attMag * modifier * maxRand) / target.defMag;
            if (checkCC <= attacker.tauxCC)
            {
                actualDegats = (power * attacker.attMag * modifier * rand * DCC) / target.defMag;
                Debug.Log("CRIT !!!");
            }
            else actualDegats = (power * attacker.attMag * modifier * rand) / target.defMag;
        }

        //UI
        if (playerPlaying && cardPlayed)
        {
            previsuMinPV = target.actualPV - minDegats;
            previsuMaxPV = target.actualPV - maxDegats;
            previsuMana = attacker.actualMana - cost;
            pvBarMax.fillAmount = 1 - (previsuMaxPV / target.basePV);
            pvBarMin.fillAmount = 1 - (previsuMinPV / target.basePV);
            manaBarPrevisu.fillAmount = 1 - (previsuMana / attacker.baseMana);
        }
    }

    private void Enemy_Attack(int power, int cost, bool phys, _PersonnagesManager attacker, _PersonnagesManager target)
    {
        Debug.Log(scriptPersoTarget._name + " a attaqué !");
        Player_Attack(power, cost, phys, attacker, target);
        Inflict_Damage(attacker, target);
        enemyPlaying = false;

        if (scriptPersoAttacker.actualPV <= 0) Death(scriptPersoAttacker.gameObject);
    }

    private void Inflict_Damage(_PersonnagesManager attacker, _PersonnagesManager target)
    {
        target.actualPV -= Mathf.RoundToInt(actualDegats);
        target.fillAmountPV -= actualDegats / target.basePV;
        attacker.actualMana -= Mathf.RoundToInt(cost);
        attacker.fillAmountMana -= cost / attacker.baseMana;
        attacker.attackBar = 0;
    }

    private void Death(GameObject target)
    {
        GameObject.Destroy(target);
    }

    public void OnClickTest()
    {
        cardPlayed = true;
        cost = 2;

        Player_Attack(100, Mathf.RoundToInt(cost), true, scriptPersoAttacker, scriptPersoTarget);
    }

    public void OnClickValidate()
    {
        if (playerPlaying && cardPlayed && scriptPersoAttacker.actualMana >= cost)
        {
            Inflict_Damage(scriptPersoAttacker, scriptPersoTarget);
            pvBarMax.fillAmount = 0;
            pvBarMin.fillAmount = 0;
            manaBarPrevisu.fillAmount = 0;
            cardPlayed = false;
            playerPlaying = false;

            if (scriptPersoTarget.actualPV <= 0) Death(scriptPersoTarget.gameObject);
        }
    }

    public void OnClickCancel()
    {
        pvBarMax.fillAmount = 0;
        pvBarMin.fillAmount = 0;
        manaBarPrevisu.fillAmount = 0;
        cardPlayed = false;
    }
}

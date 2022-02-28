using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class _SystemManager : MonoBehaviour
{
    [Header("Parametres de combat")]
    public float modifier = 1f;
    public float DCC = 2;
    public float minRand = 0.9f;
    public float maxRand = 1.1f;
    public float weakness = 2f;
    public float resistance = 0.5f;
    public float attackerOffensive = 1.1f;
    public float attackerDefensive = 0.9f;
    public float targetOffensive = 1.2f;
    public float targetDefensive = 0.8f;
    public float attackBarLoadSpeed = 0.07f;

    [Header("Equipes")]
    public List<_PersonnagesManager> team = new List<_PersonnagesManager>();
    public List<_PersonnagesManager> enemyTeam = new List<_PersonnagesManager>();
    public List<_PersonnagesManager> everybody = new List<_PersonnagesManager>();

    [HideInInspector]
    public _PersonnagesManager scriptPersoAttacker, scriptPersoTarget;

    //UI
    private Image pvBarAlly, manaBarAlly, pvBarEnemy, manaBarEnemy;
    private Image pvBarMin, pvBarMax, manaBarPrevisu;

    private TextMeshProUGUI tmp_name, tmp_pv, tmp_mana, tmp_attphys, tmp_attmag, tmp_defphys, tmp_defmag, tmp_vitesse, tmp_tauxcc;
    private TextMeshProUGUI tmp_nameEnemy, tmp_pvEnemy, tmp_manaEnemy, tmp_attphysEnemy, tmp_attmagEnemy, tmp_defphysEnemy, tmp_defmagEnemy, tmp_vitesseEnemy, tmp_tauxccEnemy;

    private float previsuMaxPV, previsuMinPV, previsuMana;

    //Battle
    private bool cardPlayed = false, basicAttack = false;
    private bool playerPlaying = false, enemyPlaying = false;
    private bool endOfTurn = false, endOfBattle = false;

    private float minDegats, maxDegats, actualDegats, cardCost;



    void Start()
    {
        //UI
        Get_HUD();

        //Initialize Battle
        Initialize_Battle();
    }

    void FixedUpdate()
    {
        //UI
        Set_HUD();

        //PLAY
        Play();
    }

    private void Get_HUD()
    {
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

        pvBarAlly = GameObject.Find("PrevisuPlayer").transform.GetChild(1).GetChild(1).GetComponent<Image>();
        manaBarAlly = GameObject.Find("PrevisuPlayer").transform.GetChild(2).GetChild(1).GetComponent<Image>();
        pvBarEnemy = GameObject.Find("PrevisuEnemy").transform.GetChild(1).GetChild(1).GetComponent<Image>();
        manaBarEnemy = GameObject.Find("PrevisuEnemy").transform.GetChild(2).GetChild(1).GetComponent<Image>();
        pvBarMax = GameObject.Find("PrevisuEnemy").transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
        pvBarMin = GameObject.Find("PrevisuEnemy").transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();
        manaBarPrevisu = GameObject.Find("PrevisuPlayer").transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>();
    }

    private void Set_HUD()
    {
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
    }

    private void Initialize_Battle()
    {
        int persoStart = 0, enemyStart = 0;

        foreach (_PersonnagesManager perso in team)
        {
            everybody.Add(perso);
            if (perso.vitesse > persoStart)
            {
                persoStart = perso.vitesse;
                scriptPersoAttacker = perso;
            }
        }
        foreach (_PersonnagesManager enemy in enemyTeam)
        {
            everybody.Add(enemy);
            if (enemy.vitesse > enemyStart)
            {
                enemyStart = enemy.vitesse;
                scriptPersoTarget = enemy;
            }
        }
    }

    private void Play()
    {
        if (!playerPlaying && !enemyPlaying && !endOfBattle)
            Load_AttackBar();
        else if (enemyPlaying)
            Enemy_Attack(20, 2, false, EnumPerso.elements.Eau, scriptPersoTarget, scriptPersoAttacker);
    }

    private void Load_AttackBar()
    {
        foreach (_PersonnagesManager perso in everybody)
        {
            perso.attackBar += perso.vitesse * attackBarLoadSpeed;
            if (perso.attackBar >= 100)
            {
                Debug.Log("TOUR DE : " + perso._name);
                if (team.Contains(perso))
                {
                    playerPlaying = true;
                    perso.hasPlayed = true;
                    scriptPersoAttacker = perso;
                }
                else
                {
                    enemyPlaying = true;
                    scriptPersoTarget = perso;
                }
            }
        }
    }

    private bool End_Of_Turn()
    {
        foreach (_PersonnagesManager perso in team)
        {
            if (!perso.hasPlayed)
                return false;
        }
        Debug.Log("FIN DU TOUR !!!");
        return true;
    }

    private void Damage_Calculation(int power, bool phys, EnumPerso.elements element, _PersonnagesManager attacker, _PersonnagesManager target)
    {
        float rand = Random.Range(minRand, maxRand);
        float checkCC = Random.Range(0.0f, 1.0f);

        //Damage Calculation
        if (phys)
        {
            minDegats = (power * attacker.attPhys * modifier * minRand) / target.defPhys;
            maxDegats = (power * attacker.attPhys * modifier * maxRand) / target.defPhys;
            actualDegats = (power * attacker.attPhys * modifier * rand) / target.defPhys;
        }
        else
        {
            minDegats = (power * attacker.attMag * modifier * minRand) / target.defMag;
            maxDegats = (power * attacker.attMag * modifier * maxRand) / target.defMag;
            actualDegats = (power * attacker.attMag * modifier * rand) / target.defMag;
        }
        //Weakness / Resistance
        if (element == target.weakness)
        {
            Debug.Log("SUPER EFFICACE !!!");
            minDegats *= weakness;
            maxDegats *= weakness;
            actualDegats *= weakness;
        }
        else if (element == target.resistance)
        {
            Debug.Log("PAS TRES EFFICACE !!!");
            minDegats *= resistance;
            maxDegats *= resistance;
            actualDegats *= resistance;
        }
        //Zones
        if (attacker.zoneOffensive && target.zoneOffensive)
        {
            Debug.Log("OFFENSIF VS OFFENSIF");
            minDegats *= attackerOffensive * targetOffensive;
            maxDegats *= attackerOffensive * targetOffensive;
            actualDegats *= attackerOffensive * targetOffensive;
        }
        else if (attacker.zoneOffensive && !target.zoneOffensive)
        {
            Debug.Log("OFFENSIF VS DEFENSIF");
            minDegats *= attackerOffensive * targetDefensive;
            maxDegats *= attackerOffensive * targetDefensive;
            actualDegats *= attackerOffensive * targetDefensive;
        }
        else if (!attacker.zoneOffensive && target.zoneOffensive)
        {
            Debug.Log("DEFENSIF VS OFFENSIF");
            minDegats *= attackerDefensive * targetOffensive;
            maxDegats *= attackerDefensive * targetOffensive;
            actualDegats *= attackerDefensive * targetOffensive;
        }
        else
        {
            Debug.Log("DEFENSIF VS DEFENSIF");
            minDegats *= attackerDefensive * targetDefensive;
            maxDegats *= attackerDefensive * targetDefensive;
            actualDegats *= attackerDefensive * targetDefensive;
        }
        //Crit
        if (checkCC <= attacker.tauxCC)
        {
            Debug.Log("CRIT !!!");
            actualDegats *= DCC;
        }
    }

    public void Player_Attack(int power, int cost, bool phys, EnumPerso.elements element, _PersonnagesManager attacker, _PersonnagesManager target)
    {
        cardCost = cost;
        cardPlayed = true;

        Damage_Calculation(power, phys, element, attacker, target);
        Load_Previsu();
    }

    public void Enemy_Attack(int power, int cost, bool phys, EnumPerso.elements element, _PersonnagesManager attacker, _PersonnagesManager target)
    {
        cardCost = cost;

        Damage_Calculation(power, phys, element, attacker, target);
        Inflict_Damage(attacker, target);

        enemyPlaying = false;

        //Death
        if (target.actualPV <= 0) Death(target);
    }

    private void Inflict_Damage(_PersonnagesManager attacker, _PersonnagesManager target)
    {
        target.actualPV -= Mathf.RoundToInt(actualDegats);
        target.fillAmountPV -= actualDegats / target.basePV;
        attacker.actualMana -= Mathf.RoundToInt(cardCost);
        attacker.fillAmountMana -= cardCost / attacker.baseMana;
        attacker.attackBar = 0;
        Debug.Log(attacker._name + " a inflige " + Mathf.RoundToInt(actualDegats) + " points de degats a " + target._name);
    }

    private void Death(_PersonnagesManager target)
    {
        if (team.Contains(target))
        {
            team.Remove(target);
            if (team.Count != 0)
                scriptPersoAttacker = team[0];
        }
        else
        {
            enemyTeam.Remove(target);
            if (enemyTeam.Count != 0)
                scriptPersoTarget = enemyTeam[0];
        }
        everybody.Remove(target);
        GameObject.Destroy(target.gameObject);
        Debug.Log(target._name + " est mort !!!");

        Win_Or_Lose();
    }

    private void Win_Or_Lose()
    {
        if (team.Count == 0)
        {
            Debug.Log("DEFAITE !!!");
            endOfBattle = true;
        }
        else if (enemyTeam.Count == 0)
        {
            Debug.Log("VICTOIRE !!!");
            endOfBattle = true;
        }
    }

    private void Load_Previsu()
    {
        previsuMinPV = scriptPersoTarget.actualPV - minDegats;
        previsuMaxPV = scriptPersoTarget.actualPV - maxDegats;
        previsuMana = scriptPersoAttacker.actualMana - cardCost;
        pvBarMax.fillAmount = 1 - (previsuMaxPV / scriptPersoTarget.basePV);
        pvBarMin.fillAmount = 1 - (previsuMinPV / scriptPersoTarget.basePV);
        manaBarPrevisu.fillAmount = 1 - (previsuMana / scriptPersoAttacker.baseMana);
    }

    private void Cancel_Previsu()
    {
        pvBarMax.fillAmount = 0;
        pvBarMin.fillAmount = 0;
        manaBarPrevisu.fillAmount = 0;
        cardPlayed = false;
    }

    public void OnClickAttack()
    {
        Player_Attack(1, 0, true, EnumPerso.elements.Aucun, scriptPersoAttacker, scriptPersoTarget);
        basicAttack = true;
    }

    public void OnClickValidate()
    {
        if (playerPlaying && cardPlayed && scriptPersoAttacker.actualMana >= cardCost)
        {
            if (basicAttack)
            {
                //Mana recovery
                scriptPersoAttacker.actualMana += scriptPersoAttacker.baseMana / 2;
                if (scriptPersoAttacker.actualMana > scriptPersoAttacker.baseMana)
                    scriptPersoAttacker.actualMana = scriptPersoAttacker.baseMana;
                basicAttack = false;
            }
            cardPlayed = false;
            Inflict_Damage(scriptPersoAttacker, scriptPersoTarget);
            Cancel_Previsu();
            playerPlaying = false;

            //Death
            if (scriptPersoTarget.actualPV <= 0) Death(scriptPersoTarget);

            //Check end of turn
            if (endOfTurn = End_Of_Turn())
            {
                foreach (_PersonnagesManager perso in team)
                    perso.hasPlayed = false;
                Debug.Log("NOUVELLE MAIN :)");
            }
        }
    }

    public void OnClickCancel()
    {
        Cancel_Previsu();
    }
}

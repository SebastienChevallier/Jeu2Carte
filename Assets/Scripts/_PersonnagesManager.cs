using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PersonnagesManager : MonoBehaviour
{
   
   [Header("Propriet� du personnage : ")]
	public string _name;
	
    public int attPhys;
	public int attMag;
    public int defPhys;
    public int defMag;

	[Header("Scripts Refs")]
	public SO_Personnages persoRef;
	public EnumCapacites scriptCapacites;

	[Header("Value Skill : ")]
	public EnumCapacites.enumCapacite capacite;
	public int valeur1;
    public int valeur2;
    public int duree;

	

	

	// Start is called before the first frame update
	void Start()
    {
		scriptCapacites = GameObject.Find("GAMEMANAGER").GetComponent<EnumCapacites>();
		CreateCharacter(persoRef);

		scriptCapacites.DoSkill(capacite, valeur1, valeur2, duree);
		scriptCapacites.DoSkill(capacite, valeur1, valeur2, duree);
    }

	public void CreateCharacter(SO_Personnages personnage)
    {
		_name = personnage.name;
        attPhys = personnage.attPhys;
        attMag = personnage.attMag;
        defPhys = personnage.defPhys;
        defMag = personnage.defMag;
        capacite = personnage.capacite;	
    } 
}

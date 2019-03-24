using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSpells : MonoBehaviour {

    delegate void abilityMethods(BaseCharacter caster, BaseCharacter target);
    List<abilityMethods> myAbilityMethods;
    void CreateAbilityMethodsList()
    {

        myAbilityMethods = new List<abilityMethods>();

        myAbilityMethods.Add(BasicAttack);
        myAbilityMethods.Add(CriticalAttack);


    }
    // Use this for initialization
    void Start () {
        CreateAbilityMethodsList();

    }
	
	// Update is called once per frame
	void Update () {
		
	}



    public void ExecuteAbility(int abilityID, BaseCharacter caster, BaseCharacter target)
    {
        myAbilityMethods[abilityID](caster, target);
        Debug.Log("Got Executed");

    }


    public void BasicAttack(BaseCharacter caster, BaseCharacter target)
    {
        target.curHP -= caster.curStrength;
        Debug.Log("Hp Left: " + target.curHP);
    }


    public void CriticalAttack(BaseCharacter caster, BaseCharacter target)
    {
        target.curHP -= caster.curStrength*2;
        Debug.Log("Hp Left: " + target.curHP);

    }
}

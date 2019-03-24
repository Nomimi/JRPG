using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseCharacter : MonoBehaviour {

    public string charakterName;
    public string characterType;


    List<int> AbilityList;
    public Sprite battleAvatar;
    public float timeTillTurn;

    public float baseHP; //The HP describing the players Healthcondition
    public float curHP;


    public float baseStrength;
    public float curStrength;

    public float baseAgility;
    public float agility;

    public bool playerCharakter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UI_RefreshStatus()
    {



    }

    void StatusStunned(float ticksToStun)
    {
        StartCoroutine(setBackStatus(ticksToStun));





    }

    IEnumerator setBackStatus (float ticksToStun)
    {
        yield return new WaitForSeconds(ticksToStun);
        agility = baseAgility;

    }
}

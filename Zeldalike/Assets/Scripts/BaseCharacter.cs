using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour {

    public string charakterName;
    public string characterType;
    


    public Sprite battleAvatar;
    public int timeTillTurn;

    public int baseAgility;
    public int agility;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

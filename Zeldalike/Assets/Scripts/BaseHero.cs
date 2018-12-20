using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BaseHero
{
    public string name;

    public float baseHP; //The HP describing the players Healthcondition
    public float curHP;

    public float baseMP;
    public float curMP;

    public float baseSTA;
    public float curSTA;

    //BattleMechanics
    public int turnCounter;

    public int endurance;
    public int intelligence;
    public int agility;
    public int luck;

}

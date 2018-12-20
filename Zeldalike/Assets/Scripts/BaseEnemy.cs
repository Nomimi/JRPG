using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseEnemy 
{
    public string name;

    public enum Type
    {
        FIRE,
        WATER,
        EARTH,
        AIR

    }

    public Type enemyType;

    public float baseHP; //The HP describing the players Healthcondition
    public float curHP;

    public float baseMP;
    public float curMP;

    public float baseSTA;
    public float curSTA;

    public int endurance;
    public int intelligence;
    public int agility;
    public int luck;

}


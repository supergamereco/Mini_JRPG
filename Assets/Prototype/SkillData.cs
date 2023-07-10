using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillData
{
    public Skill[] skillData;
}

[System.Serializable]
public class Skill
{
    public int id;
    public string category;
    public string type;
    public string name;
    public string description;
    public string element;
    public int level;
    public string targetType;
    public int targetAmount;
    public float damageMultiply;
    public string damageFrom;
    public string statusGiven;
    public string statusTaken;
    public int statusGivenChance;
    public int statusTakenChance;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attacking
{
    public float damage;
    public string damageType;
    public string element;
    public float accuracy;
    public float critChance;
    public float critPower;
    public List<string> status;
    public List<float> chance;
}


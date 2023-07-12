using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayersData
{
    public PlayerData[] playerData;
}

[System.Serializable]
public class PlayerData
{
    public int id;
    public string name;
    public int mainClass_id;
    public int class_id;
    public int level;
    public float maxhp;
    public float maxmp;
    public float speed;
    public float phyPower;
    public float magPower;
    public float critChance;
    public float critPower;
    public float evasion;
    public float hitRate;
    public float defense;
    public float phyRes;
    public float magRes;
    public float statusRes;
    public float fireRes;
    public float iceRes;
    public float windRes;
    public float earthRes;
    public float waterRes;
    public float grassRes;
    public float electricRes;
    public float lightRes;
    public float darkRes;
    public float arcaneRes;
    public float firePower;
    public float icePower;
    public float windPower;
    public float earthPower;
    public float waterPower;
    public float grassPower;
    public float electricPower;
    public float lightPower;
    public float darkPower;
    public float arcanePower;
    public int breakPoint;
    public int[] skill_id;
    public int passive_id;
    public float totalStats;
}

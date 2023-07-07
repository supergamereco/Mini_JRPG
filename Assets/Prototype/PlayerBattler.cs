using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattler : MonoBehaviour
{
    public int m_id;
    public int m_classid;
    public PlayerSkills m_playerSkills;
    public int m_hp;
    public int m_mp;
    public int m_speed;
    public int m_level;
    public int m_phyPower;
    public int m_magPower;
    public int m_critChance;
    public int m_deffense;
    public int m_phyRes;
    public int m_magRes;
    public int m_fireRes;
    public int m_iceRes;
    public int m_windRes;
    public int m_earthRes;
    public int m_waterRes;
    public int m_grassRes;
    public int m_electricRes;
    public int m_lightRes;
    public int m_darkRes;
    public int m_arcaneRes;
    public int m_firePower;
    public int m_icePower;
    public int m_windPower;
    public int m_earthPower;
    public int m_waterPower;
    public int m_grassPower;
    public int m_electricPower;
    public int m_lightPower;
    public int m_darkPower;
    public int m_arcanePower;
    public int m_breakPoint;
    public int m_money;
    public SpriteRenderer playerSprite;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setupPlayer(PlayerData data)
    {
        m_id = data.id;
        m_classid = data.class_id;
        m_playerSkills = data.playerSkills;
        m_hp = data.maxhp;
        m_mp = data.maxmp;
        m_speed = data.speed;
        m_level = data.level;
        m_deffense = data.defense;
        m_phyRes = data.phyRes;
        m_magRes = data.magRes;
        m_fireRes = data.fireRes;
        m_iceRes = data.iceRes;
        m_windRes = data.windRes;
        m_earthRes = data.earthRes;
        m_waterRes = data.waterRes;
        m_grassRes = data.grassRes;
        m_electricRes = data.electricRes;
        m_lightRes = data.lightRes;
        m_darkRes = data.darkRes;
        m_arcaneRes = data.arcaneRes;
        m_firePower = data.firePower;
        m_icePower = data.icePower;
        m_windPower = data.windPower;
        m_earthPower = data.earthPower;
        m_waterPower = data.waterPower;
        m_grassPower = data.grassPower;
        m_electricPower = data.electricPower;
        m_lightPower = data.lightPower;
        m_darkPower = data.darkPower;
        m_arcanePower = data.arcanePower;
        m_breakPoint = data.breakPoint;
        m_money = data.money;
        playerSprite.sprite = DataBase.playerSprite.Get(m_id);
    }
}

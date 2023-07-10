using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattler : Battler
{
    #region baseStats
    public int m_id;
    public string m_name;
    public int m_level;
    public int m_maxhp;
    public int m_maxmp;
    public int m_speed;
    public int m_phyPower;
    public int m_magPower;
    public int m_critChance;
    public int m_critPower;
    public int m_evasion;
    public int m_hitRate;
    public int m_deffense;
    public int m_phyRes;
    public int m_magRes;
    public int m_statusRes;
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
    public List<int> monsterSkillid;
    public int monsterPassiveid;
    #endregion

    #region currentStats
    public int current_classid;
    public int current_level;
    public int current_hp;
    public int current_mp;
    public int current_speed;
    public int current_phyPower;
    public int current_magPower;
    public int current_critChance;
    public int current_critPower;
    public int current_evasion;
    public int current_hitRate;
    public int current_deffense;
    public int current_phyRes;
    public int current_magRes;
    public int current_statusRes;
    public int current_fireRes;
    public int current_iceRes;
    public int current_windRes;
    public int current_earthRes;
    public int current_waterRes;
    public int current_grassRes;
    public int current_electricRes;
    public int current_lightRes;
    public int current_darkRes;
    public int current_arcaneRes;
    public int current_firePower;
    public int current_icePower;
    public int current_windPower;
    public int current_earthPower;
    public int current_waterPower;
    public int current_grassPower;
    public int current_electricPower;
    public int current_lightPower;
    public int current_darkPower;
    public int current_arcanePower;
    public int current_breakPoint;
    public int classPassiveid;
    public int current_barrier;
    public float current_counterChance;
    public int current_totalStats;
    public int isDead = 0;
    public bool isGuard = false;
    public bool isAttacked = false;
    public bool isEvaded = false;
    #endregion

    #region status
    public bool isStun = false;
    public bool isFreeze = false;
    public bool isParalyze = false;
    public bool isSleep = false;
    public bool isRoot = false;
    public bool isTerrify = false;
    public bool isTaunt = false;
    public bool isBurn = false;
    public bool isForstbite = false;
    public bool isPoison = false;
    public bool isCorrupt = false;
    public bool isBleed = false;
    public bool isDeAtk = false;
    public bool isDeMAtk = false;
    public bool isDeDef = false;
    public bool isDeMagRes = false;
    public bool isDePhyRes = false;
    public bool isVulnerable = false;
    public bool isSlow = false;
    public bool isUnhealable = false;
    public bool isDoom = false;
    public bool isWeakness = false;
    public bool isTargeted = false;
    public bool isBlind = false;
    public bool isInAtk = false;
    public bool isInMAtk = false;
    public bool isInDef = false;
    public bool isInMagRes = false;
    public bool isInPhyRes = false;
    public bool isBarrier = false;
    public bool isSwiftness = false;
    public bool isProtection = false;
    public bool isRegen = false;
    public bool isAegis = false;
    public bool isImmunity = false;
    public bool isFury = false;
    public bool isMight = false;
    public bool isStability = false;
    public bool isQuickness = false;
    public bool isAccuracy = false;
    #endregion

    public SpriteRenderer enemySprite;
    public Animator enemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setupEnemy(EnemyData data)
    {
        #region setupBaseStats
        m_id = data.id;
        m_maxhp = data.maxhp;
        m_maxmp = data.maxmp;
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
        #endregion

        #region setupCurrentStats
        current_hp = data.maxhp;
        current_mp = data.maxmp;
        current_speed = data.speed;
        current_deffense = data.defense;
        current_phyRes = data.phyRes;
        current_magRes = data.magRes;
        current_fireRes = data.fireRes;
        current_iceRes = data.iceRes;
        current_windRes = data.windRes;
        current_earthRes = data.earthRes;
        current_waterRes = data.waterRes;
        current_grassRes = data.grassRes;
        current_electricRes = data.electricRes;
        current_lightRes = data.lightRes;
        current_darkRes = data.darkRes;
        current_arcaneRes = data.arcaneRes;
        current_firePower = data.firePower;
        current_icePower = data.icePower;
        current_windPower = data.windPower;
        current_earthPower = data.earthPower;
        current_waterPower = data.waterPower;
        current_grassPower = data.grassPower;
        current_electricPower = data.electricPower;
        current_lightPower = data.lightPower;
        current_darkPower = data.darkPower;
        current_arcanePower = data.arcanePower;
        current_breakPoint = data.breakPoint;
        #endregion

        enemySprite.sprite = DataBase.enemySprite.Get(m_id);
    }
}

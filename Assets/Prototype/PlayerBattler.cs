using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattler : MonoBehaviour
{
    #region baseStats
    public int m_id;
    public string m_name;
    public int m_mainClassid;
    public int m_classid;
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
    public List<int> characterSkillid;
    public List<int> classSkillid;
    public int characterPassiveid;
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

    public SpriteRenderer playerSprite;
    public Animator playerAnimator;

    public void setupPlayer(PlayerData data)
    {
        m_id = data.id;
        m_name = data.name;
        m_mainClassid = data.mainClass_id;
        m_classid = data.class_id;
        m_level = data.level;
        m_maxhp = data.maxhp;
        m_maxmp = data.maxmp;
        m_speed = data.speed;
        m_phyPower = data.phyPower;
        m_magPower = data.magPower;
        m_critChance = data.critChance;
        m_critPower = data.critPower;
        m_evasion = data.evasion;
        m_hitRate = data.hitRate;
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
        for(int i = 0; i < data.skill_id.Length; i++)
        {
            characterSkillid.Add(data.skill_id[i]);
        }
        characterPassiveid = data.passive_id;
        playerSprite.sprite = DataBase.playerSprite.Get(m_id);
    }

    public void GetResurrected()
    {
        isDead = 0;
    }

    public void Attacked(Attacking attack)
    {
        Evade(attack.accuracy);
        if (!isEvaded)
        {
            TakeDamage(attack.damage, attack.damageType, attack.element);
        }
        else
        {
            isEvaded = false;
        }
    }

    public void Evade(float accuracy)
    {
        float evasionCalculateSum = accuracy + current_evasion;
        float number = 0;
        number = Random.Range(0, evasionCalculateSum);
        if(current_evasion != 0)
        {
            if (accuracy - current_evasion > 0)
            {
                if (number <= current_evasion)
                {
                    isEvaded = true;
                }
            }
            else
            {
                if (number > accuracy)
                {
                    isEvaded = true;
                }
            }
        }
    }

    public void TakeDamage(int damage, string damageType, string element)
    {
        int rawDamage = 0;
        int damageRecieved = 0;
        if (damageType == "physical")
        {
            rawDamage = damage - ((damage * current_phyRes) / 100);
        }
        else if (damageType == "magical")
        {
            rawDamage = damage - ((damage * current_magRes) / 100);
            //-------Calculate Elemental Resistance
            switch (element)
            {
                case "fire":
                    rawDamage = rawDamage - ((rawDamage * current_fireRes) / 100);
                    break;
                case "ice":
                    rawDamage = rawDamage - ((rawDamage * current_iceRes) / 100);
                    break;
                case "wind":
                    rawDamage = rawDamage - ((rawDamage * current_windRes) / 100);
                    break;
                case "earth":
                    rawDamage = rawDamage - ((rawDamage * current_earthRes) / 100);
                    break;
                case "water":
                    rawDamage = rawDamage - ((rawDamage * current_waterRes) / 100);
                    break;
                case "electric":
                    rawDamage = rawDamage - ((rawDamage * current_electricRes) / 100);
                    break;
                case "grass":
                    rawDamage = rawDamage - ((rawDamage * current_grassRes) / 100);
                    break;
                case "light":
                    rawDamage = rawDamage - ((rawDamage * current_lightRes) / 100);
                    break;
                case "dark":
                    rawDamage = rawDamage - ((rawDamage * current_darkRes) / 100);
                    break;
                case "arcane":
                    rawDamage = rawDamage - ((rawDamage * current_arcaneRes) / 100);
                    break;
            }
        }
        if (isGuard)
        {
            rawDamage = rawDamage - ((rawDamage * 30) / 100);
        }
        if(current_barrier != 0)
        {
            if (rawDamage > current_barrier)
            {
                damageRecieved = rawDamage - current_barrier;
            }
            else
            {
                damageRecieved = current_barrier - rawDamage;
            }

        }
        if (!isProtection)
        {
            current_hp = current_hp - damageRecieved;
        }
    }

    public void Guard(bool guard)
    {
        isGuard = guard;
    }

    public void Block(bool block)
    {
        isProtection = block;
    }

    public void getBarrier(int barrier)
    {
        current_barrier = barrier;
    }

    public void getStatus(string[] status, int[] chance)
    {
        for(int i = 0; i < status.Length; i++)
        {
            float statusResistCalculateSum = chance[i] + current_statusRes;
            float number = 0;
            number = Random.Range(0, statusResistCalculateSum);

            //---------------------Continue---**-*----

            if (current_statusRes > 0)
            {
                if (chance[i] - current_statusRes > 0)
                {
                    if (number <= chance[i])
                    {
                        FindStatus(status[i]);
                    }
                }
                else
                {
                    if (number > current_statusRes)
                    {
                        FindStatus(status[i]);
                    }
                }
            }
        }
    }

    private void FindStatus(string status)
    {
        switch (status)
        {
            case "stun":
                isStun = true;
                break;
            case "freeze":
                isFreeze = true;
                break;
            case "paralyze":
                isParalyze = true;
                break;
            case "sleep":
                isSleep = true;
                break;
            case "root":
                isRoot = true;
                break;
            case "terrify":
                isTerrify = true;
                break;
            case "taunt":
                isTaunt = true;
                break;
            case "burn":
                isBurn = true;
                break;
            case "frostbite":
                isForstbite = true;
                break;
            case "poison":
                isPoison = true;
                break;
            case "corrupt":
                isCorrupt = true;
                break;
            case "bleed":
                isBleed = true;
                break;
            case "deAtk":
                isDeAtk = true;
                break;
            case "deMAtk":
                isDeMAtk = true;
                break;
            case "deDef":
                isDeDef = true;
                break;
            case "deMagRes":
                isDeMagRes = true;
                break;
            case "dePhyRes":
                isDePhyRes = true;
                break;
            case "vulnerable":
                isVulnerable = true;
                break;
            case "slow":
                isSlow = true;
                break;
            case "unHealable":
                isUnhealable = true;
                break;
            case "doom":
                isDoom = true;
                break;
            case "weakness":
                isWeakness = true;
                break;
            case "targeted":
                isTargeted = true;
                break;
            case "blind":
                isBlind = true;
                break;
            case "inAtk":
                isInAtk = true;
                break;
            case "inMAtk":
                isInMAtk = true;
                break;
            case "inDef":
                isInDef = true;
                break;
            case "inMagRes":
                isInMagRes = true;
                break;
            case "inPhyRes":
                isInPhyRes = true;
                break;
            case "barrier":
                isBarrier = true;
                break;
            case "swiftness":
                isSwiftness = true;
                break;
            case "protection":
                isProtection = true;
                break;
            case "regen":
                isRegen = true;
                break;
            case "aegis":
                isAegis = true;
                break;
            case "immunity":
                isImmunity = true;
                break;
            case "fury":
                isFury = true;
                break;
            case "might":
                isMight = true;
                break;
            case "stability":
                isStability = true;
                break;
            case "quickness":
                isQuickness = true;
                break;
            case "accuracy":
                isAccuracy = true;
                break;
        }
    }
}

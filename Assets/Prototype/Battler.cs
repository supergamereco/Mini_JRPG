using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Battler : MonoBehaviour
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
    public List<int> battlerSkillid;
    public int battlerPassiveid;
    #endregion

    #region currentStats
    public int current_level;
    public float current_hp;
    public float current_mp;
    public float current_speed;
    public float current_phyPower;
    public float current_magPower;
    public float current_critChance;
    public float current_critPower;
    public float current_evasion;
    public float current_hitRate;
    public int current_deffense;
    public float current_phyRes;
    public float current_magRes;
    public float current_statusRes;
    public float current_fireRes;
    public float current_iceRes;
    public float current_windRes;
    public float current_earthRes;
    public float current_waterRes;
    public float current_grassRes;
    public float current_electricRes;
    public float current_lightRes;
    public float current_darkRes;
    public float current_arcaneRes;
    public float current_firePower;
    public float current_icePower;
    public float current_windPower;
    public float current_earthPower;
    public float current_waterPower;
    public float current_grassPower;
    public float current_electricPower;
    public float current_lightPower;
    public float current_darkPower;
    public float current_arcanePower;
    public int current_breakPoint;
    public float current_barrier;
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

    public SpriteRenderer battlerSprite;
    public Animator battlerAnimator;

    public void Attacked(Attacking attack, Battler attacker)
    {
        Evade(attack.accuracy);
        if (!isEvaded)
        {
            TakeDamage(attack, attacker);
        }
        else if (!isProtection)
        {
            TakeDamage(attack, attacker);
        }
        else
        {
            isEvaded = false;
        }
    }

    public void GetResurrected()
    {
        isDead = 0;
    }

    public void Attack(Skill skill, Battler attacker, Battler defender)
    {
        Attacking attack;
        attack = SkillFormular.damageDealt.Get(skill, attacker);
        defender.Attacked(attack, attacker);
    }

    public void Evade(float accuracy)
    {
        float evasionCalculateSum = accuracy + current_evasion;
        float number = 0;
        number = Random.Range(0, evasionCalculateSum);
        if (current_evasion != 0)
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

    public void TakeDamage(Attacking attack, Battler attacker)
    {
        float rawDamage = 0;
        float damageRecieved = 0;
        if (attack.damageType == "physical")
        {
            rawDamage = attack.damage - ((attack.damage * current_phyRes) / 100);
            float number = Random.Range(0, 100);
            if (number <= attack.critChance)
            {
                rawDamage = CriticalCalculation(rawDamage, attack.critPower);
            }
        }
        else if (attack.damageType == "magical")
        {
            rawDamage = attack.damage - ((attack.damage * current_magRes) / 100);
            float number = Random.Range(0, 100);
            if (number <= attack.critChance)
            {
                rawDamage = CriticalCalculation(rawDamage, attack.critPower);
            }
            //-------Calculate Elemental Resistance
            switch (attack.element)
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
        if (current_barrier != 0)
        {
            if (rawDamage > current_barrier)
            {
                damageRecieved = rawDamage - current_barrier;
                current_barrier = 0;
            }
            else
            {
                current_barrier = current_barrier - rawDamage;
                damageRecieved = 0;
            }

        }
        current_hp = current_hp - damageRecieved;
        Counter(current_counterChance, attacker);
    }

    private float criticalDamageRecieved;
    private float CriticalCalculation(float damage, float critPower)
    {
        criticalDamageRecieved = damage + (damage * critPower);
        return criticalDamageRecieved;
    }

    public void Guard(bool guard)
    {
        isGuard = guard;
    }

    public void getBarrier(int barrier)
    {
        current_barrier = barrier;
    }

    public void Counter(float counterChance, Battler attacker)
    {
        float number = 0;
        number = Random.Range(0, 100);
        if (counterChance > 0)
        {
            if (number <= counterChance)
            {
                // Continue ------ Move SkillList from Battle to Battler!!!
                //Attack(this.battlerSkillid[0], this, attacker);
            }
        }
    }

    public void getCounterChance(float chance)
    {
        current_counterChance = chance;
    }

    public void getStatus(string[] status, int[] chance)
    {
        for (int i = 0; i < status.Length; i++)
        {
            float statusResistCalculateSum = 0;
            statusResistCalculateSum = chance[i] + current_statusRes;
            float number = 0;
            number = Random.Range(0, statusResistCalculateSum);

            if (current_statusRes > 0)
            {
                if (chance[i] - current_statusRes > 0)
                {
                    if (number > current_statusRes)
                    {
                        FindStatus(status[i]);
                    }
                }
                else
                {
                    if (number <= chance[i])
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


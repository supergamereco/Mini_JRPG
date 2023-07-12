using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFormular : MonoBehaviour
{
    public class DealingSingleTargetDamage
    {
        public Attacking _damageDealt = new Attacking();

        public Attacking Get(Skill skill, Battler battler)
        {
            float damageStats = 0;
            switch (skill.damageFrom)
            {
                case "phyPower":
                    damageStats = battler.current_phyPower;
                    break;
                case "magPower":
                    damageStats = battler.current_magPower;
                    break;
                case "maxhp":
                    damageStats = battler.m_maxhp;
                    break;
                case "maxmp":
                    damageStats = battler.m_maxmp;
                    break;
                case "currenthp":
                    damageStats = battler.current_hp;
                    break;
                case "currentmp":
                    damageStats = battler.current_mp;
                    break;
                case "speed":
                    damageStats = battler.current_speed;
                    break;
            }

            _damageDealt.damage = damageStats * (skill.damageMultiply/100);
            _damageDealt.damageType = skill.type;
            _damageDealt.element = skill.element;
            float elementAmp = 0;
            switch (skill.element)
            {
                case "fire":
                    elementAmp = (_damageDealt.damage * battler.current_firePower) / 100;
                    _damageDealt.damage = _damageDealt.damage + elementAmp;
                    break;
                case "ice":
                    elementAmp = (_damageDealt.damage * battler.current_icePower) / 100;
                    _damageDealt.damage = _damageDealt.damage + elementAmp;
                    break;
                case "water":
                    elementAmp = (_damageDealt.damage * battler.current_waterPower) / 100;
                    _damageDealt.damage = _damageDealt.damage + elementAmp;
                    break;
                case "wind":
                    elementAmp = (_damageDealt.damage * battler.current_windPower) / 100;
                    _damageDealt.damage = _damageDealt.damage + elementAmp;
                    break;
                case "earth":
                    elementAmp = (_damageDealt.damage * battler.current_earthPower) / 100;
                    _damageDealt.damage = _damageDealt.damage + elementAmp;
                    break;
                case "grass":
                    elementAmp = (_damageDealt.damage * battler.current_grassPower) / 100;
                    _damageDealt.damage = _damageDealt.damage + elementAmp;
                    break;
                case "electric":
                    elementAmp = (_damageDealt.damage * battler.current_electricPower) / 100;
                    _damageDealt.damage = _damageDealt.damage + elementAmp;
                    break;
                case "light":
                    elementAmp = (_damageDealt.damage * battler.current_lightPower) / 100;
                    _damageDealt.damage = _damageDealt.damage + elementAmp;
                    break;
                case "dark":
                    elementAmp = (_damageDealt.damage * battler.current_darkPower) / 100;
                    _damageDealt.damage = _damageDealt.damage + elementAmp;
                    break;
                case "arcane":
                    elementAmp = (_damageDealt.damage * battler.current_arcanePower) / 100;
                    _damageDealt.damage = _damageDealt.damage + elementAmp;
                    break;
            }
            _damageDealt.accuracy = battler.current_hitRate;
            _damageDealt.critChance = battler.current_critChance;
            _damageDealt.critPower = battler.current_critPower;
            for (int i = 0; i < skill.statusGiven.Length; i++)
            {
                _damageDealt.status.Add(skill.statusGiven);
                _damageDealt.chance.Add(skill.statusGivenChance);
            }
            return _damageDealt;
        }
    }
    public readonly static DealingSingleTargetDamage damageDealt = new DealingSingleTargetDamage();
}

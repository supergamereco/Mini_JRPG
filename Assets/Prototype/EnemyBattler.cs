using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnemyBattler : Battler
{
    [SerializeField]
    private UnityEvent _clicked;
    private BattleSceneMouseInput _mouse;

    public void Awake()
    {
        _mouse = FindObjectOfType<BattleSceneMouseInput>();
        _mouse.ClickedOnEnemy += MouseOnClicked;
    }

    public void setupEnemy(EnemyData data)
    {
        battlerSide = "enemy";

        #region setupBaseStats
        m_id = data.id;
        m_name = data.name;
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
        m_statusRes = data.statusRes;
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
        for (int i = 0; i < data.skill_id.Length; i++)
        {
            battlerSkillid.Add(data.skill_id[i]);
        }
        battlerPassiveid = data.passive_id;
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

        LoadJsonSkillData();

        battlerSprite.sprite = DataBase.enemySprite.Get(m_id);
    }

    public void MouseOnClicked()
    {
        Debug.Log("Clicked");
        Destroy(gameObject);
        _clicked?.Invoke();
    }

    public void onTargeted()
    {
        BattleManager.Instance.PlayerSelectTarget(this);
    }
}

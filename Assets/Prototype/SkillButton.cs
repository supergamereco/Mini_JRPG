using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public int m_skill_id;
    public string m_skill_category;
    public string m_skill_type;
    public string m_skill_name;
    public string m_skill_description;
    public string m_skill_element;
    public int m_skill_level;
    public string m_skill_targetType;
    public int m_skill_targetAmount;
    public float m_skill_damageMultiply;
    public string m_skill_damageFrom;
    public bool m_skill_criticalAble;
    public string m_skill_statusGiven;
    public string m_skill_statusTaken;
    public float m_skill_statusGivenChance;
    public float m_skill_statusTakenChance;
    public Image skillSprite;
    public Skill m_skill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSkillButton(Skill skill)
    {
        m_skill = skill;
        //m_skill_id = skill.id;
        //m_skill_category = skill.category;
        //m_skill_type = skill.type;
        //m_skill_name = skill.name;
        //m_skill_description = skill.description;
        //m_skill_element = skill.element;
        //m_skill_level = skill.level;
        //m_skill_targetType = skill.targetType;
        //m_skill_targetAmount = skill.targetAmount;
        //m_skill_damageMultiply = skill.damageMultiply;
        //m_skill_damageFrom = skill.damageFrom;
        //m_skill_criticalAble = skill.criticalAble;
        //m_skill_statusGiven = skill.statusGiven;
        //m_skill_statusTaken = skill.statusTaken;
        //m_skill_statusGivenChance = skill.statusGivenChance;
        //m_skill_statusTakenChance = skill.statusTakenChance;
        skillSprite.sprite = DataBase.skillSprite.Get(m_skill_id);
    }

    public void OnClick()
    {
        BattleManager.Instance.battleState = "playerSelectTarget";
        BattleManager.Instance.currentSkill = m_skill;
        BattleManager.Instance.characterSkillPanel.SetActive(false);
        BattleManager.Instance.classSkillPanel.SetActive(false);
    }
}

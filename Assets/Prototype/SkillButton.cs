using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public int m_skill_index;
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

    public void setSkillButton(Skill skill, int index)
    {
        m_skill_index = index;
        m_skill = skill;
        m_skill_id = m_skill.id;
        m_skill_category = m_skill.category;
        m_skill_type = m_skill.type;
        m_skill_name = m_skill.name;
        m_skill_description = m_skill.description;
        m_skill_element = m_skill.element;
        m_skill_level = m_skill.level;
        m_skill_targetType = m_skill.targetType;
        m_skill_targetAmount = m_skill.targetAmount;
        m_skill_damageMultiply = m_skill.damageMultiply;
        m_skill_damageFrom = m_skill.damageFrom;
        m_skill_criticalAble = m_skill.criticalAble;
        m_skill_statusGiven = m_skill.statusGiven;
        m_skill_statusTaken = m_skill.statusTaken;
        m_skill_statusGivenChance = m_skill.statusGivenChance;
        m_skill_statusTakenChance = m_skill.statusTakenChance;
        skillSprite.sprite = DataBase.skillSprite.Get(m_skill_id);
        BattleManager.Instance.playerSkillList.Add(skill);
    }

    public void OnClick()
    {
        BattleManager.Instance.battleState = "playerSelectTarget";

        Debug.Log(m_skill_index);
        BattleManager.Instance.onSkillSelected(m_skill_index);
        BattleManager.Instance.characterSkillPanel.SetActive(false);
        BattleManager.Instance.classSkillPanel.SetActive(false);
    }
}

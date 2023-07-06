using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillButton : MonoBehaviour
{
    public int m_skill_id;
    public string m_skill_category;
    public string m_skill_type;
    public string m_skill_name;
    public string m_skill_description;
    public string m_skill_element;
    public int m_skill_level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSkillButton(int id, string category, string type, string name, string description, string element, int level)
    {
        m_skill_id = id;
        m_skill_category = category;
        m_skill_type = type;
        m_skill_name = name;
        m_skill_description = description;
        m_skill_element = element;
        m_skill_level = level;
    }

    public void OnClick()
    {
        Battle.Instance.battleState = "playerSelectTarget";

    }
}

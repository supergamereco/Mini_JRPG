using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public static Battle Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public List<PlayerData> playerList = new List<PlayerData>();
    public List<Skill> player1SkillList = new List<Skill>();
    public List<Skill> player2SkillList = new List<Skill>();
    public List<Skill> player3SkillList = new List<Skill>();
    public List<Skill> player4SkillList = new List<Skill>();
    public List<EnemyData> enemyList = new List<EnemyData>();
    public TextMeshProUGUI[] playerHPtext;
    public TextMeshProUGUI[] enemyHPtext;
    public GameObject PlayerZone;
    public GameObject EnemyZone;
    public Transform PlayerParent;
    public Transform EnemyParent;
    public GameObject playerPrafab;
    public GameObject enemyPrafab;
    public GameObject invisibleFrame;
    public GameObject characterSkillPanel;
    public GameObject classSkillPanel;
    public GameObject[] skillButton;
    public string battleState;
    public int currentSkill_id;
    public string currentTurn;
    public string side;

    public void setBattleScene()
    {
        LoadJsonPlayerData();
        LoadJsonEnemyData();
        //--------------------------Instantiate Player Battler-----------------------------

        for (int i = 0; i < playerList.Count; i++)
        {
            Utils.BalanceBattlerPrefabs(playerPrafab, PlayerZone.transform.GetChild(i).transform);
        }
        for (int i = 0; i < playerList.Count; i++)
        {
            PlayerBattler player = PlayerZone.transform.GetChild(i).transform.GetChild(0).GetComponent<PlayerBattler>();
            player.setupPlayer(playerList[i]);
        }

        //--------------------------Instantiate Enemy Battler-----------------------------

        for (int i = 0; i < enemyList.Count; i++)
        {
            Utils.BalanceBattlerPrefabs(enemyPrafab, EnemyZone.transform.GetChild(i).transform);
        }
        for (int i = 0; i < enemyList.Count; i++)
        {
            EnemyBattler enemy = EnemyZone.transform.GetChild(i).GetChild(0).GetComponent<EnemyBattler>();
            enemy.setupEnemy(enemyList[i]);
        }
    }

    private void setupSkillUI(int playerTurn)
    {
        //--------------------------Setup Skill UI-----------------------------
        if(playerTurn == 1)
        {
            for (int i = 0; i < player1SkillList.Count; i++)
            {
                skillButton[i].GetComponent<SkillButton>().setSkillButton(player1SkillList[i]);
            }
        }
       else if (playerTurn == 2)
        {
            for (int i = 0; i < player1SkillList.Count; i++)
            {
                skillButton[i].GetComponent<SkillButton>().setSkillButton(player1SkillList[i]);
            }
        }
        else if(playerTurn == 3)
        {
            for (int i = 0; i < player1SkillList.Count; i++)
            {
                skillButton[i].GetComponent<SkillButton>().setSkillButton(player1SkillList[i]);
            }
        }
        else if(playerTurn == 4)
        {
            for (int i = 0; i < player1SkillList.Count; i++)
            {
                skillButton[i].GetComponent<SkillButton>().setSkillButton(player1SkillList[i]);
            }
        }
    }

    public TextAsset jsonPlayerFile;

    void LoadJsonPlayerData()
    {
        PlayersData playerDataInJson = JsonUtility.FromJson<PlayersData>(jsonPlayerFile.text);

        foreach (PlayerData playerData in playerDataInJson.playerData)
        {
            Debug.Log("ID " + playerData.id + "HP " + playerData.maxhp);
            playerList.Add(playerData);
        }
        for (int i = 0; i < playerList.Count; i++)
        {
            LoadJsonSkillData(i+1, playerList[i]);
        }
    }

    public TextAsset jsonSkillFile;

    void LoadJsonSkillData(int playerIndex, PlayerData player)
    {
        SkillData skillDataInJson = JsonUtility.FromJson<SkillData>(jsonSkillFile.text);

        foreach (Skill skillData in skillDataInJson.skillData)
        {
            Debug.Log("ID " + skillData.id + "Name " + skillData.name);
            for(int i = 0; i < player.skill_id.Length; i++)
            {
                if (skillData.id == player.skill_id[i])
                {
                    switch (playerIndex)
                    {
                        case 1:
                            player1SkillList.Add(skillData);
                            break;
                        case 2:
                            player2SkillList.Add(skillData);
                            break;
                        case 3:
                            player3SkillList.Add(skillData);
                            break;
                        case 4:
                            player4SkillList.Add(skillData);
                            break;
                    }
                }
            }
        }
    }

    public TextAsset jsonEnemyFile;

    void LoadJsonEnemyData()
    {
        EnemiesData enemyDataInJson = JsonUtility.FromJson<EnemiesData>(jsonEnemyFile.text);

        foreach (EnemyData enemyData in enemyDataInJson.enemyData)
        {
            Debug.Log("ID " + enemyData.id + "HP " + enemyData.maxhp);
            enemyList.Add(enemyData);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(battleState == "PlayerSelectTarget")
        //{

        //}
    }

    public void onCharacterSkillClick()
    {
        battleState = "PlayerSelectCharacterSkill";
        characterSkillPanel.SetActive(true);
    }

    public void onCloseCharacterSkill()
    {
        characterSkillPanel.SetActive(false);
    }

    public void onClassSkillClick()
    {
        battleState = "PlayerSelectClassSkill";
        classSkillPanel.SetActive(true);
    }

    public void onCloseClassSkill()
    {
        classSkillPanel.SetActive(false);
    }

    public void setStatePlayerSelectTarget(int skill_id)
    {
        battleState = "PlayerSelectTarget";
        invisibleFrame.SetActive(true);
        currentSkill_id = skill_id;
    }
}

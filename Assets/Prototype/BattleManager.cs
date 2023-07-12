using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public GameObject[] prototypeSettingButton;
    public List<PlayerData> playerDataList = new List<PlayerData>();
    public List<PlayerBattler> playerList = new List<PlayerBattler>();
    public List<EnemyData> enemyDataList = new List<EnemyData>();
    public List<EnemyBattler> enemyList = new List<EnemyBattler>();
    public List<Battler> battlerList = new List<Battler>();
    public List<Battler> battlerListPlayed = new List<Battler>();
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
    public GameObject[] characterSkillButton;
    public GameObject[] classSkillButton;
    public Image currentTurnBattlerImage;
    public string battleState;
    public Skill currentSkill;
    private int currentTurnUnitid;
    private int currentTurnBattlerid;
    private int _unitid;
    public string side;

    public void setupBattleScene()
    {
        LoadJsonPlayerData();
        LoadJsonEnemyData();
        #region Instantiate Player Battler
        for (int i = 0; i < playerDataList.Count; i++)
        {
            Utils.BalanceBattlerPrefabs(playerPrafab, PlayerZone.transform.GetChild(i).transform);
        }
        for (int i = 0; i < playerDataList.Count; i++)
        {
            PlayerBattler player = PlayerZone.transform.GetChild(i).transform.GetChild(0).GetComponent<PlayerBattler>();
            player.setupPlayer(playerDataList[i]);
            _unitid = _unitid + i;
            player.unitid = _unitid;
            playerList.Add(player);
        }
        #endregion

        #region Instantiate Enemy Battler
        for (int i = 0; i < enemyDataList.Count; i++)
        {
            Utils.BalanceBattlerPrefabs(enemyPrafab, EnemyZone.transform.GetChild(i).transform);
        }
        for (int i = 0; i < enemyDataList.Count; i++)
        {
            EnemyBattler enemy = EnemyZone.transform.GetChild(i).GetChild(0).GetComponent<EnemyBattler>();
            enemy.setupEnemy(enemyDataList[i]);
            _unitid = _unitid + i;
            enemy.unitid = i;
            enemyList.Add(enemy);
        }
        #endregion

        TurnSequence();
    }

    public void resetBattleScene()
    {
        playerDataList.Clear();
        enemyDataList.Clear();
        playerList.Clear();
        enemyList.Clear();
        battlerList.Clear();
        battlerListPlayed.Clear();
        for (int i = 0; i < PlayerZone.transform.childCount; i++)
        {
            if (PlayerZone.transform.GetChild(i).transform.childCount != 0)
            {
                PlayerZone.transform.GetChild(i).transform.GetChild(0).GetComponent<PlayerBattler>().DestroyBattler();
            }
        }
        for (int i = 0; i < EnemyZone.transform.childCount; i++)
        {
            if (EnemyZone.transform.GetChild(i).transform.childCount != 0)
            {
                EnemyZone.transform.GetChild(i).transform.GetChild(0).GetComponent<EnemyBattler>().DestroyBattler();
            }
        }
    }

    public void TurnSequence()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            battlerList.Add(playerList[i]);
        }
        for (int i = 0; i < enemyList.Count; i++)
        {
            battlerList.Add(enemyList[i]);
        }
        float mostSpeed = 0;
        for (int i = 0; i < battlerList.Count; i++)
        {
            float speedTemp = battlerList[i].current_speed;
            if (speedTemp > mostSpeed)
            {
                mostSpeed = speedTemp;
                side = battlerList[i].battlerSide;
                currentTurnUnitid = battlerList[i].unitid;
                currentTurnBattlerid = battlerList[i].m_id;
            }
        }
        if(side == "player")
        {
            invisibleFrame.SetActive(false);
            currentTurnBattlerImage.sprite = DataBase.playerSprite.Get(currentTurnBattlerid);
            //----Waiting for Player Action
        }
        else
        {
            invisibleFrame.SetActive(true);
            currentTurnBattlerImage.sprite = DataBase.enemySprite.Get(currentTurnBattlerid);
            //----Enemy Action Method
        }
        //------- Removed played unit
        //for (int i = 0; i < battlerList.Count; i++)
        //{
        //    if (battlerList[i].unitid == currentTurnUnitid)
        //    {
        //        battlerList.Remove(battlerList[i]);
        //    }
        //}
    }

    private void setupCharacterSkillUI()
    {
        //--------------------------Setup Skill UI-----------------------------
        int index = 0;
        for (int i = 0; i < battlerList.Count; i++)
        {
            for (int j = 0; j < playerList.Count; j++)
            {
                if (battlerList[i].m_id == playerList[j].m_id && battlerList[i].battlerSide == playerList[j].battlerSide
                    && playerList[j].m_id == currentTurnBattlerid)
                {
                    index = j;
                }
            }
        }
        for (int i = 0; i < playerList[index].battlerSkillList.Count; i++)
        {
            characterSkillButton[i].GetComponent<SkillButton>().setSkillButton(playerList[index].battlerSkillList[i]);
        }
    }

    private void setupClassSkillUI()
    {
        //--------------------------Setup Skill UI-----------------------------
        int index = 0;
        for (int i = 0; i < battlerList.Count; i++)
        {
            for (int j = 0; j < playerList.Count; j++)
            {
                if (battlerList[i].m_id == playerList[j].m_id && battlerList[i].battlerSide == playerList[j].battlerSide
                    && playerList[j].m_id == currentTurnBattlerid)
                {
                    index = j;
                }
            }
        }
        for (int i = 0; i < playerList[index].classSkillList.Count; i++)
        {
            classSkillButton[i].GetComponent<SkillButton>().setSkillButton(playerList[index].classSkillList[i]);
        }
    }

    public TextAsset jsonPlayerFile;

    void LoadJsonPlayerData()
    {
        PlayersData playerDataInJson = JsonUtility.FromJson<PlayersData>(jsonPlayerFile.text);

        foreach (PlayerData playerData in playerDataInJson.playerData)
        {
            Debug.Log("ID " + playerData.id + "HP " + playerData.maxhp);
            playerDataList.Add(playerData);
        }
    }

    public TextAsset jsonSkillFile;

    public TextAsset jsonEnemyFile;

    void LoadJsonEnemyData()
    {
        EnemiesData enemyDataInJson = JsonUtility.FromJson<EnemiesData>(jsonEnemyFile.text);

        foreach (EnemyData enemyData in enemyDataInJson.enemyData)
        {
            Debug.Log("ID " + enemyData.id + "HP " + enemyData.maxhp);
            enemyDataList.Add(enemyData);
        }
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void onCharacterSkillClick()
    {
        battleState = "SelectCharacterSkill";
        setupCharacterSkillUI();
        characterSkillPanel.SetActive(true);
    }

    public void onCloseCharacterSkill()
    {
        characterSkillPanel.SetActive(false);
    }

    public void onClassSkillClick()
    {
        battleState = "PlayerSelectClassSkill";
        setupClassSkillUI();
        classSkillPanel.SetActive(true);
    }

    public void onCloseClassSkill()
    {
        classSkillPanel.SetActive(false);
    }

    public void PlayerSelectTarget(EnemyBattler enemyBattler)
    {
        battlerList[currentTurnUnitid].Attack(currentSkill, battlerList[currentTurnUnitid], enemyBattler);
        battleState = "PlayerSelectTarget";
        invisibleFrame.SetActive(true);
    }

    public void UpdateUI()
    {
        for(int i = 0; i < playerList.Count; i++)
        {
            playerHPtext[i].text = playerList[i].current_hp.ToString() + "/" + playerList[i].m_maxhp.ToString();
        }
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyHPtext[i].text = enemyList[i].current_hp.ToString() + "/" + enemyList[i].m_maxhp.ToString();
        }
    }

    #region PrototypeSetting
    public void PrototypeSetting()
    {
        for(int i = 0; i < prototypeSettingButton.Length; i++)
        {
            prototypeSettingButton[i].SetActive(true);
            prototypeSettingButton[i].SetActive(true);
        }
    }

    public void PrototypeSetupBattleScene()
    {
        setupBattleScene();
        prototypeSettingButton[0].GetComponent<Button>().interactable = false;
        prototypeSettingButton[1].GetComponent<Button>().interactable = true;
        for (int i = 0; i < prototypeSettingButton.Length; i++)
        {
            prototypeSettingButton[i].SetActive(false);
            prototypeSettingButton[i].SetActive(false);
        }
    }
    public void PrototypeResetBattleScene()
    {
        resetBattleScene();
        prototypeSettingButton[0].GetComponent<Button>().interactable = true;
        prototypeSettingButton[1].GetComponent<Button>().interactable = false;
        for (int i = 0; i < prototypeSettingButton.Length; i++)
        {
            prototypeSettingButton[i].SetActive(false);
            prototypeSettingButton[i].SetActive(false);
        }
    }
    #endregion
}

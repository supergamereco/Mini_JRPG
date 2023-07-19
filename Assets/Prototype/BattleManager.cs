using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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
    public List<Battler> battlerListTemp = new List<Battler>();
    public List<Battler> battlerListOnSpeed = new List<Battler>();
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
    public List<Skill> playerSkillList;
    public Skill currentSkill;
    private int currentTurnUnitid;
    private int currentTurnBattlerid;
    private int _unitid = 0;
    public string side;
    private int targetID;

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

        UpdateUI();
        TurnSequence();
    }

    public void resetBattleScene()
    {
        _unitid = 0;
        playerDataList.Clear();
        enemyDataList.Clear();
        playerList.Clear();
        enemyList.Clear();
        battlerList.Clear();
        battlerListTemp.Clear();
        battlerListOnSpeed.Clear();
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
        int unit_id = 0;
        Debug.Log("step1");
        for (int i = 0; i < playerList.Count; i++)
        {
            battlerList.Add(playerList[i]);
            battlerListTemp.Add(playerList[i]);
        }
        Debug.Log("step2");
        for (int i = 0; i < enemyList.Count; i++)
        {
            battlerList.Add(enemyList[i]);
            battlerListTemp.Add(enemyList[i]);
        }
        Debug.Log("step3");
        for (int i = 0; i < battlerList.Count; i++)
        {
            float mostSpeed = 0;
            for (int j = 0; j < battlerListTemp.Count; j++)
            {
                float speedTemp = battlerListTemp[j].current_speed;
                if(mostSpeed == speedTemp)
                {
                    float number = Random.Range(0, 2);
                    if (number >= 1)
                    {
                        speedTemp = speedTemp + number;
                    }
                    else
                    {
                        speedTemp = speedTemp - number;
                    }
                }
                if (speedTemp > mostSpeed)
                {
                    mostSpeed = speedTemp;
                    unit_id = battlerListTemp[j].unitid;
                }
            }
            for (int j = 0; j < battlerListTemp.Count; j++)
            {
                if(battlerListTemp[j].unitid == unit_id)
                {
                    battlerListOnSpeed.Add(battlerListTemp[j]);
                    battlerListTemp.Remove(battlerListTemp[j]);
                }
            }

            Debug.Log(battlerListOnSpeed[i].name);
        }
        FindBattlerTurn();
    }
    public void FindBattlerTurn()
    {
        Debug.Log("Find Battler Turn");
        side = battlerListOnSpeed[0].battlerSide;
        currentTurnUnitid = battlerListOnSpeed[0].unitid;
        currentTurnBattlerid = battlerListOnSpeed[0].m_id;

        if (side == "player")
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
    }
    public void Action(Battler defender)
    {
        battlerListOnSpeed[0].Attack(currentSkill, battlerListOnSpeed[0], defender);
        UpdateUI();

        battlerListOnSpeed.Remove(battlerListOnSpeed[0]);
        if (battlerListOnSpeed.Count.Equals(0))
        {
            TurnSequence();
        }
        else
        {
            FindBattlerTurn();
        }
    }

    private void setupCharacterSkillUI()
    {
        //--------------------------Setup Skill UI-----------------------------
        int playerIndex = 0;
        for (int i = 0; i < battlerList.Count; i++)
        {
            for (int j = 0; j < playerList.Count; j++)
            {
                if (battlerList[i].m_id == playerList[j].m_id && battlerList[i].battlerSide == playerList[j].battlerSide
                    && playerList[j].m_id == currentTurnBattlerid)
                {
                    playerIndex = j;
                }
            }
        }
        int skillIndex = 0;
        for (int i = 0; i < playerList[playerIndex].battlerSkillList.Count; i++)
        {
            characterSkillButton[i].GetComponent<SkillButton>().setSkillButton(playerList[playerIndex].battlerSkillList[i], i);
            characterSkillButton[i].GetComponent<SkillButton>().addListenner(skillIndex);
            skillIndex++;
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
        int skillIndex = 0;
        for (int i = 0; i < playerList[index].classSkillList.Count; i++)
        {
            classSkillButton[i].GetComponent<SkillButton>().setSkillButton(playerList[index].classSkillList[i], skillIndex);
            skillIndex++;
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

    public void ClickOnTarget()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            if (battleState == "playerSelectTarget")
            {
                if (hit.transform.tag == "EnemyBattler")
                {
                    targetID = hit.transform.GetComponent<EnemyBattler>().m_id;
                    Action(hit.transform.GetComponent<EnemyBattler>());
                    Debug.Log("Raycast Hit!! magPower" + hit.transform.GetComponent<EnemyBattler>().current_magPower);
                }
            }
        }
    }

    public void onSkillSelected(int index)
    {
        currentSkill = playerSkillList[index];
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

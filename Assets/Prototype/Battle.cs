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
    public List<EnemyBattler> enemyList = new List<EnemyBattler>();
    public TextMeshProUGUI[] playerHPtext;
    public TextMeshProUGUI[] enemyHPtext;
    public GameObject PlayerZone;
    public GameObject playerPrafab;
    public GameObject enemyPrafab;
    public Button[] skillButton;
    public string battleState;
    public int currentSkill_id;

    public void setBattleScene()
    {
        LoadJsonPlayerData();
        //Utils.BalancePrefabs(playerPrafab, players.Count, battleGround.transform);
        Utils.BalancePrefabs(playerPrafab, playerList.Count, PlayerZone.transform);
        for (int i = 0; i < playerList.Count; i++)
        {
            PlayerBattler player = PlayerZone.transform.GetChild(i).GetComponent<PlayerBattler>();
            player.setupPlayer(playerList[i]);
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
    }

    // Update is called once per frame
    void Update()
    {
        if(battleState == "PlayerSelectTarget")
        {

        }
    }

    public void setStatePlayerSelectTarget(int skill_id)
    {
        battleState = "PlayerSelectTarget";
        currentSkill_id = skill_id;
    }
}

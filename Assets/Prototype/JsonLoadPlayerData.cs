using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoadPlayerData : MonoBehaviour
{
    public static JsonLoadPlayerData Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public TextAsset jsonPlayerFile;

    void Start()
    {
        PlayersData playerDataInJson = JsonUtility.FromJson<PlayersData>(jsonPlayerFile.text);

        foreach (PlayerData playerData in playerDataInJson.playerData)
        {
            Debug.Log("ID: " + playerData.id + "Level" + playerData.level + "MaxHp" + playerData.maxhp);
        }
    }
}

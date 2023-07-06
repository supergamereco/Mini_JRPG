using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static void BalancePrefabs(GameObject prefab, int amount, Transform parent)
    {
        for (int i = parent.childCount; i < amount; ++i)
        {
            GameObject go = GameObject.Instantiate(prefab);
            go.transform.SetParent(parent, false);
        }

        for (int i = parent.childCount - 1; i >= amount; --i)
            GameObject.Destroy(parent.GetChild(i).gameObject);
    }
}

public class JSONPlayerDataReader : MonoBehaviour
{
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

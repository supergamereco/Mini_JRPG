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
    public static void BalanceBattlerPrefabs(GameObject prefab, Transform parent)
    {
        GameObject go = GameObject.Instantiate(prefab);
        go.transform.SetParent(parent, false);
    }
}

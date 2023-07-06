using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParents : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        GameObject go = GameObject.Instantiate(prefab);
        go.transform.SetParent(this.transform, false);
        go.SetActive(true);
    }
}

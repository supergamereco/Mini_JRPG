using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BattleSceneMouseInput : MonoBehaviour
{
    public event Action ClickedOnEnemy;

    public void OnAction(InputValue input)
    {
        ClickedOnEnemy?.Invoke();
    }
}

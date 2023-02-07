using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : CustomBehaviour
{
     public Action OnGameStart;
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        GameStarted();
    }
    public void GameStarted()
    {
        OnGameStart?.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isGameStarted;
    
    
    private int _playerCoinAmount;
    public int PlayerCoinAmount
    {
        get { return _playerCoinAmount; }
        set { _playerCoinAmount = value; }
    }

    private void Start()
    {
        //GameStarter();   // temporary this will connect to button
    }

    public void GameStarter()
    {
        EventManager.OnGameStart.Invoke();
        isGameStarted = true;
    }

    public void GameFinisher()
    {
        EventManager.OnGameEnd.Invoke();  //here may change with level finish because of finishing situations
        isGameStarted = false;
    }
}

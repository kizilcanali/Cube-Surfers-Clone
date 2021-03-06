﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isGameStarted;
    public bool isLevelFailed = false;
    public bool isFinishLinePassed = false;
    public bool isLevelSuccess = false;
    public int bonusAmount;
    
    private int _playerCoinAmount;
    public int PlayerCoinAmount
    {
        get { return _playerCoinAmount; }
        set { _playerCoinAmount = value; }
    }

    private void Update()
    {
       FailFinish();
       SuccessFinish();
    }

    public void GameStarter()
    {
        //EventManager.OnGameStart.Invoke();
        isGameStarted = true;
    }

    public void GameFinisher()
    {
        EventManager.OnGameEnd.Invoke(); 
        isGameStarted = false;
    }

    public void FailFinish()
    {
        if (CubeManager.Instance.cubes.Count == 0 && GameManager.Instance.isFinishLinePassed == false)
        {
            EventManager.OnLevelFail.Invoke();
            isLevelFailed = true;
        }
    }

    public void SuccessFinish()
    {
        if (CubeManager.Instance.cubes.Count == 0 && GameManager.Instance.isFinishLinePassed == true)
        {
            EventManager.OnLevelSuccess.Invoke();
        }
    }
}

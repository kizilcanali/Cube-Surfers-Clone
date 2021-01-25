﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuccessPanel : Panel
{
    public TextMeshProUGUI bonusCointText;
    public TextMeshProUGUI earnedCoins;
    
    private Animator _animator;
    public Animator Animator
    {
        get { return (_animator == null) ? _animator = GetComponentInChildren<Animator>() : _animator; }
    }
    
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelSuccess.AddListener(() =>
        {
            ShowPanel();
            InvokeTrigger("SuccessText");
            
        });
        EventManager.OnGameStart.AddListener(HidePanel);
        EventManager.OnLevelSuccess.AddListener(TextSetter);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelSuccess.RemoveListener(ShowPanel);
        EventManager.OnGameStart.RemoveListener(HidePanel);
        EventManager.OnLevelSuccess.RemoveListener(TextSetter);
    }

    void InvokeTrigger(string triggerName)
    {
        Animator.SetTrigger(triggerName);
    }
    

    void TextSetter()
    {
        bonusCointText.text = "Great!" + " " + GameManager.Instance.bonusAmount.ToString() + "X" ;
        earnedCoins.text = GameManager.Instance.PlayerCoinAmount.ToString();
    }
    
    
}

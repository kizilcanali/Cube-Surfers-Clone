using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuccessPanel : Panel
{
    public TextMeshProUGUI bonusCointText;
    
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
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelSuccess.RemoveListener(ShowPanel);
        EventManager.OnGameStart.RemoveListener(HidePanel);
    }

    void InvokeTrigger(string triggerName)
    {
        Animator.SetTrigger(triggerName);
    }

    void TextSetter()
    {
        //bonusCointText.text = "Great! {0}" + GameManager.Instance.bonusAmount + "X";
    }
    
    
}

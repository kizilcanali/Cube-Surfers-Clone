using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPanel : Panel
{
    private Animator _animator;
    public Animator Animator
    {
        get { return (_animator == null) ? _animator = GetComponentInChildren<Animator>() : _animator; }
    }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelFail.AddListener(() =>
            {
                ShowPanel();
                InvokeTrigger("FailText");
            }
        ); 
        EventManager.OnGameStart.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelFail.AddListener(() =>
            {
                ShowPanel();
                InvokeTrigger("FailText");
            }
        ); 
        EventManager.OnGameStart.RemoveListener(HidePanel);
    }
    
    public void InvokeTrigger(string triggerName)
    {
        Animator.SetTrigger(triggerName);
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    public Animator Animator
    {
        get { return (_animator == null) ? _animator = GetComponent<Animator>() : _animator; }
    }

    private Player _player;
    public Player Player
    {
        get { return (_player == null) ? _player = GetComponent<Player>() : _player; }
    }

    private void OnEnable()
    {
        if(Managers.Instance == null)
            return;
        
        EventManager.OnCubeCrushed.AddListener(() => InvokeTrigger("Crash"));
        EventManager.OnLevelFail.AddListener(() => InvokeTrigger("Finish")); //fail anim

    }

    private void OnDisable()
    {
        if(Managers.Instance == null)
            return;
        
        EventManager.OnCubeCrushed.RemoveListener(() => InvokeTrigger("Crash"));
        EventManager.OnLevelFail.RemoveListener(() => InvokeTrigger("Finish")); //about fail
        
    }

    public void InvokeTrigger(string triggerName)
    {
        Animator.SetTrigger(triggerName);
    }



   
    
}

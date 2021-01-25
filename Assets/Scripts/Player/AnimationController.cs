using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

    private bool isCrashOn;
    private bool isCollectOn;
    
    private void OnEnable()
    {
        if(Managers.Instance == null)
            return;
        
        EventManager.OnCubeCrushed.AddListener(() =>
        {
            StartCoroutine(WaitForAnimations());
            
        });
        EventManager.OnLevelFail.AddListener(() => InvokeTrigger("Finish")); //fail anim
        EventManager.OnCubeCollected.AddListener(() =>
        {
            if (isCollectOn)
                return;
            isCollectOn = true;
            InvokeTrigger("Jump");
            isCollectOn = false;
        });
        
        EventManager.OnLevelSuccess.AddListener(() => InvokeTrigger("Win"));

    }

    private void OnDisable()
    {
        if(Managers.Instance == null)
            return;
        
        EventManager.OnCubeCrushed.RemoveListener(() =>
        {
            //if(GameManager.Instance.isLevelFailed == false)
            InvokeTrigger("Crash");
        });
        EventManager.OnLevelFail.RemoveListener(() => InvokeTrigger("Finish")); //about fail
        
        EventManager.OnCubeCollected.RemoveListener(() =>
        {
            if (isCollectOn)
                return;
            isCollectOn = true;
            InvokeTrigger("Jump");
            isCollectOn = false;
        });
        EventManager.OnLevelSuccess.RemoveListener(() => InvokeTrigger("Win"));
        
    }

    public void InvokeTrigger(string triggerName)
    {
        Animator.SetTrigger(triggerName);
    }

    public IEnumerator WaitForAnimations()
    {

        if (isCrashOn)
            yield break;

        isCrashOn = true;
        yield return new WaitForSeconds(0.4f);
        
        if(GameManager.Instance.isLevelFailed)
            yield break;
        
        InvokeTrigger("Crash");
        isCrashOn = false;
    }



   
    
}

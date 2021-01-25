using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameEnd = new UnityEvent();
    
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    
    public static UnityEvent OnLevelSuccess = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();
    
    public static UnityEvent OnCubeCollected = new UnityEvent();
    public static UnityEvent OnCubeCrushed = new UnityEvent();
    
    public static UnityEvent OnCoinCollected = new UnityEvent();
    
    public static UnityEvent OnSceneLoad = new UnityEvent();
    public static UnityEvent OnTapDown = new UnityEvent();
}

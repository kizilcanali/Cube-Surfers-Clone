﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPanel : Panel
{
    private void Awake()
    {
        ShowPanel();
    }

    private void OnEnable()
    {
        if(Managers.Instance == null)
            return;
        
        EventManager.OnLevelStart.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        if(Managers.Instance == null)
            return;
        
        EventManager.OnLevelStart.RemoveListener(HidePanel);
    }
}

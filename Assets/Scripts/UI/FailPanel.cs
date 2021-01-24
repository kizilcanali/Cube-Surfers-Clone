using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPanel : Panel
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelFail.AddListener(ShowPanel);
        EventManager.OnGameStart.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelFail.RemoveListener(ShowPanel);
        EventManager.OnGameStart.RemoveListener(HidePanel);
    }
}

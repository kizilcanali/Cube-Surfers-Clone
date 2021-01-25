using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class DiamondCollectable : MonoBehaviour, ICollectable
{

    //public Image image;
    
    public void Collect()
    {
        GameManager.Instance.PlayerCoinAmount += 1;
        EventManager.OnCoinCollected.Invoke();
        Destroy(gameObject);
    /*
        Vector3 screenPoint = image.transform.position;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPoint);
        transform.position = Vector3.MoveTowards(transform.position, worldPos, 2f);
    */  
       
    }

   
}

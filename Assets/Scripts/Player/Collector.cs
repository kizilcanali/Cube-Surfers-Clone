﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public BoxCollider _collider; //Collider of the collector

    private void OnTriggerEnter(Collider other)
    {
        var collectableCube = other.GetComponent<ICollectable>();

        if (collectableCube != null)
        {
            collectableCube.Collect();
            
            _collider.size = new Vector3(_collider.size.x, _collider.size.y + 2f, _collider.size.z); // Increase the size of y value of the collector's collider.
        }
        
        if (other.gameObject.tag == "FinishLine")
        {
            GameManager.Instance.isFinishLinePassed = true;
            //Debug.Log("Im here");
        }
        
    }
}

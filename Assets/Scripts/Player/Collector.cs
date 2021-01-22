using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public BoxCollider _collider; //Collider of the collector

    private void OnTriggerEnter(Collider other)
    {
        var collectableCube = other.GetComponent<ICollectable>();

        if (collectableCube == null)
            return;
        
        collectableCube.Collect();
        
        EventManager.OnCubeCollected.Invoke();
        
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 5f, transform.localScale.z); //Increase the size of collector object
        _collider.size = new Vector3(_collider.size.x, _collider.size.y * 2f, _collider.size.z); // Increase the size of y value of the collector's collider.
        
        
    }
}

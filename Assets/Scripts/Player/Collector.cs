using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public BoxCollider _collider;

    private void OnTriggerEnter(Collider other)
    {
        var collectableCube = other.GetComponent<ICollectable>();

        if (collectableCube == null)
            return;
        
        collectableCube.Collect();
        transform.parent.position += Vector3.up * 0.55f;
        //CollectableCubeBase.Instance.cubes.Add(other.gameObject);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 5f, transform.localScale.z);
        _collider.size = new Vector3(_collider.size.x, _collider.size.y * 2f, _collider.size.z);
    }
}

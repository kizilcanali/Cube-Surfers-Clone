using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushableCube : MonoBehaviour, ICrushable
{
    private Rigidbody _rigidbody;
    public void Crush(GameObject gameObjectToDetachFromParent)
    {
        gameObjectToDetachFromParent.transform.parent = null;
        _rigidbody = gameObjectToDetachFromParent.GetComponent<Rigidbody>();
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        CollectableCubeBase.Instance.cubes.Remove(gameObjectToDetachFromParent);
        //then will make DESTROY
    }
}

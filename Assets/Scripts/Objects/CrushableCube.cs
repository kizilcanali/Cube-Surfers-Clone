using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CrushableCube : MonoBehaviour, ICrushable
{
    
    public void Crush(GameObject gameObjectToDetachFromParent)
    {
        gameObjectToDetachFromParent.transform.parent = null;
        Rigidbody _rigidbody = gameObjectToDetachFromParent.GetComponent<Rigidbody>();
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        gameObjectToDetachFromParent.GetComponent<BoxCollider>().isTrigger = false;
        CubeManager.Instance.cubes.Remove(gameObjectToDetachFromParent);
        
        EventManager.OnCubeCrushed.Invoke();
        
    }

    public void CrashForBonus(){}
}

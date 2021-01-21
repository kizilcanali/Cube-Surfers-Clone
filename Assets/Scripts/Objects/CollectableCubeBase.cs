using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCubeBase : Singleton<CollectableCubeBase>
{
    public List<GameObject> cubes;
    
    public GameObject GetLastElement()
    {
        if (cubes == null)
            return null;
        
        return cubes[cubes.Count - 1];
        
    }
}

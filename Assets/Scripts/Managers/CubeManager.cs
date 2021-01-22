using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : Singleton<CubeManager>
{
    public List<GameObject> cubes;
    public float hightOfCube = 0.5f;
    
    public GameObject GetLastElement()
    {
        if (cubes == null)
            return null;
        
        return cubes[cubes.Count - 1];
    }
}

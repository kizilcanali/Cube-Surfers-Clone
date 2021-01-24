using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnCubeCollected.AddListener(PlayerPositionCollectedOrganiser);
        EventManager.OnCubeCrushed.AddListener(() => StartCoroutine(WaitTillDropCubes()));
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnCubeCollected.RemoveListener(PlayerPositionCollectedOrganiser);
        EventManager.OnCubeCrushed.RemoveListener(() => StartCoroutine(WaitTillDropCubes()));
    }

    public bool isDeath; //check for the death state
    public bool isControllable;  //will use for the control character

    void PlayerPositionCollectedOrganiser()
    {
        transform.position = new Vector3(transform.position.x,  CubeManager.Instance.hightOfCube * CubeManager.Instance.cubes.Count -0.2f, transform.position.z);
    }

    public IEnumerator WaitTillDropCubes()
    {
        yield return new WaitForSeconds(0.5f);
        
        transform.DOMoveY(CubeManager.Instance.hightOfCube * CubeManager.Instance.cubes.Count, 0.5f);

    }
    
    
    
    
    
}

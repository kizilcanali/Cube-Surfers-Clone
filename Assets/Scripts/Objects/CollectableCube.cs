using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class CollectableCube : MonoBehaviour, ICollectable
{
  
  private Transform _characterTransform;
  private Rigidbody _rigidbody;

  private void OnEnable()
  {
    if (Managers.Instance == null)
      return;
    
    EventManager.OnCubeCollected.AddListener(CollectedCubePositionOrganiser);
    EventManager.OnCubeCrushed.AddListener(() => StartCoroutine(WaitTillDropCubes()));
    
  }
  private void OnDisable()
  {
    if (Managers.Instance == null)
      return;
    
    EventManager.OnCubeCollected.RemoveListener(CollectedCubePositionOrganiser);
    EventManager.OnCubeCrushed.RemoveListener(() => StartCoroutine(WaitTillDropCubes()));
    
  }

  private void Awake()
  {
    _characterTransform = GameObject.Find("Character").transform;
  }

  public void Collect()
  {
    //Vector3 lastObject = CubeManager.Instance.GetLastElement().transform.position;
    
    CubeManager.Instance.cubes.Insert(0, gameObject); //add to list's first position
    transform.position = new Vector3(_characterTransform.position.x, 0f, _characterTransform.position.z);
    gameObject.transform.parent = _characterTransform;
  }

  void CollectedCubePositionOrganiser()
  {
    if (!CubeManager.Instance.cubes.Contains(gameObject))
      return;
    
    transform.position = new Vector3(transform.position.x, CubeManager.Instance.hightOfCube * CubeManager.Instance.cubes.IndexOf(gameObject), transform.position.z);
  }

  private void OnTriggerEnter(Collider other)
  {
    var crushableCube = other.GetComponent<ICrushable>();
    if (crushableCube == null)
      return;
    
    crushableCube.Crush(gameObject);
    crushableCube.CrashForBonus();
    
  }
  
  public IEnumerator WaitTillDropCubes()
  {
    yield return new WaitForSeconds(0.5f);
    
    if (!CubeManager.Instance.cubes.Contains(gameObject))
      yield break;

    transform.DOMoveY(CubeManager.Instance.hightOfCube * CubeManager.Instance.cubes.IndexOf(gameObject), 0.5f);

  } 
}

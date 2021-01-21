using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CollectableCube : MonoBehaviour, ICollectable
{

  public GameObject collectableObject;
  public GameObject parentGameObject; //this will reorganise with singleton managers
  private Player _player;

  private void Awake()
  {
    _player = FindObjectOfType<Player>().GetComponent<Player>();
  }

  public void Collect()
  {
    GameObject temp;
    Vector3 lastObject = CollectableCubeBase.Instance.GetLastElement().transform.position;
    temp = Instantiate(collectableObject, CollectableCubeBase.Instance.GetLastElement().transform.position + Vector3.down * 0.5f, Quaternion.identity);
    CollectableCubeBase.Instance.cubes.Add(temp);
    temp.transform.parent = _player.transform;
    Destroy(this.gameObject);
    
  }
  
}

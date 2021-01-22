using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class CollectableCube : MonoBehaviour, ICollectable
{

  public GameObject collectableObject;
  public GameObject parentGameObject; //this will reorganise with singleton managers
  private Player _player;
  private Rigidbody _rigidbody;
  
  private void Awake()
  {
    _player = FindObjectOfType<Player>().GetComponent<Player>();
  }

  public void Collect()
  {
    //GameObject temp;
    _rigidbody = GetComponent<Rigidbody>();
    Vector3 lastObject = CollectableCubeBase.Instance.GetLastElement().transform.position;
        
    gameObject.transform.position =
      CollectableCubeBase.Instance.GetLastElement().transform.position + Vector3.down * 0.5f;
    gameObject.transform.parent = _player.transform;
    _rigidbody.isKinematic = true;  // düzgün çalışması için.
    CollectableCubeBase.Instance.cubes.Add(gameObject);
    
    
    /*temp = Instantiate(collectableObject, CollectableCubeBase.Instance.GetLastElement().transform.position + Vector3.down * 0.5f, Quaternion.identity);
    CollectableCubeBase.Instance.cubes.Add(temp);
    temp.transform.parent = _player.transform;*/
    //Destroy(this.gameObject);
  }

  private void OnTriggerEnter(Collider other)
  {
    var crushableCube = other.GetComponent<ICrushable>();
    if (crushableCube == null)
      return;
    
    crushableCube.Crush(this.gameObject);
  }
}

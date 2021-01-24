using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
  private Slider _slider;
  
  public Transform _playerPosition;
  
  public Transform _startPosition;
  public Transform _finishPosition;
  
  private float _distanceCalcution;  //İÇİNDE FİNİSH POSLAR VAR
  private float _maxDistance;
  
  private void Awake()
  {
    _slider = gameObject.GetComponent<Slider>();
    _maxDistance = Mathf.Abs(_finishPosition.position.z - _startPosition.position.z);
  }

  private void Update()
  {
    Progression();
  }

  void Progression()
  {
    
    CalculateDistance();
    _slider.value = _distanceCalcution;
    
  }

  void CalculateDistance()
  {
    _distanceCalcution = (_playerPosition.position.z / _maxDistance);
    
  }
  
}

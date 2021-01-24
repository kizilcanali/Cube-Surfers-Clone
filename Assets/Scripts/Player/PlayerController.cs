﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Joystick _joystick;
    public Joystick Joystick
    {
        get
        {
            return (_joystick == null)
                ? _joystick = GameObject.FindWithTag("Joystick").GetComponent<Joystick>()
                : _joystick;
        }
    }
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _horizontalSpeed;

    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody
    {
        get { return (_rigidbody == null) ? _rigidbody = GetComponent<Rigidbody>() : _rigidbody; }
    }
    
    public bool isControllable;
    
    private void Start()
    {
        //EventManager.OnLevelStart.Invoke();  //düzenlenecek şimdilik böyle.
    }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelStart.AddListener(() => isControllable = true);
        EventManager.OnLevelFinish.AddListener(() => isControllable = false);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelStart.RemoveListener(() => isControllable = true);
        EventManager.OnLevelFinish.RemoveListener(() => isControllable = false);
        
    }
    

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (isControllable == false)
            return;
        
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * Joystick.Horizontal * _horizontalSpeed * Time.deltaTime);
        
       if (transform.position.x <= -3.5f)
           transform.position = new Vector3(-3.5f, transform.position.y, transform.position.z);
        
       if(transform.position.x >= 3.5f)
           transform.position = new Vector3(3.5f, transform.position.y, transform.position.z);
        
    }
}

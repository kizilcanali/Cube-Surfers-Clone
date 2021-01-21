using System;
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
    private bool _isRunning;
    public bool IsRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    private void Start()
    {
        EventManager.OnLevelStart.Invoke();
    }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelStart.AddListener(() => IsRunning = true);
        EventManager.OnLevelFinish.AddListener(() => IsRunning = false);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelStart.RemoveListener(() => IsRunning = true);
        EventManager.OnLevelFinish.RemoveListener(() => IsRunning = false);
    }
    

    private void Update()
    {
        //if (IsRunning)
           // return;
        Move();
    }

    public void Move()
    {
       
       Rigidbody.velocity = new Vector3(Joystick.Horizontal * _horizontalSpeed, 0, _moveSpeed);
       
       if (transform.position.x <= -3.5f)
           transform.position = new Vector3(-3.5f, transform.position.y, transform.position.z);
        
       if(transform.position.x >= 3.5f)
           transform.position = new Vector3(3.5f, transform.position.y, transform.position.z);
        
    }
}

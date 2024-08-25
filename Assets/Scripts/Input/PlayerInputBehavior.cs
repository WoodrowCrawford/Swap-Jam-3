using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputBehavior : MonoBehaviour
{
  


    [SerializeField] private float _speed;
    private Vector2 _movementInput;


    [SerializeField] private Rigidbody2D _rb;

   

    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        _rb.velocity = _movementInput * _speed;
    }
  
    private void OnMovement(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}

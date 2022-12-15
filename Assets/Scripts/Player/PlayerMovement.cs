using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform crossHair;

    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 _movement;
    private Vector2 _mousePos;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GetComponent<PlayerHealth>().isAlive == false) return;
        ReadInputs();
        SetMoveAnimation();
        SetCrossHairPosition();
        MovePlayer();
    }

    private void ReadInputs()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void SetMoveAnimation()
    {
        _animator.SetBool("IsWalking", /*Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1 || */  Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1);
    }

    private void SetCrossHairPosition()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crossHair.transform.position = _mousePos;
    }

    private void FixedUpdate()
    {
        SetRotation();
    }

    private void MovePlayer()
    {
        transform.position += (transform.forward * _movement.x + transform.right * _movement.y) * moveSpeed * Time.deltaTime;
    }

    private void SetRotation()
    {
        Vector2 lookdirection = _mousePos - _rb.position;
        float angle = Mathf.Atan2(lookdirection.y, lookdirection.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSpider : MonoBehaviour
{
    //Serialized variabless
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] bool canChase = false;
    [SerializeField] float tuneAngle = 90f;

    //Cached variables
    private PlayerMovement _player;
    private BoxCollider2D _playerDetection;
    private Rigidbody2D _rb;
    private Animator _animator;
    private Health _health;


    void Start()
    {
        _health = GetComponent<Health>();
        _player = FindObjectOfType<PlayerMovement>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _playerDetection = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (_health.isAlive == true) ChaseOrNot();
        if (canChase == true) ChasingPlayer();
    }

    private void ChaseOrNot()
    {
        if (_playerDetection.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            canChase = true;
        }
    }

    private void ChasingPlayer()
    {
        if (_player == null) return;

        Vector3 direction = SetDistanceToPlayer();
        SetSpiderRotation(direction);
        SetAnimation();
    }

    private Vector3 SetDistanceToPlayer()
    {
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        _rb.velocity = direction * moveSpeed;
        return direction;
    }

    private void SetSpiderRotation(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + tuneAngle;
        _rb.rotation = angle;
    }

    private void SetAnimation()
    {
        if (Mathf.Abs(_rb.velocity.x) > 0 && GetComponent<SpiderBite>().biting == false)
        {
            SetChaseAnimation(true);
        }
        else if (Mathf.Abs(_rb.velocity.y) > 0 && GetComponent<SpiderBite>().biting == false)
        {
            SetChaseAnimation(true);
        }
        else
        {
            SetChaseAnimation(false);
        }
    }

    private void SetChaseAnimation(bool _canChase)
    {
        _animator.SetBool("IsWalking", canChase = _canChase);
    }

    public void SetMovementSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
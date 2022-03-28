using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWebShooting : MonoBehaviour
{
    [SerializeField] GameObject webPrefab;
    [SerializeField] Transform webShootPoint;
    [SerializeField] float webSpeed = 2f;
    [SerializeField] float tuneAngle = 180;

    public bool shootingWeb;

    private CircleCollider2D _shootRangeCollider;
    private PlayerMovement _player;
    private Rigidbody2D _rb;
    private Animator _animator;
    private Health _health;


    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _shootRangeCollider = GetComponent<CircleCollider2D>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (_health.isAlive == false || _player == null) return;

        RotateSpider();

        if (_shootRangeCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            ChangeAttackAnimation(true);
        }
        else
        {
            ChangeAttackAnimation(false);
        }
    }

    private void RotateSpider()
    {
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + tuneAngle;
        _rb.rotation = angle;
    }

    private void ChangeAttackAnimation(bool isAttacking)
    {
        _animator.SetBool("IsAttacking", shootingWeb = isAttacking);
    }

    public void ShootWeb()
    {
        GameObject web = Instantiate(webPrefab, webShootPoint.position, transform.rotation);
        var webRb = web.GetComponent<Rigidbody2D>();
        webRb.AddForce(web.transform.right * -1 * webSpeed, ForceMode2D.Impulse);
    }
}

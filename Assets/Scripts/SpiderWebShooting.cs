using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWebShooting : MonoBehaviour
{
    [SerializeField] GameObject webPrefab;
    [SerializeField] Transform webShootPoint;
    [SerializeField] float webSpeed = 2f;
    [SerializeField] float tuneAngle = 180;
    PlayerMovement player;
    Rigidbody2D rb;
    Animator animator;
    CircleCollider2D shootRangeCollider;
    public bool shootingWeb;
    float timeToShoot;
    float pistolFireRate = 0.3f;


    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        shootRangeCollider = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if (GetComponent<Health>().isAlive == false) return;
        if (player == null) return;
        Vector3 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + tuneAngle;
        rb.rotation = angle;
        if (shootRangeCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            animator.SetBool("IsAttacking", true);
            shootingWeb = true;
            timeToShoot = Time.time + pistolFireRate;
        }
        else
        {
            shootingWeb = false;
            animator.SetBool("IsAttacking", false);
        }
    }

    public void ShootWeb()
    {
        GameObject web = Instantiate(webPrefab, webShootPoint.position, transform.rotation);
        var webRb = web.GetComponent<Rigidbody2D>();
        webRb.AddForce(web.transform.right * -1 * webSpeed, ForceMode2D.Impulse);
        Debug.Log("I shot");
    }
}

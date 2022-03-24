using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSpider : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] bool canChase = false;
    [SerializeField] float tuneAngle = 90f;
    BoxCollider2D playerDetection;
    [SerializeField] PlayerMovement player;
    Rigidbody2D rb;
    Animator animator;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerDetection = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Health>().isAlive == false) return;
        ChaseOrNot();
        if (canChase == false) return;
        ChasingPlayer();
    }

    private void ChaseOrNot()
    {
        if (playerDetection.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            canChase = true;
        }
    }

    private void ChasingPlayer()
    {
        if (player == null) return;
        Vector3 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + tuneAngle;
        rb.rotation = angle;
        rb.velocity = direction * moveSpeed;
        if (Mathf.Abs(rb.velocity.x) > 0 && GetComponent<SpiderBite>().biting == false)
        {
            animator.SetBool("IsWalking", true);
            canChase = true;
        }
        else if (Mathf.Abs(rb.velocity.y) > 0 && GetComponent<SpiderBite>().biting == false)
        {
            animator.SetBool("IsWalking", true);
            canChase = true;
        }
        else
        {
            animator.SetBool("IsWalking", false);
            canChase = false;
        }
    }

    public void SetMovementSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
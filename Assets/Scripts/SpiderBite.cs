using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBite : MonoBehaviour
{
    [SerializeField] int biteDamage = 30;
    CapsuleCollider2D biteCollider;
    Animator animator;
    public bool biting = false;
    void Start()
    {
        biteCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(biteCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            animator.SetBool("IsAttacking",true);
            biting = true;
        }
        else
        {
            biting = false;
            animator.SetBool("IsAttacking", false);
        }
    }

    public void Bite()
    {
        var playerhealth = FindObjectOfType<PlayerHealth>();
        playerhealth.TakeDamage(biteDamage);

    }
}

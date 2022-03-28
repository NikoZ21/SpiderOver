using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBite : MonoBehaviour
{
    [SerializeField] int biteDamage = 30;

    public bool biting = false;

    private CapsuleCollider2D _biteCollider;
    private Animator _animator;
    private PlayerHealth _playerHealth;

    void Start()
    {
        _biteCollider = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        if (_biteCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            ChangeBiteAnimation(true);
        }
        else
        {
            ChangeBiteAnimation(false);
        }
    }

    private void ChangeBiteAnimation(bool isBiting)
    {
        _animator.SetBool("IsAttacking", biting = isBiting);
    }

    public void Bite()
    {
        _playerHealth.TakeDamage(biteDamage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 300;
    [SerializeField] float deathDelay = 1.5f;

    public bool isAlive = true;

    private Rigidbody2D _rigidBody;
    private CircleCollider2D _circleCollider2D;
    private CapsuleCollider2D _capsuleCollider2D;
    private int _currentHealth;


    private void Start()
    {
        _currentHealth = maxHealth;
    }

    void Die()
    {
        isAlive = false;
        DisplayingBlood();
        DisablingMovement();
        Destroy(gameObject, deathDelay);
    }

    void DisplayingBlood()
    {
        var bloodVFXS = GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < bloodVFXS.Length; i++)
        {
            bloodVFXS[i].Play();
        }
    }

    void DisablingMovement()
    {
        _rigidBody.bodyType = RigidbodyType2D.Static;
        _circleCollider2D.enabled = false;
        _capsuleCollider2D.enabled = false;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
}

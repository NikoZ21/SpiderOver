using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    //serialized variables
    [SerializeField] int maxHealth = 300;
    [SerializeField] float deathDelay = 1.5f;

    //public variables
    public bool isAlive = true;

    //private variables
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
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
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

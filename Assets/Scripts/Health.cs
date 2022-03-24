using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 300;
    [SerializeField] float deathDelay = 1.5f;
    [SerializeField] public bool isAlive = true;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
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
}

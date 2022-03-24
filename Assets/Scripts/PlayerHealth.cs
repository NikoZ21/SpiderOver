using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float deathDelay = 1.5f;
    [SerializeField] Image image;
    [SerializeField] Sprite[] hearts;
    [SerializeField] int maxHealth = 300;
    [SerializeField] HealthBar healthbar;
    [SerializeField] public bool isAlive = true;
    int currentHealth;
    Animator animator;
   

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        SwappingHeartImage();
        if (currentHealth < 0)
        {
            Die();
        }
    }

    private void SwappingHeartImage()
    {
        int index = (currentHealth / 100);
        if (index < 0 || index > 2) return;
        image.sprite = hearts[index];
    }

    void Die()
    {
        isAlive = false;
        DisablingMovement();
        Invoke(nameof(PlayDeathAnim), 0.02f);
        Destroy(gameObject, deathDelay);
    }

    void DisablingMovement()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void PlayDeathAnim()
    {
        animator.SetTrigger("Die");
    }
}

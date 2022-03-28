using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Sprite[] hearts;
    [SerializeField] HealthBar healthbar;
    [SerializeField] int maxHealth = 300;
    [SerializeField] public bool isAlive = true;
    [SerializeField] float deathDelay = 1.5f;

    private Animator _animator;
    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider2D;
    private int _currentHealth;


    private void Start()
    {
        _currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        healthbar.SetHealth(_currentHealth);
        SwappingHeartImage();
        if (_currentHealth < 0)
        {
            Die();
        }
    }

    private void SwappingHeartImage()
    {
        int index = (_currentHealth / 100);
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
        _rb.bodyType = RigidbodyType2D.Static;
        _boxCollider2D.enabled = false;
    }

    void PlayDeathAnim()
    {
        _animator.SetTrigger("Die");
    }
}

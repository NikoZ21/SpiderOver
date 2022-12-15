using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{

    [SerializeField] GameObject hitEffect;
    [SerializeField] int damage = 50;
    [SerializeField] float bulletLifeTime = 5f;
    [SerializeField] float hitEffectLifeTime = 1f;

    private void OnCollisionEnter2D(Collision2D collision) => ProccessHit(collision);

    private void ProccessHit(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerHealth>();
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        if (player)
        {
            player.TakeDamage(damage);
        }
        Destroy(effect, hitEffectLifeTime);
        Destroy(gameObject);
    }

    private void Update()
    {
        Destroy(gameObject, bulletLifeTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    private int damage;
    private float projectileSpeed = 5.0f;

    public void Setup(Transform target, int damage)
    {
        if (target == null) return;
        this.target = target;
        this.damage = damage;

        Vector2 direction = (target.position - transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        if (collision.transform != target)
        {
            return;
        }
        
        collision.GetComponent<PlayerHP>().TakeDamage(damage);
        Destroy(gameObject);
    }

    private void Update()
    {
        Player player = FindObjectOfType<Player>();

        if (player == null)
        {
            Destroy(gameObject);
        }
    }
}

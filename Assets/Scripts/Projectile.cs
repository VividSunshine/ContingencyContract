using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    private int damage;
    private float projectileSpeed = 5.0f;
    public float screenBoundaryX = 8f;
    public float screenBoundaryY = -5f;
    public Score score;

    public void Setup(Transform target, int damage)
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
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

        //총알이 화면 밖에 벗어나면
        if(transform.position.x > screenBoundaryX || transform.position.x < -(screenBoundaryX) || transform.position.y < screenBoundaryY)
        {
            score.AddScore(1);
            Destroy(gameObject);
        }
    }
}

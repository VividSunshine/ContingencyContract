using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum WeaponState { SearchTarget = 0, AttackToTarget }

public class TowerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float attackRate = 0.5f;
    [SerializeField]
    private int attackDamage = 1;
    private Vector2 attackTarget = Vector2.zero;

    private Player playerScript;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        StartCoroutine(AttackToTarget());
    }

    private void Update()
    {
        attackTarget = playerScript.GetSavedPosition();
        if (attackTarget != null)
        {
            RotateToTarget();
        }
    }

    private void RotateToTarget()
    {
        float dx = attackTarget.x - transform.position.x;
        float dy = attackTarget.y - transform.position.y;

        float degree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, degree);
    }

    private IEnumerator AttackToTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackRate);

            if(playerScript != null)
            {
                SpawnProjectile();
            }
        }
    }

    private void SpawnProjectile()
    {
        GameObject clone = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<Projectile>().Setup(playerScript.transform, attackDamage);
    }
}

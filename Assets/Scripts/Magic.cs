using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Magic : MonoBehaviour
{
    public float screenBoundaryY = 5f;
    public GameObject magicPrefab;
    public Tower tower;

    public float magicSpeed = 5.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Tower"))
        {
            return;
        }
        tower.TowerOnDie();

        Destroy(gameObject);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameObject magic = Instantiate(magicPrefab, transform.position, transform.rotation);

            Rigidbody2D rb = magic.GetComponent<Rigidbody2D>();

            rb.AddForce(transform.up * magicSpeed, ForceMode2D.Impulse);
        }
        if (transform.position.y > screenBoundaryY)
        {
            Destroy(gameObject);
        }
    }
}

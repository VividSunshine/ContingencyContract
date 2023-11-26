using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform canvasTransform;

    public float speed = 5f;
    public Vector2 savedPosition;

    private float minX, maxX;

    private void Start()
    {
        SaveInitialPosition();
        SetScreenLimits();
    }

    private void SetScreenLimits()
    {
        Camera mainCamera = Camera.main;

        float playerWidth = GetComponent<Renderer>().bounds.size.x / 2;
        minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + playerWidth;
        maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - playerWidth;

    }

    private void SaveInitialPosition()
    {
        savedPosition = transform.position;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        transform.Translate(movement * speed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    public Vector2 GetSavedPosition()
    {
        return savedPosition;
    }


    public void onDie()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject playerHPSlider;
    [SerializeField]
    private Transform canvasTransform;

    public float speed = 5f;
    public Transform savedPosition;

    private void Start()
    {
        savedPosition = transform;
        //SpawnPlayerHPSlider(gameObject);
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    public Transform GetSavedPosition()
    {
        return savedPosition;
    }

    public void onDie()
    {
        Destroy(gameObject);
    }

    /*private void SpawnPlayerHPSlider(GameObject player)
    {
        GameObject sliderClone = Instantiate(playerHPSliderPrefab);
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;

        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(player.transform);
        sliderClone.GetComponent<PlayerHPViewer>().Setup(player.GetComponent<PlayerHP>());
    }*/
}

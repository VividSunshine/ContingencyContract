using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    private PlayerHP playerHP;
    private Slider hpSlider;

    public void Setup(PlayerHP playerHP)
    {
        this.playerHP = playerHP;
        hpSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        if(playerHP != null && hpSlider != null)
        {
            hpSlider.value = playerHP.CurrentHP / playerHP.MaxHP;
        }
    }
}

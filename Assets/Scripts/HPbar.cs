using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public Slider HPSlider;
    public PlayerHP playerHP;

    public void Awake()
    {
        HPSlider = GetComponent<Slider>();

        if (HPSlider == null)
        {
            Debug.LogError("π∫∞°..π∫∞°πÆ¡¶¿”");
        }
    }

    public void SetHP(float HP)
    {
        if(HPSlider != null)
        {
            HPSlider.value = playerHP.CurrentHP / playerHP.MaxHP;
        }
    }
}

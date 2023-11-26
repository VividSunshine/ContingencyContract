using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillAreaSetActive : MonoBehaviour
{
    public PlayerHP playerHP;
    private void Update()
    {
        if ( playerHP.CurrentHP <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}

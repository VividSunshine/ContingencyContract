using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI text;
    int score = 0;

    private void Start()
    {
        text.text = "" + score;
    }

    public void AddScore(int num)
    {
        score += num;
        text.text = "" + score;
    }
}

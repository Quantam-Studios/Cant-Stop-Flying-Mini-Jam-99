using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public Text highScoreText;
    public static int highScore;

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "HIGH SCORE: " + highScore.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    public int score;
    public TMPro.TextMeshProUGUI scoreText;
    public void AddScore(Component component, object score)
    {
        this.score += (int)score;
        scoreText.text = this.score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
}

using UnityEngine;
using TMPro;
public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int score = 0;

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score:" + score;
    }
}

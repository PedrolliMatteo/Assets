using TMPro;
using UnityEngine;

//Ci assegno la gestione del gioco

public class GameManager : MonoBehaviour
{

    private int score;

    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        UpdateScoreText(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd) 
    {
        score += scoreToAdd;
        UpdateScoreText(score);
    }

    public void UpdateScoreText(int actualScore) 
    {
        scoreText.text = "Score: " + actualScore;
    }
}

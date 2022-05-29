using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater: MonoBehaviour
{
    int score = 0;
    int hitScore = 0;
    float timer = 60;
    [SerializeField] Text timerText;
    [SerializeField] Text scoreText;
    [SerializeField] Text hitScoreText;
  
       
    void Start() 
    {
       scoreText.text = score.ToString();
       hitScoreText.text = hitScore.ToString();
    }

    void Update()
    {           
       if(timer > 1)
       {
           timer -= Time.deltaTime;
           timerText.text = Mathf.FloorToInt(timer).ToString();
       }
       else
       {
           timer = 0;
       }
    }
      
    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void AddToHitScore(int hitPointsToAdd)
    {
        hitScore += hitPointsToAdd;
        hitScoreText.text = hitScore.ToString();
    }
}

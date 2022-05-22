using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    int score = 0;
    float timer = 60;
    [SerializeField] Text timerText;
    [SerializeField] Text scoreText;
   
    void Start() 
    {
       scoreText.text = score.ToString();
    }

    void Update()
    {           
        timer -= Time.deltaTime;
        timerText.text = Mathf.FloorToInt(timer).ToString();
    }
      
    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
        
}



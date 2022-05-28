using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSessions : MonoBehaviour
{
    int score = 0;
    float timer = 40;
    [SerializeField] Text timerText;
    [SerializeField] Text scoreText;
   
    void Awake()
    {
       int numGameSessions = FindObjectsOfType<GameSessions>().Length;
       if(numGameSessions > 1)
       {
           Destroy(gameObject);
       } 
       else 
       {
           DontDestroyOnLoad(gameObject);
       }
    }
    
    void Start() 
    {
       scoreText.text = score.ToString();
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
           SceneManager.LoadScene(4);
       }
    }
      
    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
        
}



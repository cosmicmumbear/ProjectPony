using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSessionNew : MonoBehaviour
{
     //[SerializeField] GameOverHandler gameOverHandler;   
     //float timer = 40;
        void Awake()
        {
        int numGameSessions = FindObjectsOfType<GameSessionNew>().Length;
        if(numGameSessions > 1)
            {
                Destroy(gameObject);
            } 
            else 
            {
                DontDestroyOnLoad(gameObject);
            }
        } 

        // void Update()
        // {           
        // if(timer > 1)
        //     {
        //         timer -= Time.deltaTime;
                
        //     }
        //     else
        //     {
        //         gameOverHandler.EndGame();
        //     }
        // } 
}



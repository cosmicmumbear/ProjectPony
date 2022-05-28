using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{

    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private GameObject notEnemySpawner;
    [SerializeField] private GameObject notEnemySpawnerGolden;
    [SerializeField] private GameObject player;

 
    public void EndGame()
    {
        gameOverDisplay.gameObject.SetActive(true);
        notEnemySpawner.gameObject.SetActive(false);
        notEnemySpawnerGolden.gameObject.SetActive(false);
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

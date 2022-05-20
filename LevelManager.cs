using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   [SerializeField] float sceneLoadDelay = 1.5f;
   //ScoreKeeper scoreKeeper;

//    void Awake() 
//    {
//        scoreKeeper = FindObjectOfType<ScoreKeeper>();
//    }
   public void LoadGame()
   {
       //scoreKeeper.ResetScore();
       SceneManager.LoadScene(1);
   }

    public void LoadMainMenu()
   {
       SceneManager.LoadScene(0);
   }

     public void LoadAbout()
   {
       SceneManager.LoadScene(3);
   }

    public void LoadGameOver()
   {
       StartCoroutine(WaitAndLoad(2, sceneLoadDelay));
   }

    public void QuitGame()
   {
       Debug.Log("Quit");
       Application.Quit();
   }

   IEnumerator WaitAndLoad(int sceneIndex, float delay) 
   {
       yield return new WaitForSeconds(delay);
       SceneManager.LoadScene(sceneIndex);
   }
}

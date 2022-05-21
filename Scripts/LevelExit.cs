using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
   [SerializeField] float levelLoadDelay =1f;
   [SerializeField] AudioClip levelExitSFX;
   [SerializeField] ParticleSystem levelExitEffect;

   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.tag == "Player")
       {
       StartCoroutine(LoadNextLevel());
       }
   }
   
   
   IEnumerator LoadNextLevel()
   {
       AudioSource.PlayClipAtPoint(levelExitSFX, Camera.main.transform.position);
       levelExitEffect.Play();
       
       yield return new WaitForSecondsRealtime(levelLoadDelay);
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       int nextSceneIndex = currentSceneIndex +1;

       if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
       {
          nextSceneIndex = 0; 
       }

       FindObjectOfType<ScenePersist>().ResetScenePersist();
       SceneManager.LoadScene(nextSceneIndex);
   }
       
     
}

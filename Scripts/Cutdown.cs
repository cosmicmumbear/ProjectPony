using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutdown : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] Text timerText;
    [SerializeField] AudioClip cutdownSFX;


 
    public void CutdownOn(float timer)
    {
        AudioSource.PlayClipAtPoint(cutdownSFX, Camera.main.transform.position);
        gameOverDisplay.gameObject.SetActive(true);
        timerText.text = Mathf.FloorToInt(timer).ToString();
             
    }
        public void CutdownOff()
    {
        gameOverDisplay.gameObject.SetActive(false);
             
    }
}

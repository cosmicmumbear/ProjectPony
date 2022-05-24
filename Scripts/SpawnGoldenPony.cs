using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoldenPony : MonoBehaviour
{
[SerializeField] float respawnTime = 2f;
[SerializeField] int changeToZombieScoreValue = 400;

        private void OnTriggerEnter(Collider other) 
        {
            if (other.tag == "Player")
            {
                Pickup(gameObject);
            }
        }

        private void Pickup(GameObject subject)
        {
            FindObjectOfType<GameSessions>().AddToScore(changeToZombieScoreValue);
            StartCoroutine(HideForSeconds(respawnTime));
        }

        private IEnumerator HideForSeconds(float seconds)
        {
            ShowPickup(false);
            yield return new WaitForSeconds(seconds);
            ShowPickup(true);
        }

        private void ShowPickup(bool shouldShow)
        {
            GetComponent<Collider>().enabled = shouldShow;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(shouldShow);
            }
        }
}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour {

    float delay = 0.5f;
	// AudioSource coinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ScoreText.coinAmount += 1;
         //   coinSound.Play();
            Destroy(gameObject, delay);
                      
            
            if (ScoreText.coinAmount == 21) {		
			SceneManager.LoadScene ("Ending");
			}
				
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour {

    public float pMaxHealth = 100;
    public GameObject pDeathParticleEmitter;
    public Image lifeBar;
	
	public void AddHealth(float x)
    {
        pMaxHealth += x;
        lifeBar.fillAmount = pMaxHealth;
    }

    public void DeductHealth(float x)
    {
        Debug.Log("HPssss");
        pMaxHealth -= x;
        lifeBar.fillAmount = pMaxHealth;
        Debug.Log("HP");

    }
  /*  public void Die()
    {
        Debug.Log("DIE");
        Instantiate(pDeathParticleEmitter, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDestroyed : MonoBehaviour {

    public GameObject pExplosionPrefab;

    void OnCollisionEnter2D(Collision2D otherObjectCollider)
    {
        if (otherObjectCollider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
			EliminationText.eliminationAmount += 1;
            Destroy(otherObjectCollider.gameObject);
            Instantiate(pExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D (Collision2D otherObjectCollider)
    {

        if (otherObjectCollider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            otherObjectCollider.gameObject.GetComponent<Penguin>().TakeDamage(20);
        }

    }

}

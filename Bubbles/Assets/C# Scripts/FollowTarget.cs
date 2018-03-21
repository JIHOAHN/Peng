using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    [SerializeField]
    Transform pTarget;
    [SerializeField]
    float pFollowSpeed;
    [SerializeField]
    float pFollowRange;

    float pArriveThreshold = 0.05f;

	// Update is called once per frame
	void Update () {
		
        if (pTarget != null)
        {
            float distance = Vector2.Distance(transform.position, pTarget.position);

            if (distance < pFollowRange)
            {
                Vector3 directionToGo = pTarget.position - transform.position;
                directionToGo.Normalize();

                transform.position += directionToGo * Time.deltaTime * pFollowSpeed;
            }
        }
	}

    public void SetTarget(Transform target)
    {
        pTarget = target;
    }
}

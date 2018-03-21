using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PengGun : MonoBehaviour {

	int speed = 20;
	public Rigidbody2D bullet;
	public Transform PPoint;
	AudioSource Shoot;
	public float bulletSpeed = 15;


	// Use this for initialization
	void Start () 
	{
		Shoot = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			bullet = Instantiate (bullet, PPoint.position, PPoint.rotation) as Rigidbody2D;
			bullet.velocity = transform.TransformDirection (Vector3.right * bulletSpeed);
			//BusterShoot.Play ();
		}
	}
}

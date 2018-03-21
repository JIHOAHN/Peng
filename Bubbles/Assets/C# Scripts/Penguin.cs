using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Penguin : MonoBehaviour
{

    // Use this for initialization
    public float WalkSpeed = 3;
    public float RunSpeed = 6;
    public Image healthImage;
    public float Health = 1;
    public bool running;
    Life life;

    [SerializeField]
    GameObject pDeathParticleEmitter;

	float pDamagePushForce = 2.5f;

    Animator Animator;
    Rigidbody2D Rigidbody2D;
	bool pInvincible;
    Vector2 pFacingDirection;

	bool movingLeft;
	bool movingRight;
	bool movingUp;
	bool movingDown;

    AudioSource pTakeDamageSound;

    void Start()
    {
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        pTakeDamageSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
		Animator.SetBool("left", movingLeft);
		Animator.SetBool("right", movingRight);
		Animator.SetBool("up", movingUp);
		Animator.SetBool("down", movingDown);
    }

    private void MoveCharacter()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * WalkSpeed;

		float moveSpeed =  WalkSpeed;

		if (Input.GetButtonDown("Left"))
		{
			// Translate the game object
			transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
			FaceDirection(-Vector2.right);
			movingLeft = true;
		}
		if (Input.GetButtonDown("Right"))
		{
			// Translate the game object
			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
			FaceDirection(Vector2.right);
			movingRight = true;
		}
		if (Input.GetButtonDown("Up"))
		{
			transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
			FaceDirection(Vector2.up);
			movingUp = true;
		}
		if (Input.GetButtonDown("Down"))
		{
			transform.Translate(-Vector2.up * moveSpeed * Time.deltaTime);
			FaceDirection(-Vector2.up);
			movingDown = true;
		}

        if (Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
            WalkSpeed = 6;
        }
    }

    private void FaceDirection (Vector2 direction)
    {
        pFacingDirection = direction;
        if (direction == Vector2.zero)
            return;

        Quaternion rotation3D = direction == Vector2.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back);
        transform.rotation = rotation3D;
    }

    public void Die()
    {
        Instantiate(pDeathParticleEmitter, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Ending");
        Destroy(gameObject);
    }
    public void TakeDamage(int dmg)
    {
        Vector2 forceDirection = new Vector2(-pFacingDirection.x, 1.0f) * pDamagePushForce;
        Rigidbody2D.velocity = Vector2.zero;
        Rigidbody2D.AddForce(forceDirection, ForceMode2D.Impulse);
		Health -= (float)dmg;
		healthImage.fillAmount = Health;
        pTakeDamageSound.Play();

        if (Health <= 0)
        {
            Die();
        }
    }
}

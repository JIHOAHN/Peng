using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    GameObject pExplosionPrefab;
    Animator Animator;
    Rigidbody2D eRigidbody2D;
    Vector2 eMovingDirection;
    private float latestDirectionChangeTime;
    private float characterVelocity = 0.05f;
    private readonly float directionChangeTime = 0.05f;
    private Vector2 movementPerSecond;
    private Vector2 moveDirection;

    public float power = 0.05f;
    float x;
    float y;

    void Start()
    {
        Animator = GetComponent<Animator>();
        eRigidbody2D = GetComponent<Rigidbody2D>();

        latestDirectionChangeTime = 0f;
        calculateNewMovementVector();
    }

    void Update()
    {
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calculateNewMovementVector();
        }
        eRigidbody2D.AddForce(moveDirection, ForceMode2D.Impulse);
    }

    public void calculateNewMovementVector()
    {
        moveDirection = new Vector2(Random.Range(12.5f, -8.5f), Random.Range(3.5f, -6.5f)) * power;
        movementPerSecond = moveDirection * characterVelocity;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(col.gameObject);
            Instantiate(pExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            col.GetComponent<Penguin>().TakeDamage(20);

        }
    }
}

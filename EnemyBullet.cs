using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {


    private Rigidbody2D rb;

    public float bulletSpeed;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        bulletSpeed = 500f;

        rb.AddRelativeForce(new Vector2(0, bulletSpeed));
    }

    private void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
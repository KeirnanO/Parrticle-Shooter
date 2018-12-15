using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeSolo : MonoBehaviour {

    private Rigidbody2D rb;


    private Animator animator;

    [SerializeField]
    private int damage;
    public float bulletSpeed;

    private PlayerSolo player;

    private bool explode;
    private int explodeTime;

	// Use this for initialization
	void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        bulletSpeed = 700f;

        rb.AddRelativeForce(new Vector2(0, bulletSpeed));

        player = FindObjectOfType<PlayerSolo>();
        animator = FindObjectOfType<Animator>();

        explode = false;

	}

    private void Update()
    {
        explodeTime++;

        if(explodeTime >= 40f && !explode)
        {
            rb.velocity = Vector3.zero;
            animator.SetTrigger("Explode");
            explode = true;
            Destroy(gameObject, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!explode)
        {
            explode = true;
            rb.velocity = Vector3.zero;
            animator.SetTrigger("Explode");
            Destroy(gameObject, 1f);
        }

        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            player.AddPoints(1);
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            player.IncreaseMultiplier();
            player.AddPoints(10);
        }

    }
}

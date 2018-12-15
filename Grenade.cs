using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    private Rigidbody2D rb;


    private Animator animator;

    public float bulletSpeed;

    private Player player;
    private GameCoop game;

    private bool explode;
    private int explodeTime;

	// Use this for initialization
	void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        bulletSpeed = 700f;

        rb.AddRelativeForce(new Vector2(0, bulletSpeed));

        animator = FindObjectOfType<Animator>();

        explode = false;

        game = FindObjectOfType<GameCoop>();
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
            game.IncreaseMultiplier();
            player.IncreaseMultiplier();
            player.AddPoints(10);
        }

    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
}

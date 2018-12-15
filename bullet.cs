using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    private Rigidbody2D rb;


    private float bulletSpeed;

    private Player player;
    private GameCoop game;

	// Use this for initialization
	void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        bulletSpeed = 1500f;

        rb.AddRelativeForce(new Vector2(0, bulletSpeed));

        game = FindObjectOfType<GameCoop>();
	}

    private void Update()
    {
        Destroy(gameObject, 0.6f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            player.AddPoints(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            game.IncreaseMultiplier();
            player.AddPoints(10);
            player.IncreaseMultiplier();
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

}

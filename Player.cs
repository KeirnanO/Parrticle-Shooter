using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private GameCoop game;

    private int score;
    private int multiplier;
    private float multiplierTime;
    private float multiplierMaxTime;

    private int highestMultiplier;

    private bool dead;

    // Use this for initialization
    void Start ()
    {
        score = 0;
        multiplier = 0;
        highestMultiplier = 0;
        game = FindObjectOfType<GameCoop>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        game = FindObjectOfType<GameCoop>();

        if (Time.timeScale > 0)
        {
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time >= 0.1)
        {
            dead = true;
            Destroy(gameObject, 1f);
        }
    }

    public int GetScore()
    {
        return score;
    }
    public void AddPoints(int points)
    {
        score += points * game.GetMultiplier();
    }
    public void IncreaseMultiplier()
    {
        multiplier++;
        
        if(multiplier > highestMultiplier)
        {
            highestMultiplier = multiplier;
        }
    }
    public int GetMultiplier()
    {
        return multiplier;
    }
    public void LoseMultiplier()
    {
        multiplier = 0;
    }
    public bool IsDead()
    {
        return dead;
    }
}

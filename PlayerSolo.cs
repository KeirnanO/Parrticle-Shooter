using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSolo : MonoBehaviour {


    private int score;
    private int multiplier;
    private float multiplierTime;
    private float multiplierMaxTime;

    private bool dead;

    // Use this for initialization
    void Start ()
    {
        score = 0;
        multiplier = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.timeScale > 0)
        {
            CheckMultiplier();
        }
    }

    private void CheckMultiplier()
    {
        if (multiplierTime <= 0)
        {
            multiplier = 0;
        }
        if (multiplier > 0)
        {
            multiplierTime--;
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
        score += points * multiplier;
    }
    public void IncreaseMultiplier()
    {
        multiplier++;
        multiplierTime = multiplierMaxTime;
    }
    public int GetMultiplier()
    {
        return multiplier;
    }
    public float GetMultiplierTime()
    {
        return multiplierTime;
    }
    public float GetMultiplierMaxTime()
    {
        return multiplierMaxTime;
    }
    public void SetMultiplierMaxTime(int maxTime)
    {
        multiplierMaxTime = maxTime;
    }
    public bool IsDead()
    {
        return dead;
    }
}

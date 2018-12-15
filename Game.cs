using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerSolo))]
public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid;
    [SerializeField]
    private GameObject enemyL;
    [SerializeField]
    private GameObject enemyS;
    [SerializeField]
    private GameObject spawnPrefab;

    private GameObject playerPrefab;

    private int time;
    private int asteroidTime;
    private int spawnTime;

    private int wait;

    private PlayerSolo playerSolo;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI hiscoreText;
    [SerializeField]
    private TextMeshProUGUI streakText;
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private Image streakTime;


    private void Start()
    {
        Physics2D.IgnoreLayerCollision(0, 5);
        Physics2D.IgnoreLayerCollision(1, 1);
        Physics2D.IgnoreLayerCollision(1, 4);
        Physics2D.IgnoreLayerCollision(4, 4);
        Physics2D.IgnoreLayerCollision(5, 5);
        Physics2D.IgnoreLayerCollision(4, 5);


        for (int i = 0; i < 24; i++)
        {
            GameObject asteroids = Instantiate(asteroid, new Vector3(Random.Range(-30, 30), Random.Range(-35, 35), 0), Quaternion.Euler(0, 0, 0));
            asteroids.transform.localScale *= Random.Range(0.1f, 6);
        }
        Instantiate(enemyL, new Vector3(Random.Range(-30,30), Random.Range(-35, 35), 0), Quaternion.Euler(0, 0, 0));
        Instantiate(enemyL, new Vector3(Random.Range(-30, 30), Random.Range(-35, 35), 0), Quaternion.Euler(0, 0, 0));

    }

    private void Update()
    {
        //Spawn Enemies
        if (Time.timeScale != 0)
        {
            if (asteroidTime == 110)
            {
                GameObject asteroid1 = Instantiate(asteroid, new Vector3(Random.Range(-50, 50), Random.Range(47, 49), 0), Quaternion.Euler(0, 0, 0));
                GameObject asteroid2 = Instantiate(asteroid, new Vector3(Random.Range(-50, 50), Random.Range(-47, -49), 0), Quaternion.Euler(0, 0, 0));
                GameObject asteroid3 = Instantiate(asteroid, new Vector3(Random.Range(-55, -50), Random.Range(-47, 47), 0), Quaternion.Euler(0, 0, 0));
                GameObject asteroid4 = Instantiate(asteroid, new Vector3(Random.Range(50, 55), Random.Range(-47, 47), 0), Quaternion.Euler(0, 0, 0));

                Color color1 = new Color(255, 238, 2, 1.0f);
                Color color2 = new Color(255, 226, 3, 1.0f);
                Color color3 = new Color(203, 131, 7, 1.0f);
                Color color4 = new Color(217, 224, 21, 1.0f);

                asteroid1.transform.localScale *= Random.Range(0.1f, 6);
                SpriteRenderer sr = asteroid1.GetComponentInChildren<SpriteRenderer>();
                sr.color = color1;
                asteroid2.transform.localScale *= Random.Range(0.1f, 6);
                SpriteRenderer sr2 = asteroid2.GetComponentInChildren<SpriteRenderer>();
                sr2.color = color2;
                asteroid3.transform.localScale *= Random.Range(0.1f, 6);
                SpriteRenderer sr3 = asteroid3.GetComponentInChildren<SpriteRenderer>();
                sr3.color = color3;
                asteroid4.transform.localScale *= Random.Range(0.1f, 6);
                SpriteRenderer sr4 = asteroid4.GetComponentInChildren<SpriteRenderer>();
                sr4.color = color4;

                asteroidTime = 0;
            }


            if (time % 340 / Mathf.Round(Time.time / 10) == 0)
            {
                int r = Random.Range(0, 5);
                if (r == 1)
                {
                    Instantiate(enemyL, new Vector3(Random.Range(-35, 35), Random.Range(37, 39), 0), Quaternion.Euler(0, 0, 0));
                }
                else if (r == 2)
                {
                    Instantiate(enemyL, new Vector3(Random.Range(-35, 35), Random.Range(-37, 39), 0), Quaternion.Euler(0, 0, 0));
                }
                else if (r == 3)
                {
                    Instantiate(enemyL, new Vector3(Random.Range(35, 37), Random.Range(-37, 37), 0), Quaternion.Euler(0, 0, 0));
                }
                else
                {
                    Instantiate(enemyL, new Vector3(Random.Range(-35, 37), Random.Range(-37, 37), 0), Quaternion.Euler(0, 0, 0));
                }
            }

            if (time % 510 / Mathf.Round(Time.time / 10) == 0)
            {
                int r = Random.Range(0, 5);
                if (r == 1)
                {
                    Instantiate(enemyS, new Vector3(Random.Range(-35, 35), Random.Range(37, 39), 0), Quaternion.Euler(0, 0, 0));
                }
                else if (r == 2)
                {
                    Instantiate(enemyS, new Vector3(Random.Range(-35, 35), Random.Range(-37, 39), 0), Quaternion.Euler(0, 0, 0));
                }
                else if (r == 3)
                {
                    Instantiate(enemyS, new Vector3(Random.Range(35, 37), Random.Range(-37, 37), 0), Quaternion.Euler(0, 0, 0));
                }
                else
                {
                    Instantiate(enemyS, new Vector3(Random.Range(-35, 37), Random.Range(-37, 37), 0), Quaternion.Euler(0, 0, 0));
                }
            }


            SpawnPlayer();

            asteroidTime++;
            time++;
            wait++;
        }

        //GetScore
        GetScore();
        GetKillstreak();
        SetStreakTime();
        SetTimeText();

    }

    private void SpawnPlayer()
    {
        playerSolo = FindObjectOfType<PlayerSolo>();

        if (playerSolo == null)
        {
            GameObject spawn = Instantiate(spawnPrefab, new Vector3(Random.Range(-15, 15), Random.Range(-7, 9), 0), Quaternion.Euler(0, 0, 0));
            playerSolo = Instantiate(playerPrefab, spawn.transform.position, Quaternion.Euler(0, 0, 0)).GetComponent<PlayerSolo>();
        }
    }
    private void GetScore()
    {
        scoreText.text = playerSolo.GetScore().ToString();
    }
    private void GetKillstreak()
    {
        if(playerSolo.GetMultiplier() > 0)
        {
            streakText.text = "Killstreak x " + playerSolo.GetMultiplier();
        }
        else
        {
            streakText.text = "";
        }
    }
    private void SetStreakTime()
    {
        streakTime.fillAmount = (playerSolo.GetMultiplierTime() / playerSolo.GetMultiplierMaxTime());
    }
    private void SetTimeText()
    {
        timeText.text = "Time: " + ((Mathf.Round(Time.time * 10)/10).ToString());
    }

    public void SetPlayerPrefab(GameObject prefab)
    {
        playerPrefab = prefab;
    }

    public GameObject GetPlayerPrefab()
    {
        return playerPrefab;
    }


}


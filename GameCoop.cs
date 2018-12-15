using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameCoop : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid;
    [SerializeField]
    private GameObject enemyL;
    [SerializeField]
    private GameObject enemyS;
    [SerializeField]
    private GameObject spawnPrefab;

    private GameObject[] playerPrefabs;

    private EnemyL eL;
    private EnemyS eS;

    private int time;
    private int asteroidTime;

    private int multiplier;
    private int score;
    private float multiplierTime;
    private float multiplierMaxTime;

    private Player[] players;

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

        multiplierMaxTime = 90f - (playerPrefabs.Length * 5);

            for (int i = 0; i < 24; i++)
            {
                GameObject asteroids = Instantiate(asteroid, new Vector3(Random.Range(-30, 30), Random.Range(-35, 35), 0), Quaternion.Euler(0, 0, 0));
                asteroids.transform.localScale *= Random.Range(0.1f, 6);
            }

        for (int i = 0; i < playerPrefabs.Length; i++)
        {
            eL = Instantiate(enemyL, new Vector3(Random.Range(-30, 30), Random.Range(-35, 35), 0), Quaternion.Euler(0, 0, 0)).GetComponent<EnemyL>();
            eL.SetPlayer(players[i]);
            eL = Instantiate(enemyL, new Vector3(Random.Range(-30, 30), Random.Range(-35, 35), 0), Quaternion.Euler(0, 0, 0)).GetComponent<EnemyL>();
            eL.SetPlayer(players[i]);
        }

    }

    private void Update()
    {
        //Spawn Enemies
        if (Time.timeScale != 0)
        {
            if (asteroidTime == 110)
            {
                for (int i = 0; i < playerPrefabs.Length; i++)
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
            }


            if (time % 340 / Mathf.Round(Time.time / 10) == 0)
            {
                for (int i = 0; i < playerPrefabs.Length; i++)
                {
                    int r = Random.Range(0, 5);
                    if (r == 1)
                    {
                        eL = Instantiate(enemyL, new Vector3(Random.Range(-35, 35), Random.Range(37, 39), 0), Quaternion.Euler(0, 0, 0)).GetComponent<EnemyL>();
                    }
                    else if (r == 2)
                    {
                        eL = Instantiate(enemyL, new Vector3(Random.Range(-35, 35), Random.Range(-37, 39), 0), Quaternion.Euler(0, 0, 0)).GetComponent<EnemyL>();
                    }
                    else if (r == 3)
                    {
                        eL = Instantiate(enemyL, new Vector3(Random.Range(35, 37), Random.Range(-37, 37), 0), Quaternion.Euler(0, 0, 0)).GetComponent<EnemyL>();
                    }
                    else
                    {
                        eL = Instantiate(enemyL, new Vector3(Random.Range(-35, 37), Random.Range(-37, 37), 0), Quaternion.Euler(0, 0, 0)).GetComponent<EnemyL>();
                    }


                    eL.SetPlayer(players[i]);

                }
            }

            if (time % 510 / Mathf.Round(Time.time / 10) == 0)
            {
                for (int i = 0; i < playerPrefabs.Length; i++)
                {
                    int r = Random.Range(0, 5);
                    if (r == 1)
                    {
                        eS = Instantiate(enemyS, new Vector3(Random.Range(-35, 35), Random.Range(37, 39), 0), Quaternion.Euler(0, 0, 0)).GetComponent<EnemyS>();
                    }
                    else if (r == 2)
                    {
                        eS = Instantiate(enemyS, new Vector3(Random.Range(-35, 35), Random.Range(-37, 39), 0), Quaternion.Euler(0, 0, 0)).GetComponent<EnemyS>();
                    }
                    else if (r == 3)
                    {
                        eS = Instantiate(enemyS, new Vector3(Random.Range(35, 37), Random.Range(-37, 37), 0), Quaternion.Euler(0, 0, 0)).GetComponent<EnemyS>();
                    }
                    else
                    {
                        eS = Instantiate(enemyS, new Vector3(Random.Range(-35, 37), Random.Range(-37, 37), 0), Quaternion.Euler(0, 0, 0)).GetComponent<EnemyS>();
                    }

                    eS.SetPlayer(players[i]);

                }
            }

            SpawnPlayers();

            asteroidTime++;
            time++;
        }

        //GetScore
        GetMultiplierTime();
        GetScore();
        GetKillstreak();
        SetStreakTime();
        SetTimeText();

    }

    private void SpawnPlayers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == null)
            {
                GameObject spawn = Instantiate(spawnPrefab, new Vector3(Random.Range(-15, 15), Random.Range(-7, 9), 0), Quaternion.Euler(0, 0, 0));
                players[i] = Instantiate(playerPrefabs[i], spawn.transform.position, Quaternion.Euler(0, 0, 0)).GetComponent<Player>();


            }
        }
    }

    private void GetScore()
    {
        int localScore = 0;

        for(int i = 0; i < players.Length; i++)
        {
            localScore = localScore + players[i].GetScore();
        }

        score = localScore;

        scoreText.text = score.ToString();
    }
    private void GetKillstreak()
    {
        int localMultiplier = 0;

        for (int i = 0; i < players.Length; i++)
        {
            localMultiplier += players[i].GetMultiplier();
        }

        multiplier = localMultiplier;

        if (multiplier > 0)
        {
            streakText.text = "Killstreak x " + multiplier;
        }
        else
        {
            streakText.text = "";
        }
    }
    private void SetStreakTime()
    {
        streakTime.fillAmount = (multiplierTime / multiplierMaxTime);
    }
    private void GetMultiplierTime()
    {
        if (multiplierTime <= 0)
        {
            multiplier = 0;
            for (int i = 0; i < players.Length; i++)
            {
                players[i].LoseMultiplier();
            }
        }
        if (multiplier > 0)
        {
            multiplierTime--;
        }
    }
    public int GetMultiplier()
    {
        return multiplier;
    }


    private void SetTimeText()
    {
        timeText.text = "Time: " + ((Mathf.Round(Time.time * 10)/10).ToString());
    }

    public void IncreaseMultiplier()
    {
        multiplier++;
        multiplierTime = multiplierMaxTime;
    }


    public void SetPlayerPrefab(GameObject[] prefabs, int numberOfPlayers)
    {
        players = new Player[numberOfPlayers];
        playerPrefabs = new GameObject[numberOfPlayers];
        for (int i = 0; i < numberOfPlayers; i++)
        {
            playerPrefabs[i] = prefabs[i];
        }
        SpawnPlayers();
    }

    public Player[] GetPlayers()
    {
        return players;
    }


}


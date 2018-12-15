using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerJoin : MonoBehaviour {

    [SerializeField]
    private GameObject[] notJoined;
    [SerializeField]
    private GameObject[] joinedCharacter;
    [SerializeField]
    private Image[] characterImage;
    [SerializeField]
    private GameObject[] ready;
    [SerializeField]
    private Sprite[] characterSprites;
    [SerializeField]
    private GameObject[] characterPreFabs;  
    [SerializeField]
    private GameObject startGame;

    private GameObject[] setPrefab = new GameObject[4];

    private GameCoop game;

    [SerializeField]
    private GameObject menuObject;
    [SerializeField]
    private GameObject mainMenu;

    private bool[] joined = new bool[4];
    private bool[] selecting = new bool[4];
    private bool[] playerReady = new bool[4];
    private int[] selectTime = new int[4];
    private int[] hover = new int[4];

    private int numJoined;
    private int numReady;

	// Use this for initialization
	void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            joined[i] = false;
            playerReady[i] = false;
            selecting[i] = false;
            selectTime[i] = 0;
            hover[i] = 0;
        }

        numJoined = 0;
        numReady = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        game = FindObjectOfType<GameCoop>();

        GetInput();
        GetStart();        
    }


    private void GetInput()
    {
        for(int i = 0; i < 4; i++)
        {
            if (!joined[i])
            {
                if (Input.GetKeyDown("joystick " + (i + 1) + " button 0"))
                {
                    notJoined[i].SetActive(false);
                    joinedCharacter[i].SetActive(true);
                    selecting[i] = true;
                    joined[i] = true;

                    numJoined++;
                    selectTime[i] = 0;
                }
            }

            //Back Button
            if (Input.GetKeyDown("joystick " + (i + 1) + " button 1"))
            {
                if (selecting[i])
                {
                    notJoined[i].SetActive(true);
                    joinedCharacter[i].SetActive(false);
                    joined[i] = false;
                    selecting[i] = false;

                    numJoined--;
                }
                else if (playerReady[i])
                {
                    ready[i].SetActive(false);
                    playerReady[i] = false;
                    selecting[i] = true;
                    numReady--;
                }
                else
                {
                    menuObject.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
                


            if (selecting[i])
            {
                if(hover[i] == 0)
                {
                    hover[i] = i * 10;
                }

                if (Input.GetAxis("Menu Horizontal" + (i + 1)) == 1 && selectTime[i] > 5f)
                {
                    if (hover[i] == (i*10) + 1)
                    {
                        hover[i] = i*10;
                    }
                    else
                    {
                        hover[i]++;
                    }
                    selectTime[i] = 0;
                }
                else if (Input.GetAxis("Menu Horizontal" + (i + 1)) == -1 && selectTime[i] > 5f)
                {
                    if (hover[i] == i*10)
                    {
                        hover[i] = (i*10) + 1;
                    }
                    else
                    {
                        hover[i]--;
                    }
                    selectTime[i] = 0;
                }
                else
                {
                    selectTime[i]++;
                }

                characterImage[i].sprite = characterSprites[hover[i]];
                setPrefab[i] = characterPreFabs[hover[i]];
                
                if (Input.GetKeyDown("joystick " + (i + 1) + " button 0") && selectTime[i] > 2f)
                {
                    selecting[i] = false;
                    playerReady[i] = true;
                    ready[i].SetActive(true);
                    numReady++;
                }
            }
            


        }
    }
    private void GetStart()
    {
        if (numJoined >= 2 && numReady == numJoined)
        {
            startGame.SetActive(true); ;

            if(Input.GetKeyDown("joystick button 7"))
            {
                SceneManager.LoadSceneAsync("Coop");
            }

            game.SetPlayerPrefab(setPrefab, numReady);

            if (game.GetPlayers() != null)
            {
                Destroy(mainMenu);
            }
            
        }
        else
        {
            startGame.SetActive(false);
        }
    }

    private void StartGame()
    {

        Array.Clear(setPrefab, 0, setPrefab.Length);
        /*
        for(int i = 0; i < setPrefab.Length; i++)
        {
            print("yo");
            if(setPrefab[i] == null)
            {
                Array.Clear(setPrefab, 0, setPrefab.Length);
                i--;
            }
        }
        */
        print(setPrefab[0]);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SingleplayerSelect : MonoBehaviour {

    [SerializeField]
    private Sprite[] characterSprites;
    [SerializeField]
    private GameObject[] actualCharacters;

    [SerializeField]
    private GameObject menuObject;

    private GameObject selectedCharacter;

    private Game game;

    private Image character;

    private int hover;
    private bool movable;
    private int time;

    // Use this for initialization
    void Start ()
    {
        character = GetComponent<Image>();
        hover = 0;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetSelected();

        character.sprite = characterSprites[hover];

        if (Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadScene("Singleplayer");
        }
        if (Input.GetKeyDown("joystick button 1"))
        {
            menuObject.SetActive(true);
            gameObject.SetActive(false);
        }

        game = FindObjectOfType<Game>();
        game.SetPlayerPrefab(actualCharacters[hover]);

        if (game.GetPlayerPrefab() != null)
        {
            Destroy(gameObject);
        }
    }
    
    private void GetSelected()
    {
        if (Input.GetAxis("Menu Horizontal1") == 1 && time > 5f)
        {
            if (hover == characterSprites.Length - 1)
            {
                hover = 0;
            }
            else
            {
                hover++;
            }
            time = 0;
        }
        else if (Input.GetAxis("Menu Horizontal1") == -1 && time > 5f && hover > 0)
        {
            if (hover == 0)
            {
                hover = characterSprites.Length - 1;
            }
            else
            {
                hover--;
            }
            time = 0;
        }
        else
        {
            time++;
        }
    }

}

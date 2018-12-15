using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI[] selections;
    [SerializeField]
    private Scene[] scenes;

    [SerializeField]
    private GameObject playerJoin;
    [SerializeField]
    private GameObject singlePlayerSelect;

    private GameObject menuObjects;

    private int hover;
    private bool movable;
    private int time;

    private Color selected;
    private Color unselected;


    // Use this for initialization
    void Start ()
    {
        hover = 0;
        movable = true;

        menuObjects = GameObject.FindGameObjectWithTag("ShowOnMenu");

        selected = new Color(82, 82, 82, 0.8f);

        unselected = new Color(82, 82, 82, 0.3f);
	}
	
	// Update is called once per frame
	void Update ()
    {

        selections[hover].color = selected;

        MenuLogic();
    }

    private void MenuLogic()
    {
        if (Input.GetAxis("Menu Vertical") == 1 && hover < 3 && movable)
        {
            selections[hover].color = unselected;
            time = 0;
            hover++;
        }
        if (Input.GetAxis("Menu Vertical") == -1 && hover > 0 && movable)
        {
            selections[hover].color = unselected;
            time = 0;
            hover--;
        }

        if (time > 10)
        {
            movable = true;
        }
        else
        {
            time++;
            movable = false;
        }

        if (Input.GetKeyDown("joystick button 0"))
        {
            switch (hover)
            {
                case 0:
                    menuObjects.SetActive(false);
                    SoloLogic();
                    break;

                case 1:
                    menuObjects.SetActive(false);
                    CoopLogic();
                    break;

                case 3:
                    Application.Quit();
                    break;
            }
        }
    }

    private void SoloLogic()
    {
        singlePlayerSelect.SetActive(true);
        menuObjects.SetActive(false);
    }

    private void CoopLogic()
    {
        playerJoin.SetActive(true);
        menuObjects.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField]
    private GameObject[] pauseObjects;

    private bool paused;

	// Use this for initialization
	void Awake ()
    {
        Time.timeScale = 1;
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("joystick button 7"))
        {
            Time.timeScale = 0;
            showPaused();
            paused = true;
        }
        if(paused && Input.GetKeyDown("joystick button 1"))
        {
            Time.timeScale = 1;
            hidePaused();
        }
        if(paused && Input.GetKeyDown("joystick button 3"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
        if (paused && Input.GetKeyDown("joystick button 2"))
        {
            Time.timeScale = 1;
            hidePaused();
            SceneManager.LoadScene(1);            
        }

    }

    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

}

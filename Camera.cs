using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {


    private PlayerSolo player;
    private Grenader grenader;


	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerSolo>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        player = FindObjectOfType<PlayerSolo>();

        transform.SetPositionAndRotation(new Vector3(player.transform.localPosition.x, player.transform.localPosition.y, -20), Quaternion.Euler(0, 0, 0));
	}
}

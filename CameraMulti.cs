using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMulti : MonoBehaviour {

    private Player[] players;
    private GameCoop game;

    public Vector3 offset;

    private float maxZoom = -60f;
    private float minZoom = -15f;



	// Use this for initialization
	void Start ()
    {
        game = FindObjectOfType<GameCoop>();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        players = game.GetPlayers();

        Zoom();
        Move();
    }


    private void Zoom()
    {
        float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance() / 45);
        offset = new Vector3(0, 0, newZoom);
    }

    private float GetGreatestDistance()
    {
        var bounds = new Bounds(players[0].transform.position, Vector3.zero);

        for (int i = 0; i < players.Length; i++)
        {
            bounds.Encapsulate(players[i].transform.position);
        }

        if(bounds.size.x > bounds.size.y)
        {
            return bounds.size.x;
        }
        else
        {
            return bounds.size.y;
        }

    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.SetPositionAndRotation(newPosition, Quaternion.Euler(0, 0, 0));
    }

    private Vector3 GetCenterPoint()
    {
        var bounds = new Bounds(players[0].transform.position, Vector3.zero);

        for(int i = 0; i < players.Length; i++)
        {
            bounds.Encapsulate(players[i].transform.position);
        }

        return bounds.center;
    }

}

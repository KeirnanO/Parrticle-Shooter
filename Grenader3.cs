using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenader3 : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject bpos1;

    private Player player;
    private Grenade grenade;

    private int moveSpeed;

    private Animator animator;

    private int reloadTime;

    private int score;
    private int multiplier;
    private float multiplierTime;

    //This stops rapid fire
    private bool fire;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();

        fire = false;
    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            Move();

            CheckFire();
        }

        if (player.IsDead())
        {
            enabled = false;
        }
    }

    //Inputs and Mechanics
    public void Move()
    {
        transform.eulerAngles = new Vector3(10, 0, Mathf.Atan2(Input.GetAxis("Vertical3"), Input.GetAxis("Horizontal3")) * 180 / Mathf.PI - 90);
        transform.Translate(new Vector3(Input.GetAxis("Horizontal3") * 10 * Time.deltaTime, Input.GetAxis("Vertical3") * 10 * Time.deltaTime, 0), Space.World);
    }

    private void CheckFire()
    {
        if (Input.GetKeyDown("joystick 3 button 0") && !fire)
        {
            fire = true;
            grenade = Instantiate(bullet, bpos1.transform.position, bpos1.transform.rotation).GetComponent<Grenade>();
            grenade.SetPlayer(player);
            reloadTime = 0;
        }

        if (fire && reloadTime > 180f)
        {
            fire = false;
        }
        else
        {
            reloadTime++;
        }
    }
}

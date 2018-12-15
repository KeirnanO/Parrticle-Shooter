using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject bpos1;
    [SerializeField]
    private GameObject bpos2;
    [SerializeField]
    private GameObject bpos3;

    private PlayerSolo player;

    private int moveSpeed;

    private Animator animator;

    private int damage;

    private bool invincible;
    private int invincibleTimer;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerSolo>();
        player.SetMultiplierMaxTime(90);        
    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            Move();

            CheckFire();
        }

        if(player.IsDead())
        {
            enabled = false;
        }

    }

    //Inputs and Mechanics
    public void Move()
    {
        transform.eulerAngles = new Vector3(10, 0, Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * 180 / Mathf.PI - 90);
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * 17 * Time.deltaTime, Input.GetAxis("Vertical") * 17 * Time.deltaTime, 0), Space.World);
    }

    private void CheckFire()
    {
        if (Input.GetKeyDown("joystick 1 button 0"))
        {
            Instantiate(bullet, bpos1.transform.position, bpos1.transform.rotation);
            Instantiate(bullet, bpos2.transform.position, bpos2.transform.rotation);
            Instantiate(bullet, bpos3.transform.position, bpos3.transform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast3 : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bpos1;
    [SerializeField]
    private GameObject bpos2;
    [SerializeField]
    private GameObject bpos3;

    private Player player;

    private bullet bullet;

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();        
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
        transform.eulerAngles = new Vector3(10, 0, Mathf.Atan2(Input.GetAxis("Vertical3"), Input.GetAxis("Horizontal3")) * 180 / Mathf.PI - 90);
        transform.Translate(new Vector3(Input.GetAxis("Horizontal3") * 17 * Time.deltaTime, Input.GetAxis("Vertical3") * 17 * Time.deltaTime, 0), Space.World);
    }

    private void CheckFire()
    {
        if (Input.GetKeyDown("joystick 3 button 0"))
        {
            bullet = Instantiate(bulletPrefab, bpos1.transform.position, bpos1.transform.rotation).GetComponent<bullet>();
            bullet.SetPlayer(player);
            bullet = Instantiate(bulletPrefab, bpos2.transform.position, bpos2.transform.rotation).GetComponent<bullet>();
            bullet.SetPlayer(player);
            bullet = Instantiate(bulletPrefab, bpos3.transform.position, bpos3.transform.rotation).GetComponent<bullet>();
            bullet.SetPlayer(player);
        }
    }
}

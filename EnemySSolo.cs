using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySSolo : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject cannon;
    [SerializeField]
    private GameObject cannon2;
    [SerializeField]
    private GameObject cannon3;
    [SerializeField]
    private GameObject cannon4;
    [SerializeField]
    private GameObject cannon5;
    [SerializeField]
    private GameObject cannon6;
    [SerializeField]
    private GameObject cannon7;
    [SerializeField]
    private GameObject cannon8;
    [SerializeField]
    private GameObject cannon9;
    [SerializeField]
    private GameObject cannon10;
    [SerializeField]
    private GameObject cannon11;
    [SerializeField]
    private GameObject cannon12;

    private PlayerSolo player;
    private Animator animator;

    private int attackSpeed;
    private int r;
    private int rad;

    private float mag;
    private float speed;


    // Use this for initialization
    void Awake()
    {
        player = FindObjectOfType<PlayerSolo>();
        animator = GetComponent<Animator>();

        r = 0;
        speed = 0.2f;
        rad = Random.Range(-2, 2);
    }

    void FixedUpdate()
    {
        if (mag > 16)
        {
            Vector2 toTarget = player.transform.position - transform.position;

            transform.Translate(toTarget * speed * Time.deltaTime);
        }
        else if (mag < 16)
        {
            Vector2 toTarget = transform.position - player.transform.position;

            transform.Translate(toTarget * speed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<PlayerSolo>();
        Vector3 diff = (player.transform.position - transform.position);
        mag = (player.transform.position - transform.position).magnitude;
        float angle = Mathf.Atan2(diff.y, diff.x);

        transform.rotation = Quaternion.Euler(0f, 0f, (angle * Mathf.Rad2Deg) - 89.5f);

        if (mag <= 16)
        {
            transform.RotateAround(player.transform.position, new Vector3(0, 0, 1), rad * 5 * Time.deltaTime);
        }


        if (attackSpeed == (150 + r) && Time.deltaTime > 0)
        {
            Instantiate(bulletPrefab, cannon.transform.position, cannon.transform.rotation);
            Instantiate(bulletPrefab, cannon2.transform.position, cannon2.transform.rotation);
            Instantiate(bulletPrefab, cannon3.transform.position, cannon3.transform.rotation);
            Instantiate(bulletPrefab, cannon4.transform.position, cannon4.transform.rotation);
            Instantiate(bulletPrefab, cannon5.transform.position, cannon5.transform.rotation);
            Instantiate(bulletPrefab, cannon6.transform.position, cannon6.transform.rotation);
            Instantiate(bulletPrefab, cannon7.transform.position, cannon7.transform.rotation);
            Instantiate(bulletPrefab, cannon8.transform.position, cannon8.transform.rotation);
            Instantiate(bulletPrefab, cannon9.transform.position, cannon9.transform.rotation);
            Instantiate(bulletPrefab, cannon10.transform.position, cannon10.transform.rotation);
            Instantiate(bulletPrefab, cannon11.transform.position, cannon11.transform.rotation);
            Instantiate(bulletPrefab, cannon12.transform.position, cannon12.transform.rotation);
            r = Random.Range(0, 120);
            attackSpeed = 0;
        }



        attackSpeed++;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            animator.SetTrigger("Dead");
            GetComponent<PolygonCollider2D>().enabled = false;
            Destroy(gameObject, 0.3f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLSolo : MonoBehaviour
{

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject cannon;

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
        speed = 0.3f;
        rad = Random.Range(-2, 2);
    }

    void FixedUpdate()
    {
        if (mag > 7)
        {
            Vector2 toTarget = player.transform.position - transform.position;

            transform.Translate(toTarget * speed * Time.deltaTime);
        }
        else if (mag <= 5)
        {
            Vector2 toTarget =transform.position - player.transform.position;

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
       
        if(mag <= 10)
        {
            transform.RotateAround(player.transform.position, new Vector3(0, 0, 1), rad * 5 * Time.deltaTime);
        }


        if (attackSpeed % (60 + r) == 0 && mag < 80 && Time.deltaTime > 0)
        {
            Instantiate(bulletPrefab, cannon.transform.position, cannon.transform.rotation);
            r = Random.Range(0, 120);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour{

    private Rigidbody2D rb;

    private Animator animator;
    private PolygonCollider2D bc;

    [SerializeField]
    private int health;

    [SerializeField]
    private float maxThrust;
    [SerializeField]
    private float maxTorque;

    private bool alive;
    private bool splittable;
    private bool splitted;

    private void Awake()
    {
        health = 1;
        alive = true;
        splitted = false;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        bc = GetComponent<PolygonCollider2D>();

        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust*rb.mass);
        rb.AddTorque(torque*rb.mass);

        if(transform.localScale.x > 0.6)
        {
            splittable = true;
        }

    }

    private void Update()
    {
        CheckBounds();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            if (splittable && !splitted)
            {
                GameObject piece1 = Instantiate(gameObject, new Vector3(transform.localPosition.x - 0.5f, transform.localPosition.y, transform.localPosition.z), transform.localRotation);
                GameObject piece2 = Instantiate(gameObject, new Vector3(transform.localPosition.x + 0.5f, transform.localPosition.y, transform.localPosition.z), transform.localRotation);

                piece1.transform.localScale /= 1.4f;
                piece2.transform.localScale /= 1.4f;

                splitted = true;
            }

            animator.SetTrigger("Dead");
            bc.enabled = false;

            alive = false;

            Destroy(gameObject, .3f);
        }
}

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void CheckBounds()
    {
        if(transform.position.x < -60 || transform.position.x > 60 || transform.position.y > 50 || transform.position.y < -50)
        {
            Destroy(gameObject);
        }
    }
}

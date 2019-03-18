using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeChange = 0;
    private float MovementX;
    private float MovementY;


    private float moveSpeed = 1f;
    public Rigidbody2D rb;

    public float ChaseRadius;
    public float AttackRadius;
    public Animator animator;
    private GameObject target;

    public int health;
    private int damagedlt;
    public int dodamage = 2;

    public bool Moving = false;

    Vector3 movement;
    Vector3 temp;

    void Start()
    {
        target = GameObject.Find("Player");
        Moving = false;
    }

    void Update()
    {
        CheckDistance();
    }   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackHB"))
        {
            damagedlt = collision.GetComponentInParent<Attack>().damage;
            health -= damagedlt;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Move()
    {
        if (Time.time >= timeChange)
        {
            rb.velocity = new Vector2(0, 0);
            MovementX = Random.Range(1, -2);
            MovementY = Random.Range(1, -2);      
            movement = new Vector3(MovementX, MovementY, 0f);
            rb.velocity += new Vector2(MovementX, MovementY) * moveSpeed;
            timeChange = Time.time + 2;
        }
        
    }


    private void Animations()
    {
        animator.SetFloat("ZomX", rb.velocity.x);
        animator.SetFloat("ZomY", rb.velocity.y);
        animator.SetFloat("ZomMagnitude", rb.velocity.magnitude);

    }

    private void CheckDistance()
    {
        if(Vector3.Distance(target.transform.position, transform.position) <= ChaseRadius && Vector3.Distance(target.transform.position, transform.position) > AttackRadius)
        {
            Moving = target.GetComponentInChildren<Attack>().knocked;

            if(Moving == false)
            {
                rb.velocity = new Vector2(0f, 0f);
            }
            temp = target.transform.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            animator.SetFloat("ZomX", temp.x);
            animator.SetFloat("ZomY", temp.y);
            animator.SetFloat("ZomMagnitude", temp.magnitude);

        }
        
        else
        {
            Move();
            Animations();
        }
   

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeChange = 0;
    private float MovementX;
    private float MovementY;



    public float moveSpeed = 0.2f;
    public Rigidbody2D rb;
    //public Vector2 maxpos;
    //public Vector2 minpos;
    public float ChaseRadius;
    public float AttackRadius;
    public Animator animator;
    public Transform target;
    public float xMove;
    public float yMove;
    public float xOffset;
    public float yOffset;
    public float magnitude;
    public float enemyHealth;
    Vector3 movement;
    Vector3 temp;

    void Start()
    {
        enemyHealth = 100;
    }

    void Update()
    {

        CheckDistance();
        //CheckBoundaries();
        Animations();


    }
   
    private void Move()
    {
        if (Time.time >= timeChange)
        {
            MovementX = Random.Range(1, -2);
            MovementY = Random.Range(1, -2);
            timeChange = Time.time + 2;
            movement = new Vector3(MovementX, MovementY, 0f);
            
            rb.velocity += new Vector2(MovementX, MovementY) * moveSpeed;
            xMove = rb.velocity.x;
            yMove = rb.velocity.y;
            magnitude = rb.velocity.magnitude;
        }
        
    }

    //private void CheckBoundaries()
    //{
        //if (transform.position.x >= maxpos.x || transform.position.x <= minpos.x)
        //{
            //rb.velocity = new Vector2(-RandomX, RandomY) * moveSpeed;
        //}
        //if (transform.position.y >= maxpos.y || transform.position.y <= minpos.y)
        //{
            //rb.velocity = new Vector2(RandomX, -RandomY) * moveSpeed;
        //}

    //}

    private void Animations()
    {
        animator.SetFloat("ZomX", xMove);
        animator.SetFloat("ZomY", yMove);
        animator.SetFloat("ZomMagnitude", magnitude);

    }
    private void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= ChaseRadius && Vector3.Distance(target.position, transform.position) > AttackRadius)
        {
            if (MovementX > 0f || MovementX < 0f) 
            {
                rb.velocity = new Vector2(0f, 0f);
            }
            if (MovementY > 0f || MovementY < 0f)

            {
                rb.velocity = new Vector2(0f, 0f);
            }

            temp = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime * 2);
            xMove = target.position.x - transform.position.x;
            yMove = target.position.y - transform.position.y;
            magnitude = 0.5f;
            Animations();
        }
        
        else
        {
            Move();
        }
   

    }
}

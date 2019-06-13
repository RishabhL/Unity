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

    public GameObject HeartModule;
    public GameObject Coin;
    public Item[] Axe = new Item[5];
    public Item[] Spear = new Item[5];
    public GameObject axe;
    public GameObject spear;

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
                SpawnRandom();
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().health -= 1;

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
            Moving = target.GetComponent<Attack>().knocked;

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
    void SpawnRandom()
    {
        int rnd = Random.Range(1, 11);
        if (rnd == 1)
        {
            Instantiate(HeartModule, transform.position, Quaternion.identity);
        }
        if (rnd > 1 && rnd < 8)
        {
            Instantiate(Coin, transform.position, Quaternion.identity);
        }
        if (rnd >= 8)
        {
            int rnd_w = Random.Range(1, 3);
            if (rnd_w == 1)
            {

                int rar_rnd = Random.Range(1, 16);
                if (rar_rnd <= 5)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[0];
                }
                else if (rar_rnd > 5 && rar_rnd < 10)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[1];
                }
                else if (rar_rnd >= 10 && rar_rnd < 13)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[2];
                }
                else if (rar_rnd >= 13 && rar_rnd < 15)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[3];
                }
                else if (rar_rnd == 15)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[4];
                }

                Instantiate(axe, transform.position, Quaternion.identity);
            }

            else if (rnd_w == 2)
            {
                int rar_rnd = Random.Range(1, 16);
                if (rar_rnd <= 5)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[0];
                }
                else if (rar_rnd > 5 && rar_rnd < 10)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[1];
                }
                else if (rar_rnd >= 10 && rar_rnd < 13)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[2];
                }
                else if (rar_rnd >= 13 && rar_rnd < 15)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[3];
                }
                else if (rar_rnd == 15)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[4];
                }

                Instantiate(spear, transform.position, Quaternion.identity);
            }
        }



    }

}

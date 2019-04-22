using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public GameObject crossHair;
    public GameObject inventory;
    public Rigidbody2D rb;
    public Vector2 maxaim;
    public Vector2 minaim;

    public bool isattacking;

    public Camera cam;

    Vector3 movement;
    Vector3 aim;
    Vector2 cross;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = true;
        
    }
    // Update is called once per frame
    void Update()
    {

        if (inventory.activeInHierarchy)
        {
            Setallzero();
            Animations();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else if (!inventory.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Inputs();
            Shooting();
            Animations();
            Move();
        }
    }
    private void Inputs()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal") * 2, Input.GetAxisRaw("Vertical") * 2, 0f);
        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f);
        aim = aim + mouseMovement;
        aim.x = Mathf.Clamp(aim.x, transform.position.x + minaim.x, transform.position.x + maxaim.x);
        aim.y = Mathf.Clamp(aim.y, transform.position.y+ minaim.y, transform.position.y + maxaim.y);

    }

    private void Animations()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
        animator.SetFloat("CrossX", cross.x);
        animator.SetFloat("CrossY", cross.y);
        animator.SetFloat("CrossMagnitude", cross.magnitude);
        animator.SetBool("Aiming", Input.GetButtonDown("Fire1"));

    }
    private void Move()
    {
        // transform.position = transform.position + movement * Time.deltaTime;
        rb.velocity = new Vector2(movement.x, movement.y);
    }

    private void Shooting()
    {
        crossHair.transform.position = aim;
        

        if (Input.GetButtonDown("Fire1"))
        {
            cross = new Vector2(aim.x - transform.position.x, aim.y - transform.position.y);
        }


    }
    private void Setallzero()
    {
        rb.velocity = Vector2.zero;
        movement = Vector3.zero;
        cross = Vector2.zero;
        crossHair.transform.position = rb.position;


    }
}


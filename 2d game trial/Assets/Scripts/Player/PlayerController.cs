using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    // Importing all the needed components
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


    // Locking and hiding the cursor at the start of the program
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = true;
        
    }
    // Update is called once per frame
    void Update()
    {
        // If the inventory is open, enabling the cursor
        if (inventory.activeInHierarchy)
        {
            Setallzero();
            Animations();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        // If the inventory is closed, disabling the cursor
        else if (!inventory.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            // Calling the functions below
            Inputs();
            Shooting();
            Animations();
            Move();
        }
    }
    // Function that gets the inputs from the user
    private void Inputs()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal") * 2, Input.GetAxisRaw("Vertical") * 2, 0f);
        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f);
        aim = aim + mouseMovement;
        aim.x = Mathf.Clamp(aim.x, transform.position.x + minaim.x, transform.position.x + maxaim.x);
        aim.y = Mathf.Clamp(aim.y, transform.position.y+ minaim.y, transform.position.y + maxaim.y);

    }
    // Function that animates the player depending on the inputs given by the user
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

    // Moving the player, depending on the inputs given by the user
    private void Move()
    {
        // transform.position = transform.position + movement * Time.deltaTime;
        rb.velocity = new Vector2(movement.x, movement.y);
    }

    // Changing the position of the crosshair, depending on the inputs given by the user
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


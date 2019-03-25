using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public GameObject crossHair;
    public Rigidbody2D rb;
    public Vector2 maxaim;
    public Vector2 minaim;

    public bool isattacking;



    Vector3 movement;
    Vector3 aim;
    Vector2 cross;
    



    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        
        Inputs();
        Animations();
        Move();
        Shooting();
        

    }

    private void Inputs()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal") * 2, Input.GetAxisRaw("Vertical") * 2, 0f);
        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f);
        aim = aim + mouseMovement;
        aim.x = Mathf.Clamp(aim.x, minaim.x, maxaim.x);
        aim.y = Mathf.Clamp(aim.y, minaim.x, maxaim.y);


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
}


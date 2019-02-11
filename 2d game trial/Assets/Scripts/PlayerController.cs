using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public GameObject crossHair;
    public Rigidbody2D rb;
    public Sprite Up;
    public Sprite Down;
    public Sprite Left;
    public Sprite Right;

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
        Shooting();
        Move();
            



    }

    private void Inputs()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal") * 2, Input.GetAxisRaw("Vertical") * 2, 0f);
        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f);
        aim = aim + mouseMovement;
    }

    private void Animations()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

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
            cross = new Vector2(aim.x - movement.x, aim.y - movement.y);
            if (cross.x > 0)
            {
                Debug.Log("Right");
                gameObject.GetComponent<SpriteRenderer>().sprite == Right;
                
            }
            if (cross.x < 0)
            {
                Debug.Log("Left");
                Debug.Log(cross.x);
            }
            if (cross.y > 0)
            {
                Debug.Log("Up");
                Debug.Log(cross.y);
            }
            if (cross.y < 0)
            {
                Debug.Log("Down");
                Debug.Log(cross.y);
            }
        }


    }
}


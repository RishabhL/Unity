using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public Transform Player;

    public float fowardForce = 2000f;
    public float sideForce = 500f;
    public float jumpForce = 300f;
	
    // Use this for initialization
	void Start ()
    {

        
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, fowardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1.5f)
        {
            FindObjectOfType<GameManager>().Endgame();

        }
        if (Input.GetKey("space"))
        {
            if (Player.position.y < 1.1)
            {
                Debug.Log(Player.position.y);
                rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
            }
        }
    }
}
    
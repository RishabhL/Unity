using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    private int damagedlt;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite HalfHeart;
    public Sprite ZeroHeart;



    // Start is called before the first frame update    
    void Start()
    {
        Initialise();
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))   
        {
            Rigidbody2D player = gameObject.GetComponent<Rigidbody2D>();
            damagedlt = collision.GetComponent<Enemy>().dodamage;
            if (player != null)
            {
                health -= damagedlt;
                if (health <= 0)
                {
                    Debug.Log("DED");
                }
            }
        }
    }
    void Initialise()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = FullHeart;
            Debug.Log(i);
        }

    }
}

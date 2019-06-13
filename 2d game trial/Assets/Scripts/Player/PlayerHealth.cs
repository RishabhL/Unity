using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour

{
    // Importing the needed components
    public int health = 5;
    private int damagedlt;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite HalfHeart;
    public Sprite ZeroHeart;

    private bool isattacking;


    // Start is called before the first frame update    
    void Start()
    {
        Initialise();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHearts();
        CheckHealth();
    } 
    
    // Creates the hearts as full at the start
    void Initialise()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = FullHeart;
        }

    }
    // Updating the heart every frame
    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i <= health - 1)
            {   
                hearts[i].sprite = FullHeart;

            }
            else if (i >= health)
            {

                hearts[i].sprite = ZeroHeart;
            }
            else
            {
                hearts[i].sprite = HalfHeart;
            }
        }


    }
    void CheckHealth()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health Pot"))
        {
            health += 1;
            Destroy(collision.gameObject);

        }
    }
}

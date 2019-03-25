using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCoins : MonoBehaviour
{
    private int Coins;
    public TextMeshProUGUI Cointext;

    // Start is called before the first frame update
    void Start()
    {
        Cointext = Cointext.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Cointext.text = Coins.ToString(); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Coins += 1;
            Destroy(collision.gameObject);

        }
    }
}

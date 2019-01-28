using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public int Crates = 5;

    public void TakeDamage(float amount) {

        health -= amount;

        if (health <= 0)
        {

            Death();
        }

    }

    void Death() {

        gameObject.SetActive(false);

    }

    void Update()
    {

    }



}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float knockback;
    public float knockTime;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();

            if (enemy != null)
            {
                
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockback;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockBk(enemy));
            }
            Enemy healthAccess = other.GetComponent<Enemy>();
            healthAccess.enemyHealth -= damage;
            
        }
    }

    private IEnumerator KnockBk(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
           

        }
    }
}

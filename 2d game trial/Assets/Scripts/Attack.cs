using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float knockback;
    public float knockTime;
    public bool knocked = false;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        knocked = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockback;
                knocked = true;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockBk(enemy));
            }
        }
    }
        
    private IEnumerator KnockBk(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            knocked = false;
            if (enemy != null)
            {
                enemy.velocity = new Vector2(0f, 0f);
            }
            
        }
    }
}

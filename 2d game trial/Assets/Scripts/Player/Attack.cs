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
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * knockback;
                knocked = true;
                hit.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockBk(hit));
            }
        }
    }
        
    private IEnumerator KnockBk(Rigidbody2D enemy)
    {
        yield return new WaitForSeconds(knockTime);
        if (enemy != null)
        {
            enemy.velocity = new Vector2(0f, 0f);
        }
        knocked = false;
    }
}

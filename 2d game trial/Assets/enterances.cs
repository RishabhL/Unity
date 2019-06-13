using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enterances : MonoBehaviour
{
    private bool iswasteland = true;
    public GameObject Wasteland_text;
    public GameObject HomeLand_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (iswasteland is true)
            {
                Debug.Log("Wasteland");
                Wasteland_text.SetActive(true);
                StartCoroutine("wait");
            }
            else if (iswasteland is false)
            {
                Debug.Log("Homeland");
                HomeLand_text.SetActive(true);
                StartCoroutine("wait2");
            }
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        Wasteland_text.SetActive(false);
        iswasteland = false;

    }
    IEnumerator wait2()
    {
        yield return new WaitForSeconds(2);
        HomeLand_text.SetActive(false);
        iswasteland = true;

    }
}

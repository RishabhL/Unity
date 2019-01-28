using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public GameObject Target1;
    public bool tg1c = false;
    public GameObject Target2;
    public bool tg2c = false;
    public GameObject Target3;
    public bool tg3c = false;
    public GameObject Target4;
    public bool tg4c = false;
    public GameObject Target5;
    public bool tg5c = false;
    public int CratesLeft = 5;
    public Text CLT;
    public GameObject StartT;
    public GameObject EndC;
    public Text EndT;
  
    public Text TimeC;
    private float theTime;
    private bool playing;
    public float speed = 1;


    void Start () {


        StartCoroutine(Wait());

	}
	
	// Update is called once per frame
	void Update () {

        CLT.text = CratesLeft.ToString();

        if (tg1c == false)
        {
            if (Target1.activeSelf == false)
            {
                CratesLeft -= 1;
                tg1c = true;
            }
        }

        if (tg2c == false)
        {
            if (Target2.activeSelf == false)
            {
                CratesLeft -= 1;
                tg2c = true;

            }
        }

        if (tg3c == false)
        {
            if (Target3.activeSelf == false)
            {
                CratesLeft -= 1;
                tg3c = true;

            }
        }

        if (tg4c == false)
        {
            if (Target4.activeSelf == false)
            {
                CratesLeft -= 1;
                tg4c = true;

            }
        }
        if (tg5c == false)
        {
            if (Target5.activeSelf == false)
            {
                CratesLeft -= 1;
                tg5c = true;

            }
        }

        if (CratesLeft == 0) 
        {
            Win();
        }

        if (playing == true)
        {
            theTime += Time.deltaTime * speed;
            string hours = Mathf.Floor((theTime % 216000) / 3600).ToString("00");
            string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
            string seconds = (theTime % 60).ToString("00");
            TimeC.text = hours + ":" + minutes + ":" + seconds;
        }



    }

    IEnumerator Wait()
    {
        StartT.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        StartT.SetActive(false);
        playing = true;

    }

    void Win()
    {
        playing = false;
        Debug.Log("Finished");
        EndT.text = TimeC.text;
        EndC.SetActive(true);

    }
}

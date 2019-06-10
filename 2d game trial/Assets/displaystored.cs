using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class displaystored : MonoBehaviour
{
    public Text TS;
    public Text Hours_Lived;
    public Text Coins;

    private int coins;
    private int days;
    private int hours;
    private string day;
    private int ts;
    private int daytotal;

    private GameObject storeddata;


    // Start is called before the first frame update
    void Start()
    {
        storeddata = GameObject.Find("DTStore");
        coins = storeddata.GetComponent<storedt>().coins;
        days = storeddata.GetComponent<storedt>().dayno;
        hours = storeddata.GetComponent<storedt>().timeno;
        day = storeddata.GetComponent<storedt>().timetxt;

        Coins.text = coins.ToString();
        if (day == "PM")
        {
            hours += 12;
        }
        Hours_Lived.text = hours.ToString();

        coins *= 3;
        ts = coins + hours;
        TS.text = ts.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

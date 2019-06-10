using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class storedt : MonoBehaviour
{
    public TextMeshProUGUI DayNum;
    public TextMeshProUGUI TimeNum;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI Coins;

    public string timetxt;
    public int timeno;
    public int dayno;
    public int coins;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        timetxt = TimeText.text;
        timeno = int.Parse(TimeNum.text);
        dayno = int.Parse(DayNum.text);
        coins = int.Parse(Coins.text);
    }

}

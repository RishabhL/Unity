using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class NightDay : MonoBehaviour
{
    public Tilemap TilemapCo;
    public Tilemap CollCo;

    public float co = 0.48f;
    public float currentco = 1f;
    private float timeChange = 0.2f;

    public bool day = true;
    public bool ischanging = false;
    public float WaitSeconds = 30f;

    public TextMeshProUGUI DayNum;
    public TextMeshProUGUI TimeNum;
    public TextMeshProUGUI TimeText;

    private float timefordatetimechange = 0f;


    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (day == true)
        {
            if (ischanging == false)
            {
                StartCoroutine(WaitDay());
            }
            else
            {
                ChangeDay();
            }
        }
        else
        {
            if (ischanging == false)
            {
                StartCoroutine(WaitNight());
            }
            else
            {
                ChangeNight();
            }
        }
        UpdateTime();

    }
    void ChangeDay()
    {
        if (currentco <= 1f)
        {
            if (Time.time >= timeChange)
            {
                currentco += 0.01f;
                TilemapCo.color = new Color(currentco, currentco, currentco);
                CollCo.color = new Color(currentco, currentco, currentco);
                timeChange = Time.time + 1f;
            }
        }
        else
        {
            day = true;
            ischanging = false;
        }
    }
    void ChangeNight()
    {
        if (currentco >= co)
        {
            if (Time.time >= timeChange)
            {
                currentco -= 0.01f;
                TilemapCo.color = new Color(currentco, currentco, currentco);
                CollCo.color = new Color(currentco, currentco, currentco);
                timeChange = Time.time + 1f;
            }
        }
        else
        {
            day = false;
            ischanging = false;
        }
    }
    public IEnumerator WaitDay()
    {
        yield return new WaitForSecondsRealtime(WaitSeconds);
        day = false;
        ischanging = true;
    }
    public IEnumerator WaitNight()
    {
        yield return new WaitForSecondsRealtime(WaitSeconds);
        day = true;
        ischanging = true;
    }
    void UpdateTime()
    {
        if (Time.time >= timefordatetimechange)
        {
            int num = int.Parse(TimeNum.text);
            if (num == 12)
            {
                if (TimeText.text == "PM")
                {
                    int daynum = int.Parse(DayNum.text);
                    daynum += 1;
                    DayNum.text = daynum.ToString();
                    TimeText.text = "AM";
                }
                else if (TimeText.text == "AM")
                {
                    TimeText.text = "PM";
                }
                TimeNum.text = "1";
            }
            else if (num != 12)
            {
                num += 1;
                TimeNum.text = num.ToString();
            }
            timefordatetimechange = Time.time + 30f;
        }
    }
}

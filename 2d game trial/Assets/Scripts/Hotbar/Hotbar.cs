using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,

     };
    private List<Transform> hslots = new List<Transform>();

    public List<Item> items = new List<Item>(7);

    public static Hotbar instance;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitialiseHSlots();
    }
     
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i ++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                int numberPressed = i;
                int currentPressed = numberPressed;
                numberPressed = i + 1;
                Debug.Log(numberPressed);
                SetActiveHSlot(hslots[i]);
                
            }
            
        }
    }
    void InitialiseHSlots()
    {
        for (int n = 0; n < transform.GetChild(0).childCount; n++)
        {
            hslots.Add(transform.GetChild(0).GetChild(n).GetChild(0).transform);
        }
    }
    void SetActiveHSlot(Transform Hslot)
    {
        for (int n = 0; n < transform.GetChild(0).childCount; n++)
        {
            hslots[n].GetComponent<Image>().color = new Color(255, 255, 255);
        }
        Hslot.GetComponent<Image>().color = new Color(255, 255, 0);

    }
}

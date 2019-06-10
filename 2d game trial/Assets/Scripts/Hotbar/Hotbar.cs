using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

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

    public Item currentequipped = null;

    public Animator playeranimator;

    public AnimatorOverrideController spear;
    public AnimatorOverrideController axe;
    public RuntimeAnimatorController playeranimator2;


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
        for (int i = 0; i < transform.childCount; i ++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                int numberPressed = i;
                int currentPressed = numberPressed;
                numberPressed = i + 1;
                SetActiveHSlot(hslots[i]);
                currentequipped = items[i];
                Usecurrent();
            }
            
        }
    }
    void InitialiseHSlots()
    {
        for (int n = 0; n < transform.childCount; n++)
        {
            hslots.Add(transform.GetChild(n).GetChild(0).transform);
        }
    }
    void SetActiveHSlot(Transform Hslot)
    {
        for (int n = 0; n < transform.childCount; n++)
        {
            hslots[n].GetComponent<Image>().color = new Color(255, 255, 255);
        }
        Hslot.GetComponent<Image>().color = new Color(255, 255, 0);

    }
    void Usecurrent()
    {
        if (currentequipped is WeaponItem)
        {
            if (currentequipped.Itemname == "Spear")
            {
                Debug.Log("Spear equipped");
                playeranimator.runtimeAnimatorController = spear as RuntimeAnimatorController;

            }
            if (currentequipped.Itemname == "Axe")
            {
                Debug.Log("Axe equipped");
                playeranimator.runtimeAnimatorController = axe as RuntimeAnimatorController;

            }

        }
        else if (currentequipped is null)
        {
            Debug.Log("Nothing equipped");
            playeranimator.runtimeAnimatorController = playeranimator2;
        }
    }
}

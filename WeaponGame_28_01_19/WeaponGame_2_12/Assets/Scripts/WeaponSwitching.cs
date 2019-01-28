using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    public int selectedWeapon = 0;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public GameObject crosshair;
    public Animator animator;
    private float normalFOV;
    public Camera mainCamera;

    // Use this for initialization
    void Start ()
    {
        SelectWeapon();
        normalFOV = mainCamera.fieldOfView;
    }
	
	// Update is called once per frame
	void Update () {

        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                if (scopeOverlay.activeSelf)
                {
                    ResetScope();
                }
                selectedWeapon++;
                
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                if (scopeOverlay.activeSelf)
                {
                    ResetScope();
                }
                selectedWeapon--;
                
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (scopeOverlay.activeSelf)
            {
                ResetScope();
            }
            selectedWeapon = 0;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            if (scopeOverlay.activeSelf)
            {
                ResetScope();
            }
            selectedWeapon = 1;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            if (scopeOverlay.activeSelf)
            {
                ResetScope();
            }
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            if (scopeOverlay.activeSelf)
            {
                ResetScope();
            }
            selectedWeapon = 3;
        }


        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);

            i++;

        }
    }

    void ResetScope()
    {
        mainCamera.fieldOfView = normalFOV;
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        crosshair.SetActive(true);
        animator.SetBool("Scoped", false);
        return;


    }

}

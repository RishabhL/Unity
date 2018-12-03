using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour {

    public Animator animator;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public GameObject crosshair;
    public Camera mainCamera;
    private bool isScoped = false;
    public bool activeSelf;

    public float scopedFOV = 15f;
    private float normalFOV;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (activeSelf)
                isScoped = !isScoped;
                animator.SetBool("Scoped", isScoped);

                if (isScoped)
                    StartCoroutine(OnScoped());
                else
                    OnUnscoped();
        }
    }

    
    void OnUnscoped()
    { 
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        crosshair.SetActive(true);

        mainCamera.fieldOfView = normalFOV;
    }
    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f);
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        crosshair.SetActive(false);

        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 150f;
    public float GunForce = 60f;
    public float FireRate = 15f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Text CurrentAmmoTxt;
    public Text MaxAmmoTxt;

    public Animator animator;

    public Camera Cam;
    public ParticleSystem muzzleFlash;
    // public GameObject impactEffect;

    private float nextTimetoFire = 0f;

    // Update is called once per frame
    void Start()
    {
        currentAmmo = maxAmmo;

    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }


    void Update ()
    {
        CurrentAmmoTxt.text = currentAmmo.ToString();
        MaxAmmoTxt.text = maxAmmo.ToString();

        if (isReloading)
        {
            return;
        }


        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }


        if (Input.GetButton("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / FireRate;
            Shoot();
        }
        
	}

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading..");

        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        currentAmmo = maxAmmo;
        isReloading = false;



    }

    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);


            Target target = hit.transform.GetComponent<Target>();
            if (target != null) {
                target.TakeDamage(damage);

            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * GunForce);
            }

            // Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }     
    }
}

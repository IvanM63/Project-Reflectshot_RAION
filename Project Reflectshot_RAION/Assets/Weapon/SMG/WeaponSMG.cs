using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSMG : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float timeBetweenShot;
    public float startTimeBetweenShot;

    //Ammo and Reload
    public int maxAmmo = 30;
    private int currentAmmo;
    public float reloadTime = 2f;
    private bool isReloading;

    private void Start() {
        currentAmmo = maxAmmo;
    }

    private void OnEnable() {
        isReloading = false;
    }

    void Update()
    {
        if(isReloading) {
            return;
        }

        if(currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine(Reload());
            return;
        }

        if(timeBetweenShot <= 0 )
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
                timeBetweenShot = startTimeBetweenShot;
            }
        } else
        {
            timeBetweenShot -= Time.deltaTime;
        }      
    }

    void Shoot()
    {
        currentAmmo--;
        //Tembak menembak
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator Reload() {
        isReloading = true;
        Debug.Log("RELOADING........");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}

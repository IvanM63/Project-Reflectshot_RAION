using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float timeBetweenShot;
    public float startTimeBetweenShot;


    void Update()
    {
        if(timeBetweenShot <= 0 )
        {
            if (Input.GetButtonDown("Fire1"))
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
        //Tembak menembak
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

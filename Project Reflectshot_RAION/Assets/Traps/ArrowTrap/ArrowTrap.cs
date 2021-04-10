using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public Transform firePoint;
    public float spawnTime = 3f;
    public GameObject Arrow;

    void Start()
    {
        InvokeRepeating("arrowShoot", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void arrowShoot() {
        Instantiate(Arrow, firePoint.position, firePoint.rotation);
    }
}

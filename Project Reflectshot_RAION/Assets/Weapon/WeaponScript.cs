using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private int totalWeapons = 1;
    private int currentWeaponIndex;

    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentWeapon;


    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i<totalWeapons;i++) {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        currentWeapon = guns[0];
        currentWeaponIndex = 0;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
            //Change Weapon    
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                if(currentWeaponIndex > 1) {
                    currentWeaponIndex = 0;
                }
                guns[currentWeaponIndex].SetActive(true);
                currentWeapon = guns[currentWeaponIndex];
            
        }
    }
}

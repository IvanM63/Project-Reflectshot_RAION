using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathEff;

    public int health = 100;

    public void takeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Belum jadi
    //ini kalo butuh animasi meninggal
    void Die()
    {
        Instantiate(deathEff, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}

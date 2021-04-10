using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathEff;

    public int health = 100;

    public float force;
    public int damageExplode;
    public float fieldOfImpact;
    public LayerMask LayerToHit;

    public void takeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
            explode();
        }
    }

    //Belum jadi
    //ini kalo butuh animasi meninggal
    void Die()
    {
        Instantiate(deathEff, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void explode() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);
        foreach (Collider2D nearbyObject in colliders) {
            Rigidbody2D rbo = nearbyObject.GetComponent<Rigidbody2D>();
            if (rbo != null) {
                Vector2 direction = rbo.transform.position - transform.position;
                rbo.AddForce(direction.normalized * force);
            }
            if (nearbyObject.CompareTag("Player")) {
                nearbyObject.GetComponent<Player>().takeDamage(damageExplode);
            }
            if (nearbyObject.CompareTag("Enemy")) {
                nearbyObject.GetComponent<Enemy>().takeDamage(damageExplode);
            }

        }
    }


}

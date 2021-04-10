using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float fieldOfImpact;
    public float force;
    public int damage;
    public LayerMask LayerToHit;
    private Rigidbody2D rb;

    public int health = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
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
                nearbyObject.GetComponent<Player>().takeDamage(damage / 4);
            }
            if (nearbyObject.CompareTag("Enemy")) {
                nearbyObject.GetComponent<Enemy>().takeDamage(damage);
            }

        }
    }

    public void takeDamage(int takedamage) {
        health -= takedamage;
        if (health <= 0) {
            explode();
            Destroy(gameObject); 
        }
    }
}

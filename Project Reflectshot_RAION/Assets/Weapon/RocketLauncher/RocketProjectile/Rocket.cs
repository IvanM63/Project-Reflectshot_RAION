using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Rigidbody2D rb;
    public LayerMask whatIsSolid;
    public float bulletSpeed = 10f;
    public int damage = 40;
    public float lifeTime = 1.5f;
    public float distance = 0.5f;

    //Tambahan
    public float fieldOfImpact;
    public float force;
    public LayerMask LayerToHit;

    void Start() {
        Invoke("DestroyProjectile", lifeTime);
        rb.velocity = transform.right * bulletSpeed;
    }

    private void Update() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null) {
            Explode();
            if (hitInfo.collider.CompareTag("Enemy")) {
                hitInfo.collider.GetComponent<Enemy>().takeDamage(damage);           
            }           
            DestroyProjectile();
        }
    }

    void DestroyProjectile() {
        Destroy(gameObject);
    }

    void Explode() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit); 

        foreach (Collider2D nearbyObject in colliders) {
            Rigidbody2D rbo = nearbyObject.GetComponent<Rigidbody2D>();           
            if(rbo != null) {
                Vector2 direction = nearbyObject.transform.position - transform.position;
                rbo.AddForce(direction.normalized * force); 
            }           
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }
}

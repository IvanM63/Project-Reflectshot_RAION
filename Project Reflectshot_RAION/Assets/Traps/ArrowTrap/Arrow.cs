using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    public LayerMask whatIsSolid;
    public float arrowSpeed = 10f;
    public int damage = 20;
    public float lifeTime = 15;
    public float distance = 0.05f;

    void Start() {
        Invoke("DestroyProjectile", lifeTime);
        rb.velocity = transform.right * arrowSpeed;
    }

    private void Update() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Player")) {
                hitInfo.collider.GetComponent<Player>().takeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Barrel")) {
                hitInfo.collider.GetComponent<Barrel>().takeDamage(damage);
            }
            DestroyProjectile();
        }
    }

    void DestroyProjectile() {
        Destroy(gameObject);
    }
}

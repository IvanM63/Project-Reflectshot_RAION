using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public LayerMask whatIsSolid;
    public float bulletSpeed = 10f;
    public int damage = 40;
    public float lifeTime = 1.5f;
    public float distance = 0.5f;

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        rb.velocity = transform.right * bulletSpeed;
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().takeDamage(damage);
            }
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    

}
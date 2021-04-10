using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    public int maxHealth = 100;
    public int currentHealth;

    public int maxShield = 100;
    public int currentShield;

    public HealthBarScript healthbar;
    public ShieldBarScript shieldBar;

    private Coroutine regen;

    //Buat Invincible
    Color p;
    Renderer render;

    public float knockbackForce = 500f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Set darah dan shield awal
        currentHealth = maxHealth;
        currentShield = maxShield;

        healthbar.setMaxHealth(maxHealth);
        shieldBar.setMaxShield(maxShield);

        //buat Invincible, opacity diturunin kalo kena hit
        render = GetComponent<Renderer>();
        p = render.material.color;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("StartMenu");
        }

        if(currentHealth <= 0) {
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void takeDamage(int damage) {
        if(currentShield > 0) {
            if(currentShield - damage < 0) {
                int shieldLeft = damage - currentShield;
                currentShield = 0;
                currentHealth -= shieldLeft;
                healthbar.setHealth(currentHealth);
            } else {
                currentShield -= damage;
            }
            shieldBar.setShield(currentShield);

            if(regen != null) {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(shieldRegen());
        } else {
            currentHealth -= damage;
            healthbar.setHealth(currentHealth);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Rigidbody2D rbo = collision.rigidbody;
        if (collision.gameObject.tag.Equals("Enemy")) {
            takeDamage(35);
            StartCoroutine(getInvulnerable());

            Vector2 direction = transform.position - rbo.transform.position;
            rb.AddForce(direction * knockbackForce);
        } 
    }

     private void OnTriggerEnter2D(Collider2D collision) {
        Rigidbody2D rbo = collision.GetComponent<Rigidbody2D>();
        if (collision.gameObject.CompareTag("Lava")) {
            takeDamage(50);
            StartCoroutine(getInvulnerable());

            Vector2 direction = transform.position - rbo.transform.position;
            rb.AddForce(direction * knockbackForce);
        }
        if(collision.gameObject.CompareTag("Cermin")) {
            SceneManager.LoadScene("EndGameScreen");
        }
    }



    IEnumerator shieldRegen() {
        yield return new WaitForSeconds(3f);

        while(currentShield < maxShield) {
            currentShield += maxShield / 25;
            shieldBar.setShield(currentShield);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator getInvulnerable() {
        Physics2D.IgnoreLayerCollision(3, 7, true);
        Physics2D.IgnoreLayerCollision(3, 10, true);
        p.a = 0.5f;
        render.material.color = p;
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(3, 7, false);
        Physics2D.IgnoreLayerCollision(3, 10, false);
        p.a = 1f;
        render.material.color = p;
    }


}

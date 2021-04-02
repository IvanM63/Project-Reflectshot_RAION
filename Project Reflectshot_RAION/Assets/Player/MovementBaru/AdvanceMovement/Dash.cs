using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    Rigidbody2D rb;
    public float dashSpeed;
    public float startDashTime;
    private float tempDashTime;
    private float doubleTapTime;
    KeyCode lastKey;

    private int arah;

    private bool isDashing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tempDashTime = startDashTime;
    }

    void Update()
    {
        if (arah == 0)
        {
            
            if (Input.GetKeyDown(KeyCode.D)) {
                if (doubleTapTime > Time.time && lastKey == KeyCode.D) {
                    arah = 2;
                    StartCoroutine(Dashh());
                } else {
                    doubleTapTime = Time.time + 0.5f;
                }
                lastKey = KeyCode.D;
            }

            //Buat Dash kiri
            if (Input.GetKeyDown(KeyCode.A)) {
                if (doubleTapTime > Time.time && lastKey == KeyCode.A) {
                    arah = 1;
                    StartCoroutine(Dashh());
                } else {
                    doubleTapTime = Time.time + 0.5f;
                }
                lastKey = KeyCode.A;
            }           

        } else {
            if(tempDashTime <= 0) {
                arah = 0;
                tempDashTime = startDashTime;
                rb.velocity = Vector2.zero;
            } else {
                tempDashTime -= Time.deltaTime;

                if(arah == 1) {
                    rb.velocity = Vector2.left * dashSpeed;
                } else if (arah == 2) {
                    rb.velocity = Vector2.right * dashSpeed;
                } 
            }
        }    
    }

    IEnumerator Dashh() {
        isDashing = true;
        yield return new WaitForSeconds(0.1f);
        isDashing = false;
    }

    public bool getIsDashing() {
        return isDashing;
    }

}

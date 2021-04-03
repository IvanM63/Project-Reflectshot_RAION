using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSlide : MonoBehaviour
{

    public CharacterMovement player;

    private Rigidbody2D rb;

    public BoxCollider2D normalCollys;
    public BoxCollider2D slideCollys;

    public float slideSpeed;

    public bool isSliding = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            Slide();
        }
    }

    void Slide() {
        isSliding = true;

        normalCollys.enabled = false;
        slideCollys.enabled = true;

        if(player.facingRight) {
            rb.AddForce(Vector2.right * slideSpeed);
        } else {
            rb.AddForce(Vector2.left * slideSpeed);
        }
        StartCoroutine(stopSliding());
    }

    IEnumerator stopSliding() {

        yield return new WaitForSeconds(1f);

        normalCollys.enabled = true;
        slideCollys.enabled = false;
        isSliding = false;
    }

    public bool Sliding() {
        return isSliding;
    }
    
    public float getSlideSpeed() {
        return slideSpeed;
    }

}

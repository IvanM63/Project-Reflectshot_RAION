using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovC : MonoBehaviour
{
    private PlayerBase playerBase;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] private LayerMask platformLayerMask;

    public float jumpVelocity = 100f;
    public float runSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        playerBase = gameObject.GetComponent<PlayerBase>();
        rb = transform.GetComponent<Rigidbody2D>();
        bc = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

        
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
        } else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(+runSpeed, rb.velocity.y);
            } else
            {
                //ga mencet apapun
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

    }

    private bool isGrounded()
    {
        RaycastHit2D racast = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
        return racast.collider != null;
    }
}

using System.Collections;
using UnityEngine;



public class CharacterMovement : MonoBehaviour
{
    public Animator animator;

    private Rigidbody2D rb;
    //Atribut untuk ngatur movement
    public float moveSpeed = 10f;
    public float jumpForce = 5f;

    //Atribut untuk cek nyentuh tanah atau tidak
    public bool isGrounded;
    public Transform checkGround;
    public float checkRadius;
    public LayerMask whatIsGround;
    //Tambahan 
    public bool facingRight = true;

    //Buat Lompat + extra jump
    private int extraJump;
    public int extraJumpValue;

    //LinearDrag
    public float dragAsli;

    public float moveInput;

    void Start()
    {
        //Masukin Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        extraJump = extraJumpValue;
    }

    
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, checkRadius, whatIsGround);

        //Gerak kanan kiri
        Movement();
    }

    private void Update() {
        //Cek buat tambahin lompatan
        if (isGrounded) {
            extraJump = extraJumpValue;
            rb.drag = dragAsli;
        } else {
            rb.drag = 1f;
        }

        //Untuk Lompat
        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            /*rb.velocity += Vector2.up * jumpForce;*/
            extraJump--;
            animator.SetBool("isJumping", true);
        } else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            /*rb.velocity += Vector2.up * jumpForce;*/
            animator.SetBool("isJumping", true);
        }

    }

        void Flip() {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);

        /*Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;*/
        }

    void Movement() {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(xInput));

        //Ubah posisi karakter
        if(xInput > 0 && facingRight == false) {
            Flip();
        } else if (xInput < 0 && facingRight == true) {
            Flip();
        }

        float xForce = xInput * moveSpeed * Time.deltaTime;

        Vector2 force = new Vector2(xForce, 0);

        rb.AddForce(force);
    }
}
    

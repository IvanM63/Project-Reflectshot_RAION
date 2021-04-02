using System.Collections;
using UnityEngine;



public class CharacterMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    //Atribut untuk ngatur movement
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    private float moveInput;
    private float newMoveSpeed;

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

    void Start()
    {
        //Masukin Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        extraJump = extraJumpValue;
        newMoveSpeed = moveSpeed;
    }

    
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, checkRadius, whatIsGround);

        //Gerak kanan kiri

        if (!GetComponent<Dash>().getIsDashing() && !GetComponent<playerSlide>().Sliding()) {
            moveInput = Input.GetAxis("Horizontal") * newMoveSpeed;
            rb.velocity = new Vector2(moveInput, rb.velocity.y);
        }
        

        //Ubah posisi karakter
        if(moveInput > 0 && facingRight == false)
        {
            Flip();
        } else if (moveInput < 0 && facingRight == true)
        {
            Flip();
        }
    }

    private void Update() {
        //Cek buat tambahin lompatan
        if (isGrounded == true) {
            extraJump = extraJumpValue;
        }

        //Untuk Lompat
        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0) {
            rb.velocity += Vector2.up * jumpForce;
            extraJump--;
        } else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true) {
            rb.velocity += Vector2.up * jumpForce;
        }

        //efeksliding
        if (GetComponent<playerSlide>().Sliding()) {

            newMoveSpeed = moveSpeed + GetComponent<playerSlide>().getSlideSpeed() / 50;
        }

        if (Input.GetAxis("Horizontal") == 0) {
            newMoveSpeed = moveSpeed; ;
        }

        if (isGrounded && newMoveSpeed > moveSpeed) {
            newMoveSpeed -= 0.1f;
        }

    }

        void Flip() {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);

        /*Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;*/
        }
}
    

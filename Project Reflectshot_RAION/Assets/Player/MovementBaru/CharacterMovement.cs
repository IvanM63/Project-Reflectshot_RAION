
using UnityEngine;



public class CharacterMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    //Atribut untuk ngatur movement
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    private float moveInput;

    //Atribut untuk cek nyentuh tanah atau tidak
    private bool isGrounded;
    public Transform checkGround;
    public float checkRadius;
    public LayerMask whatIsGround;
    //Tambahan 
    private bool facingRight = true;

    //Buat Lompat + extra jump
    private int extraJump;
    public int extraJumpValue;

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
        moveInput = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(moveInput, rb.velocity.y);

        //Ubah posisi karakter
        if(moveInput > 0 && facingRight == false)
        {
            Flip();
        } else if (moveInput < 0 && facingRight == true)
        {
            Flip();
        }
    }

    private void Update()
    {
        //Cek buat tambahin lompatan
        if(isGrounded == true)
        {
            extraJump = extraJumpValue;
        }

        //Untuk Lompat
        if(Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        } else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);

        /*Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;*/
    }
}

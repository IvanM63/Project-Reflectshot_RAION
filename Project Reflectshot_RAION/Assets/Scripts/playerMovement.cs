using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float jumpSpeed = 5f;
    private float movement = 0f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if(movement != 0f)
        {
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        }
        
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}

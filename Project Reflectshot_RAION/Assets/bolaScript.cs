using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolaScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)) {
            rb.AddForce(transform.right * speed);
        } else if (Input.GetKeyDown(KeyCode.A)) {
            rb.AddForce(transform.right * -speed);
        }
    }
}

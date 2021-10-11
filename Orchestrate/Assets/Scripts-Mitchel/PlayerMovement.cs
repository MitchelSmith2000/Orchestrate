using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("This is the speed at which the player moves. It is very unclear how this unit is measured in, so arbitrary values are used for it.")]
    public float speed = 1;
    public float jumpForce = 1;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
        //Vector3 move = transform.right * x + transform.forward * z;
        // controller.SimpleMove(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}

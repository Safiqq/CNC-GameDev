using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private float maxJump = 2;
    private float countJump = 0;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && countJump < maxJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            countJump++;
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.layer == 6)
        {
            countJump = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

}
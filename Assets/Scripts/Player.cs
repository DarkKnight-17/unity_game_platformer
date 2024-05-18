using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update


    public float speed;

    public float jump;
    public LayerMask ground;
    private Rigidbody2D rigidBody;
    private Collider2D playerCollider;
    private Animator animator;

    
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();    
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);

        bool isGrounded = Physics2D.IsTouchingLayers(playerCollider, ground);


    
      if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {

            if (isGrounded)
            {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump);
            }
        }
            animator.SetBool("Grounded", isGrounded);

        
    }
}

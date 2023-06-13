using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool isJumping = false;
    private Rigidbody2D rb;
    public Animator anim;

    public GameObject PauseMenu;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(moveX));
        // Move the player horizontally
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if(!PauseMenu.activeInHierarchy)
        {
            // Flip the player sprite if moving in the opposite direction
            if (moveX < 0)
                transform.localScale = new Vector3(-5, 5, 1);
            else if (moveX > 0)
                transform.localScale = new Vector3(5, 5, 1);

            // Jumping
            if (Input.GetButtonDown("Jump") && isJumping == false )
            {
                rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
                isJumping = true;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is touching the ground
        if (collision.gameObject.CompareTag("Ground"))
            isJumping = false;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}






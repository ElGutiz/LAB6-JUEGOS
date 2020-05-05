using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int score;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            Jump();

        UnityEngine.Vector3 newScale = transform.localScale;
        if (Input.GetAxis("Horizontal") > 0.0f)
            newScale.x = 0.8f;
        else if (Input.GetAxis("Horizontal") < 0.0f)
            newScale.x = -0.8f;

        transform.localScale = newScale;

    }

    private void FixedUpdate()
    {

        if (rb2d)
        {
            rb2d.AddForce(new UnityEngine.Vector2(Input.GetAxis("Horizontal") * 10, 0));
        }

    }

    void Jump()
    {
        if (rb2d)
            if (Mathf.Abs(rb2d.velocity.y) < 0.05f)
                rb2d.AddForce(new UnityEngine.Vector2(0, 8), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            GetComponent<SpriteRenderer>().material.color = Color.red;
            score = score + 1;
        }
        else
        {
            if (collision.gameObject.CompareTag("Enemy") && score !=1)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Enemy") && score == 1)
        {
            Destroy(collision.gameObject);
        }
    }
}

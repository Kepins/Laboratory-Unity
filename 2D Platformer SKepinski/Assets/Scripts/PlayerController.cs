using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement parameters")]
    [Range(0.01f, 20.0f)][SerializeField] private float moveSpeed = 0.1f; // moving speed of the player
    [Range(0.01f, 20.0f)][SerializeField] private float jumpForce = 6.0f; // jump force of the player

    private Rigidbody2D rigidbody; // jump force of the player

    public LayerMask groundLayer;

    private const float rayLength = 1.6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            //rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Jump();
        }

        //Debug.DrawRay(transform.position, rayLength * Vector3.down, Color.white, 1.0f, false);
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(this.transform.position, Vector2.down, rayLength, groundLayer.value);
    }

    private void Jump()
    {
        if (IsGrounded()) {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("jumping");
        }
    }
}

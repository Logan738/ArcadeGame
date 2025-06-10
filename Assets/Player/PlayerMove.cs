using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    public float movespeed = 5f;
    public float Rotationspeed = 2f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(moveInputX, moveInputY);
        moveDirection.Normalize();

        rb2d.velocity = moveDirection * movespeed;

    }
}

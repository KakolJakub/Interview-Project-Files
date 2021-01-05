using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{    
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rBody;

    private float horizontal;
    private float vertical;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(vertical == 0)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        if(horizontal == 0)
        {
            vertical = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Up,
    Right,
    Down,
    Left
}

public class PlayerMovement : MonoBehaviour
{    
    public Direction PlayerDirection {get { return currentDirection; }}
    private Direction currentDirection;

    [SerializeField] private float moveSpeed;
    [SerializeField] Animator animator;

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
            animator.SetFloat("horizontalMove", horizontal);
            animator.SetFloat("verticalMove", 0);
        }

        if(horizontal == 0)
        {
            vertical = Input.GetAxisRaw("Vertical");
            animator.SetFloat("verticalMove", vertical);
            animator.SetFloat("horizontalMove", 0);
        }

        if(vertical != 0 || horizontal !=0)
        {
            UpdateDirection();
        }
    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }

    void UpdateDirection()
    {
        if(vertical > 0)
        {
            currentDirection = Direction.Up;
        }
        if(vertical < 0)
        {
            currentDirection = Direction.Down;
        }
        if(horizontal > 0)
        {
            currentDirection = Direction.Right;
        }
        if(horizontal < 0)
        {
            currentDirection = Direction.Left;
        }
    }
}

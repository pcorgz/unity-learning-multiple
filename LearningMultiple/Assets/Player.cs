using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float upVelocity = 0f;

    private Rigidbody2D rb;
    private bool goingUp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        goingUp = Input.GetMouseButton (0);
    }

    private void FixedUpdate()
    {
        if (goingUp)
        {
            rb.velocity = Vector2.up * upVelocity * Time.deltaTime;
        }
    }
}

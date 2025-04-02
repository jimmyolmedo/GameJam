using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class RigidbodyMovement : MonoBehaviour
{
    [SerializeField] float speed = 200;
    Vector2 move;
    Rigidbody2D rb;

    private void OnEnable()
    {
        InputManager.OnMove += Move;
    }

    private void OnDisable()
    {
        InputManager.OnMove -= Move;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2 (move.x, move.y) * speed * Time.deltaTime;
    }

    void Move(Vector2 _move)
    {
        move = _move;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed;
    Vector2 dir;
    Rigidbody2D rb;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        InitMovement();
    }
    private void InitMovement()
    {
        dir = player.position - transform.position;
        dir.Normalize();
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }
}

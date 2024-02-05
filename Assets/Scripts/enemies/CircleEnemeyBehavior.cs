using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemeyBehavior : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 dir;
    Transform player;
    Rigidbody2D rb;
    [SerializeField] LayerMask wall;
    [SerializeField] LayerMask ground;
    CircleCollider2D col;
    Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<CircleCollider2D>();
        StartCoroutine(ofa7());
        findDirctionPlayer();
        setSpeed();
    }
    private void Update()
    {
        HandleAnimation();
    }

    void findDirctionPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dir = player.transform.position - transform.position;
    }
    void setSpeed()
    {
        if(dir.x >= 0)
        {
            rb.velocity = Vector2.right * speed;
        }
        else
        {
            rb.velocity = Vector2.left * speed;
        }
    }

    private void HandleAnimation()
    {
        bool ground = Physics2D.CircleCast(col.bounds.center, col.radius, Vector2.down, 0.1f, this.ground);
        bool wall = Physics2D.CircleCast(col.bounds.center, col.radius, Vector2.left, 0.1f, this.wall)
            || Physics2D.CircleCast(col.bounds.center, col.radius, Vector2.right, 0.1f, this.wall);
        if (wall)
        {
            anim.SetTrigger("HitWall");
        }
        if (ground)
        {
            anim.SetTrigger("HitGround");
        }

    }
    IEnumerator ofa7()
    {
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.5f);
        rb.gravityScale = 1;
    }

}

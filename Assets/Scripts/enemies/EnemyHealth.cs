using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxhealth;
    float health;
    Animator anim;
    Rigidbody2D rb;
    private void Start()
    {
        health = maxhealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player bullet")
        {
            TakeDamage(collision.gameObject.GetComponent<Damage>().getDamage());
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            anim.SetTrigger("isDeath");
        }
    }
    void destroyGameObject()
    {
        Destroy(gameObject);
    }
    void makeStaticBody()
    {
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}

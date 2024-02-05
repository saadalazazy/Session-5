using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    float playerHealth;

    private void Start()
    {
        playerHealth = maxHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy Bullet")
        {
            DamagePlayer(collision.gameObject.GetComponent<Damage>().getDamage());
            Destroy(collision.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DamagePlayer(collision.gameObject.GetComponent<Damage>().getDamage());
            Destroy(collision.gameObject);
        }
    }
    private void DamagePlayer(float damage)
    {
        playerHealth -= damage;
        if (playerHealth < 0)
        {
            playerHealth = 0;
            Debug.Log("isDead");
        }
    }
}

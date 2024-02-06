using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    float playerHealth;
    Animator anim;
    Rigidbody2D rb;
    bool isDie;
    [SerializeField] Slider healthBar;
    private void Start()
    {
        playerHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy Bullet")
        {
            DamagePlayer(collision.gameObject.GetComponent<Damage>().getDamage());
            CameraShake.instance.setCameraShake(5, 0.5f);
            Destroy(collision.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DamagePlayer(collision.gameObject.GetComponent<Damage>().getDamage());
            CameraShake.instance.setCameraShake(5, 0.5f);
            Destroy(collision.gameObject);
        }
    }
    private void DamagePlayer(float damage)
    {
        playerHealth -= damage;
        healthBar.value = playerHealth / maxHealth;
        if (playerHealth <= 0 && !isDie)
        {
            isDie = true;
            playerHealth = 0;
            anim.SetLayerWeight(1, 0);
            anim.SetTrigger("die");
            rb.velocity = Vector3.zero;
            
            
        }
    }
}

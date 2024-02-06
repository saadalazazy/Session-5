using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLifeTime : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    [SerializeField] GameObject hitBulletEffect;
    private void Start()
    {
        StartCoroutine(destory());
    }

    IEnumerator destory()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
        Instantiate(hitBulletEffect, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(hitBulletEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

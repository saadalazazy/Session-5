using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifeTime : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    [SerializeField] GameObject hitBulletEffect;
    [SerializeField] GameObject instantiatBulletEffect;
    private void Start()
    {
        StartCoroutine(destory());
        Instantiate(instantiatBulletEffect, transform.position, Quaternion.identity);
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

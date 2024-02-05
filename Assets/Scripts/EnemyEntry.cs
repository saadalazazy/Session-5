using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntry : MonoBehaviour
{
    [SerializeField] bool down;
    [SerializeField] 
    Transform player;
    float dir;
    [SerializeField] float distance;
    Transform entryPos;
    [SerializeField] float speed;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        entryPos = transform;
        setDir();
    }
    private void Update()
    {
        entryMovment();
    }
    void setDir()
    {
        dir = player.position.x - transform.position.x;
    }
    void entryMovment()
    {
        if (!down)
        {
            if (dir >= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, entryPos.position + Vector3.right * distance, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, entryPos.position + Vector3.left * distance, speed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, entryPos.position + Vector3.down * distance, speed * Time.deltaTime);
        }

    }
    
}

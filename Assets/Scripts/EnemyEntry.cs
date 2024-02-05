using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyEntry : MonoBehaviour
{
    [SerializeField] bool down;
    [SerializeField] 
    Transform player;
    float dir;
    [SerializeField] float distance;
    Transform entryPos;
    [SerializeField] float speed;
    [SerializeField] UnityEvent start;
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
        Vector3 distenation;
        if (!down)
        {
            if (dir >= 0)
            {

               distenation= entryPos.position + Vector3.right * distance;
            }
            else
            {
                distenation = entryPos.position + Vector3.left * distance;
            }
        }
        else
        {
            distenation = entryPos.position + Vector3.down * distance;
        }
        transform.position = Vector3.MoveTowards(transform.position, distenation, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, distenation)<0.1f)
        {
            start.Invoke();
        }
    }
    
}

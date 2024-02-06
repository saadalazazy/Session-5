using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyEntry : MonoBehaviour
{
    [HideInInspector]public bool entryFinished;
    Transform player;
    float dir;
    Vector2 dis;
    Transform pos;
    [SerializeField] Vector2 distance;
    [SerializeField] float speed;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pos = transform;
        getDestination();
    }
    private void Update()
    {
        if(Vector3.Distance(transform.position , dis) > 0.01)
        {
            transform.position = Vector3.MoveTowards(transform.position, dis, speed * Time.deltaTime);
        }
        else
        {
            entryFinished = true;
            enabled = false;
        }
    }
    void getDestination()
    {
        dir = player.position.x - transform.position.x;
        if(dir >= 0)
        {
            dis = pos.position + Vector3.right * Random.Range(distance.x , distance.y);
        }
        else
        {
            dis = pos.position + Vector3.left * Random.Range(distance.x, distance.y);
        }
    }



}

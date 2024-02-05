using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(menuName = "Creat Wave" , fileName = "new Wave")]
public class WaveData : ScriptableObject
{
    public GameObject[] Enemies;
    [SerializeField] float timeBetweenEnemies;

    public float getCount()
    {
        return Enemies.Length;
    }
    public float getDuration()
    {
        return timeBetweenEnemies;
    }
}

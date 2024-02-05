using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManger : MonoBehaviour
{
    [SerializeField] WaveData[] waves;
    [SerializeField] float timeBetweenTwoWave;
    [SerializeField] Transform[] spawnerPoits;
    int currentWaveindex = 0;
    WaveData currentWave;
    bool waveFinished = false;

    private void Start()
    {
        StartCoroutine(WaveDelay(currentWaveindex));
    }
    private void Update()
    {
        if(waveFinished && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            currentWaveindex++;
            if (currentWaveindex < waves.Length)
            {
                waveFinished = false;
                StartCoroutine(WaveDelay(currentWaveindex));
            }
            
        }
    }
    IEnumerator WaveDelay(int index)
    {
        yield return new WaitForSeconds(timeBetweenTwoWave);
        StartCoroutine(nextWaveSpawn(currentWaveindex));
    }

    IEnumerator nextWaveSpawn(int index)
    {
        currentWave = waves[index];
        for(int i = 0; i < currentWave.getCount(); i++)
        {
            if (currentWave.Enemies[i].GetComponent<StarBehavior>() != null)
            {
                Instantiate(currentWave.Enemies[i], spawnerPoits[Random.Range(0, 2)].position, Quaternion.identity);
            }
            else if(currentWave.Enemies[i].GetComponent<CircleEnemeyBehavior>() != null)
            {
                Instantiate(currentWave.Enemies[i], spawnerPoits[Random.Range(2, 4)].position, Quaternion.identity);
            }
            else if(currentWave.Enemies[i].GetComponent<traingleEnemyBehavior>() != null)
            {
                Instantiate(currentWave.Enemies[i], spawnerPoits[Random.Range(4, 6)].position, Quaternion.identity);
            }
            else
            {
                Instantiate(currentWave.Enemies[i], spawnerPoits[Random.Range(6, 8)].position, Quaternion.identity);
            }
            Debug.Log(i);
            Debug.Log(currentWave.getCount() - 1);
            if (i == currentWave.getCount()-1)
            {
                waveFinished = true;
                Debug.Log(waveFinished);
                yield break;
            }

            yield return new WaitForSeconds(currentWave.getDuration());
        }
    }

}

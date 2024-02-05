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
        int randomIndex;
        for (int i = 0; i < currentWave.getCount(); i++)
        {
            if (currentWave.Enemies[i].GetComponent<StarBehavior>() != null)
            {
                randomIndex = Random.Range(0, 2);
                Instantiate(currentWave.Enemies[i], spawnerPoits[randomIndex].position, Quaternion.identity);
            }
            else if(currentWave.Enemies[i].GetComponent<CircleEnemeyBehavior>() != null)
            {
                randomIndex = Random.Range(2, 4);
                Instantiate(currentWave.Enemies[i], spawnerPoits[randomIndex].position, Quaternion.identity);
            }
            else if(currentWave.Enemies[i].GetComponent<traingleEnemyBehavior>() != null)
            {
                randomIndex = Random.Range(4, 6);
                Instantiate(currentWave.Enemies[i], spawnerPoits[randomIndex].position, Quaternion.identity);
            }
            else
            {
                randomIndex = Random.Range(6, 8);
                Instantiate(currentWave.Enemies[i], spawnerPoits[randomIndex].position, Quaternion.identity);
            }
            spawnerPoits[randomIndex].GetComponent<Animator>().SetTrigger("shoot");
            if (i == currentWave.getCount()-1)
            {
                waveFinished = true;
                yield break;
            }

            yield return new WaitForSeconds(currentWave.getDuration());
        }
    }

}

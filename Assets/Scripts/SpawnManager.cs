using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public enum spawnState {SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public Transform enemy;
        public int count;
        public float rate;
    }

    private int nextWave = 0;
    private float searchCountdown = 1f;
    

    public Wave[] waves;
    public Transform[] spawnPoints;
    public Text waveText;
    public GameObject particles;
    public spawnState state = spawnState.COUNTING;
    public float waveWait = 1f;
    public float waveCountdown;
    public static int waveCount;
    
    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.Log("No spawn points.");    
        }

        waveCountdown = waveWait;
        waveCount = 1;
        UpdateWave();
    }

    void Update()
    {
        if (state == spawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            } else
            {
                return;
            }
        }

        if (waveCountdown <= 0f)
        {
            if (state != spawnState.SPAWNING)
                StartCoroutine(SpawnWave(waves[nextWave]));
        } else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        state = spawnState.COUNTING;
        waveCountdown = waveWait;

        if (nextWave + 1 > waves.Length - 1)
            nextWave = 0;
        else
            nextWave++;
            waveCount++;
            UpdateWave();
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0)
        {
            searchCountdown = 1f;

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
                return false;
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = spawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            StartCoroutine(SpawnEnemy(_wave.enemy));
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = spawnState.WAITING;

        yield break;
    }

    IEnumerator SpawnEnemy(Transform _enemy)
    {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(particles, sp.position, sp.rotation);
        
        yield return new WaitForSeconds(1f);
        
        Instantiate(_enemy, sp.position, sp.rotation);
    }

    void UpdateWave()
    {
        waveText.text = "Wave " + waveCount.ToString();
    }
}

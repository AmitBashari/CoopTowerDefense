using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemySpawner : NetworkBehaviour
{
    public Transform WaveStartPoint;
    public GameObject FlowerPrefeb;
    public int NumberOfFlowers;
    public float TimeBetweenWaves = 5f;

    private float _countdown = 2f;
    private int _waveIndex = 0;
    private float _delayBetweenFlowers = 1f;

    public override void OnStartServer()
    {

    }

    private void Update()
    {
        if(_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = TimeBetweenWaves;
        }
        _countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        _waveIndex++;

        for (int i = 0; i < _waveIndex; i++)
        {
            if(_waveIndex <= 3)
            {
            SpawnFlower();
            yield return new WaitForSeconds(_delayBetweenFlowers);
            }
            else
            {
                break;
            }
        }
      
    }

    private void SpawnFlower()
    {
        for (int i = 0; i < NumberOfFlowers; i++)
        {
            Vector3 spawnPosition = WaveStartPoint.position;
            Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 0f);

            GameObject flower = (GameObject)Instantiate(FlowerPrefeb, spawnPosition, spawnRotation);
            NetworkServer.Spawn(flower);
        }
    }

}

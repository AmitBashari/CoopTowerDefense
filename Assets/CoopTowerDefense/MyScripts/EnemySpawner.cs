using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemySpawner : NetworkBehaviour

{
    public GameObject FlowerPrefeb;
    public int NumberOfFlowers;

    public override void OnStartServer()
    {
        for (int i = 0; i < NumberOfFlowers; i++)
        {
            Vector3 spawnPosition = new Vector3(1f, 1f, 1f);
            Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 0f);

            GameObject flower = (GameObject)Instantiate(FlowerPrefeb, spawnPosition, spawnRotation);
            NetworkServer.Spawn(flower);
        }
    }


}

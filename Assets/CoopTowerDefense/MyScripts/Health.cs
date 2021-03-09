using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Mirror;

public class Health : NetworkBehaviour
{
    public const int MaxHealth = 100;
    [SyncVar(hook = nameof(OnChangeHealth))] public int CurrentHealth = MaxHealth;
    public RectTransform HealthBar;
    public bool DestroyOnWet;

    private NetworkStartPosition[] _spawnPoints;

    private void Start()
    {
        if (isLocalPlayer)
        {
            _spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
    }

    public void GetWet(int amount)
    {
        if (!isServer)
        {
            return;
        }
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            if (DestroyOnWet)
            {
                Destroy(gameObject);
            }
            else
            {
                CurrentHealth = MaxHealth;
                RpcSpawn();
            }
        }

    }

    void OnChangeHealth(int currenthealth, int health)
    {
        HealthBar.sizeDelta = new Vector2(health * 2, HealthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcSpawn()
    {
        if (isLocalPlayer)
        {
            //transform.position = Vector3.zero;
            Vector3 spawnPoint = Vector3.zero;

            if(spawnPoint != null && _spawnPoints.Length > 0)
            {
                spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform.position;
            }
            transform.position = spawnPoint;
        }
    }
}

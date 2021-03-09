﻿using System.Collections;
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

    public void GetWet(int amount)
    {
        if (!isServer)
        {
            return;
        }
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Debug.Log("Fully Watered!");
        }

    }

    void OnChangeHealth(int currenthealth, int health)
    {
        HealthBar.sizeDelta = new Vector2(health * 2, HealthBar.sizeDelta.y);
        //CurrentHealth = health;
    }

}

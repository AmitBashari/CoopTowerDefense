using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public const int MaxHealth = 100;
    public int CurrentHealth = MaxHealth;
    public RectTransform HealthBar;

    public void GetWet(int amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Debug.Log("Fully Watered!");
        }

        HealthBar.sizeDelta = new Vector2(CurrentHealth * 2, HealthBar.sizeDelta.y);
    }

}

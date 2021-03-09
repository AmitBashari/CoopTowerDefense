using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBaloon : MonoBehaviour
{
    private int _wetAmount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.GetWet(_wetAmount);
        }

        Destroy(gameObject);
    }

}

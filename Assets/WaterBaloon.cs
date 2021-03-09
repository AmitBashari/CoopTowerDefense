using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBaloon : MonoBehaviour
{
    private void OnCollisionEnter()
    {
        Destroy(gameObject);
    }

}

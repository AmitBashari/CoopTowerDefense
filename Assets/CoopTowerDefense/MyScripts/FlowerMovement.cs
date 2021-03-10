using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMovement : MonoBehaviour
{
    public float Speed = 4f;

    private Transform _target;
    private int _wavePointIndex = 0;

    private void Start()
    {
        _target = Waypoints.Points[0];
    }

    private void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.5f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if(_wavePointIndex >= Waypoints.Points.Length - 1)
        {
            Destroy(gameObject);
        }
        _wavePointIndex++;
        _target = Waypoints.Points[_wavePointIndex];
    }
}

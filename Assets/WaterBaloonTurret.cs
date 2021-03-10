using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class WaterBaloonTurret : NetworkBehaviour
{
    private Transform _target;

    [Header ("Attributes")]

    public float FireRate = 1f;
    public float TurrentRange = 8f;
    private float _fireCountDown = 0f;
    //private float _shootVelocity = 6f;

    [Header("Unity Setup Fields")]
    public string FlowerTag = "Flower";
    public GameObject WaterBaloonPrefab;
    public Transform WaterBaloonSpawn;



    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] flowers = GameObject.FindGameObjectsWithTag(FlowerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearstFlower = null;
        foreach (GameObject flower in flowers)
        {
            float distanceToFlower = Vector3.Distance(transform.position, flower.transform.position);
            if(distanceToFlower < shortestDistance)
            {
                shortestDistance = distanceToFlower;
                nearstFlower = flower;
            }
        }

        if (nearstFlower != null && shortestDistance <= TurrentRange)
        {
            _target = nearstFlower.transform;
        }
        else
        {
            _target = null;
        }
    }

    private void Update()
    {
        if (_target == null)
            return;

        if (_fireCountDown <= 0f)
        {
            Shoot();
            _fireCountDown = 1f/FireRate;
        }

        _fireCountDown -= Time.deltaTime;

    }

    private void Shoot()
    {
        GameObject waterBaloon = (GameObject)Instantiate(WaterBaloonPrefab, WaterBaloonSpawn.position, WaterBaloonSpawn.rotation);

        //waterBaloon.GetComponent<Rigidbody>().velocity = waterBaloon.transform.forward * _shootVelocity;
        WaterBaloon waterBaloonTemp = waterBaloon.GetComponent<WaterBaloon>();
        if (waterBaloonTemp != null)
        {
            //waterBaloonTemp.Seek(_target);
        }
        NetworkServer.Spawn(waterBaloon);

        Destroy(waterBaloon, 2);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, TurrentRange);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;


public class PlayerController : NetworkBehaviour
{
    public GameObject WaterBaloonPrefab;
    public Transform WaterBaloonSpawn;

    private float _throwVelocity = 6f;

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdThrowWaterBaloon();
        }
    }
    [Command]
    private void CmdThrowWaterBaloon()
    {
        GameObject waterBaloon = (GameObject) Instantiate(WaterBaloonPrefab,WaterBaloonSpawn.position, WaterBaloonSpawn.rotation );

        waterBaloon.GetComponent<Rigidbody>().velocity = waterBaloon.transform.forward * _throwVelocity;

        NetworkServer.Spawn(waterBaloon);

        Destroy(waterBaloon, 2);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;


public class PlayerController : NetworkBehaviour
{
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
    }
}

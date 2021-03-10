using UnityEngine;
using Mirror;

public class Waypoints : NetworkBehaviour
{
    public static Transform[] Points;

    private void Awake()
    {
        Points = new Transform[transform.childCount];
        for (int i = 0; i < Points.Length; i++)
        {
            Points[i] = transform.GetChild(i);
        }
    }
}

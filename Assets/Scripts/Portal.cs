using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int portalID;
    public int scene;
    public Vector3 spawnPosition;
    // Start is called before the first frame update
    void Awake()
    {
        spawnPosition = transform.GetChild(0).position;
    }
}

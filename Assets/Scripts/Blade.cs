using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    private int targetPoint;
    [SerializeField]
    private float speed;

    void Update()
    {
        transform.Rotate(0, 0, 100f * speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, waypoints[targetPoint].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoints[targetPoint].position) < .1f)
        {
            targetPoint = targetPoint < waypoints.Length - 1 ? targetPoint + 1 : 0;
        }
    }
}

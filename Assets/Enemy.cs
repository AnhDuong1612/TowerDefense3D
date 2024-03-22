using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavePointIndex;
    private void Start()
    {
        target = Waypoint.points[0];
    }

    private void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position , target.position)<=0.2f)
        {
            GetNextWayPoints();
        }
    }

    public void GetNextWayPoints()
    {
        if(wavePointIndex == Waypoint.points.Length)
        {
            Destroy(gameObject);
            return; 
        }

        wavePointIndex++;
        target = Waypoint.points[wavePointIndex];
    }
}

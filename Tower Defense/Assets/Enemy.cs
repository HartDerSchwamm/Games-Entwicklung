using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform gameMaster;

    private Transform target;
    private int wavePointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = WayPoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }
    // Go trought the Array Waypoints to get the next Waypoint.
    void GetNextWaypoint()
    {
        if(wavePointIndex >= WayPoints.points.Length -1 )
        {
            Destroy(gameObject);
            gameMaster.GetComponent<Life>().TookLife();
        }
        else {
            wavePointIndex++;
            target = WayPoints.points[wavePointIndex];
        }
      
    }
}

using UnityEngine;

public class PlaneMovement : MyMonoBehavior
{
    [SerializeField] protected Transform[] waypoints;
    [SerializeField] protected float speed = 0.3f;
    [SerializeField] protected Vector3 initialPosition;
    private int currentWaypointIndex = 0;

    protected override void Start()
    {
        initialPosition = transform.position;
        if (waypoints.Length > 0)
        {
            waypoints[0].position = initialPosition;
        }
    }

    protected virtual void FixedUpdate()
    {
        if (waypoints.Length == 0)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.fixedDeltaTime);

        float distanceToTarget = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);

        if (distanceToTarget < 0.1f)
        {
            if (currentWaypointIndex < waypoints.Length - 1)
            {
                currentWaypointIndex++;
            }
            else
            {
                System.Array.Reverse(waypoints);
                currentWaypointIndex = 0;
            }
        }
    }
}

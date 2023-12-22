using System.Collections;
using UnityEngine;

public class MovementRandom : MyMonoBehavior
{
    [SerializeField] protected float moveSpeedRandom = 1.0f;
    public float MoveSpeed => moveSpeedRandom;
    [SerializeField] protected float raycastDistance = 1f;
    [SerializeField] protected float initialSpeed = 1.0f;

    protected bool onStopMovement = false;
    protected override void Start()
    {
        base.Start();
        initialSpeed = moveSpeedRandom;
        StartCoroutine(RandomTimeMove());
        OnTurn();
    }
    protected virtual void FixedUpdate()
    {
        CheckRaycast();
        MoveRandom();
    }

    protected virtual void CheckRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            OnTurn();
        }
    }

    protected virtual void MoveRandom()
    {
        transform.Translate(Vector3.forward * moveSpeedRandom * Time.fixedDeltaTime);
    }

    void OnTurn()
    {
        float randomAngle = Random.Range(0f, 360f);
        transform.Rotate(Vector3.up, randomAngle);
        
    }

    IEnumerator RandomTimeMove()
    {
        onStopMovement = false;
        int randomTimeMove = Random.Range(0, 10);
        int randomTimeStop = Random.Range(0, 5);
        yield return new WaitForSeconds(randomTimeMove);
        onStopMovement = true;
        moveSpeedRandom = 0;
        yield return new WaitForSeconds(randomTimeStop);
        StartCoroutine(RandomTimeMove());
    }


}

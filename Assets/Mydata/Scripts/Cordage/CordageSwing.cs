using System.Collections;
using UnityEngine;

public class CordageSwing : MonoBehaviour
{
    public float rotationSpeed = 20f;
    private float rotationDirection = 1;

    private void Start()
    {
        StartCoroutine(ReverseRotate());
    }
    void FixedUpdate()
    {
        RotateObject();
    }
    void RotateObject()
    {
        transform.Rotate(Vector3.forward * rotationDirection * rotationSpeed * Time.fixedDeltaTime);
    }

    protected virtual void OnReverse()
    {
        StartCoroutine(ReverseRotate());
    }

    IEnumerator ReverseRotate()
    {
        yield return new WaitForSeconds(3f);
        rotationDirection *= -1;
        OnReverse();
    }


}

using System.Collections;
using UnityEngine;

public class CameraLook : MyMonoBehavior
{
    public float rotationSpeedMobile = 20.0f;
    public float rotationSpeedPC = 200.0f;

    private float rotateX;
    private float rotateY;

    protected float delay = 0.1f;
    protected float timer = 0;
    protected virtual void Update()
    {
        if (InputManager.Instance.lockInput == true) return;
        LockRotationZ();
        ResetRotation();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                rotateX = -touch.deltaPosition.y * rotationSpeedMobile * Time.deltaTime;
                rotateY = touch.deltaPosition.x * rotationSpeedMobile * Time.deltaTime;
                RotateTranform();
            }
        }
        if (Input.GetMouseButton(0))
        {
            rotateX = -Input.GetAxis("Mouse Y") * rotationSpeedPC * Time.deltaTime;
            rotateY = Input.GetAxis("Mouse X") * rotationSpeedPC * Time.deltaTime;
            RotateTranform();
        }
    }

    protected virtual void RotateTranform()
    {
        transform.Rotate(Vector3.up, rotateY, Space.World);
        transform.Rotate(Vector3.right, rotateX, Space.World);
    }
    protected virtual void LockRotationZ()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z = 0f;
        transform.eulerAngles = currentRotation;
    }

    protected virtual void ResetRotation()
    {
        if (InputManager.Instance.EnableZoom == true) { timer = 0; }
        else
        {
            if (CountDown() == false) return;
            Vector3 currentRotation = transform.eulerAngles;
            currentRotation.y = 0f;
            currentRotation.x = 0f;
            transform.eulerAngles = currentRotation;
        }
    }

    protected virtual bool CountDown()
    {
        this.timer += Time.deltaTime;
        if (this.timer > this.delay) return true;
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCamera : MonoBehaviour
{
    public GameObject cam;

    float LookUp = 0.0f;
    float LookAside = 0.0f;
    float MovementForward = 0.0f;
    float MovementAside = 0.0f;

    [Header("Control Settings")]
    public float MovementSpeed = 3.0F;
    public float MouseSensetivityX = 5.0f;
    public float MouseSensetivityY = 5.0f;

    void Update()
    {
        ControllerMovement();
        Debug.Log(cam.transform.rotation.x);
    }

    void ControllerMovement()
    {
        MovementForward = Input.GetAxis("Vertical");
        MovementAside = Input.GetAxis("Horizontal");
        LookAside = Input.GetAxis("Mouse X") * MouseSensetivityX;
        LookUp = Input.GetAxis("Mouse Y") * MouseSensetivityY;


        if (!InputManager.isStopedController)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            transform.Rotate(0, LookAside, 0);
            cam.transform.localRotation *= Quaternion.AngleAxis(LookUp, Vector3.left);
            cam.transform.localRotation = ClampRotationAroundXAxis(cam.transform.localRotation);
            Vector3 vector = transform.TransformDirection((MovementForward * Vector3.forward + MovementAside * Vector3.right) * MovementSpeed);
            //controller.SimpleMove(vector);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            cam.transform.localRotation = cam.transform.localRotation;
        }
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, -75, 125);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}

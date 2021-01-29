using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCameraControl : MonoBehaviour
{
    /// <summary>
    /// The tilt of the camera in degrees.
    /// </summary>
    /// 
    float pitch = 0;
    float targetPitch = 0;
    /// <summary>
    /// The yaw angle of the camera rig in degrees
    /// </summary>
    float yaw = 0;
    float targetYaw = 0;
    /// <summary>
    /// How far away the camera should be from its target in meters.
    /// </summary>
    float dollyDis = 10;
    float targetDollyDis;

    /// <summary>
    /// This scales the horizontal mouse input.
    /// </summary>
    public float mouseSensitivityX = 1;
    /// <summary>
    /// This scales the vertical mouse input.
    /// </summary>
    public float mouseSensitivityY = 1;

    public float mouseScrollMultiplier = 5;

    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            // changing the pitch:
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            targetYaw += mouseX * mouseSensitivityX;
            targetPitch += mouseY * mouseSensitivityY;
        }

        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        targetDollyDis += scroll * mouseScrollMultiplier;
        targetDollyDis = Mathf.Clamp(targetDollyDis, 2.5f, 15f);

        dollyDis = AnimMath.Slide(dollyDis, targetDollyDis, .05f);

        cam.transform.localPosition = new Vector3(0, 0, -dollyDis);

        // changing the rotation to match the pitch variable:
        targetPitch = Mathf.Clamp(pitch, -89, 89);

        pitch = AnimMath.Slide(pitch, targetPitch, .05f);
        yaw = AnimMath.Slide(yaw, targetYaw, .05f);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
    }
}

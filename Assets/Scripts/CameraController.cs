using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraTurnSpeed = 1;
    public float cameraRotationDamping = 0;
    public float minYRot = -50, maxYRot = 45;
    float mouseX, mouseY;
    Camera playerCamera;
    bool rotationInputAllowed = true;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();

        mouseX = this.gameObject.transform.eulerAngles.y;
        mouseY = playerCamera.transform.eulerAngles.x;
    }

    void Update()
    {
        HandleRotation();
    }

    void HandleRotation()
    {
        if (!rotationInputAllowed)
            return;

        GameObject player = this.gameObject;

        mouseX += Input.GetAxis("Mouse X") * cameraTurnSpeed;

        mouseY -= Input.GetAxis("Mouse Y") * cameraTurnSpeed;
        mouseY = Mathf.Clamp(mouseY, -maxYRot, -minYRot);

        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.Euler(0, mouseX, 0), cameraRotationDamping);
        playerCamera.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(mouseY, mouseX, 0), cameraRotationDamping);

    }

    Vector2 RotationVector()
    {
        return new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}

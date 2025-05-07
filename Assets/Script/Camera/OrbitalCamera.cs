using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    public float sensitivity;
    public float orbitDamping;
    Vector3 localRot;

    public Transform playerPos;
    


    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        transform.position = playerPos.position;

        localRot.x += Input.GetAxisRaw("Mouse X") * sensitivity;
        localRot.y -= Input.GetAxisRaw("Mouse Y") * sensitivity;

        localRot.y = Mathf.Clamp(localRot.y, -30f, 80f);

        Quaternion qt = Quaternion.Euler(localRot.y, localRot.x, 0f);
        transform.rotation = qt;
    }
}

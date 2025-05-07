using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float workingSpeed;

    float horizontalInput;
    float depthInput;

    public OrbitalCamera orbitCamera;

    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }


    private void Start()
    {
        workingSpeed = speed;
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal") * workingSpeed;
        depthInput = Input.GetAxis("Vertical") * workingSpeed;

        PlayerMovements(horizontalInput, depthInput);
    }

    void PlayerMovements(float _horizontale, float _depth)
    {
        Vector3 camforward = orbitCamera.transform.forward;
        Vector3 camRight = orbitCamera.transform.right;

        camforward.y = 0;
        camRight.y = 0;

        Vector3 forwardRelative = _depth * camforward;
        Vector3 rightRelative = _horizontale * camRight;

        Vector3 moveDir = forwardRelative + rightRelative;

        rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);

        if (rb.velocity != Vector3.zero)
            transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && !GameManager.instance.inWater)
            GameManager.instance.ToggleWaterState();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water") && GameManager.instance.inWater)
            GameManager.instance.ToggleWaterState();
    }
}

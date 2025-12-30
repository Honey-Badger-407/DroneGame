using UnityEngine;

public class Direction_Contoller : MonoBehaviour
{
    public float forwardSpeed = 6f;
    public float rotationSpeed = 80f;

    private Rigidbody rb;

    // Hold states (set by UI buttons)
    private bool pitchUp;
    private bool pitchDown;
    private bool yawLeft;
    private bool yawRight;
    float pitch = 0f;
    float yaw = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        // Forward movement
        rb.linearVelocity = transform.forward * forwardSpeed;
        Vector3 rotation = new Vector3(
            pitch * rotationSpeed * Time.fixedDeltaTime,
            yaw   * rotationSpeed * Time.fixedDeltaTime,
            0f
        );

        transform.Rotate(rotation, Space.Self);
    }

    // ===== UI BUTTON CALLBACKS =====

    public void PitchUp(bool pressed)
    {
        if (pressed)
            pitch = -1f;
        else
            pitch = 0f;
        pressed = false;
    }

    public void PitchDown(bool pressed)
    {
        if (pressed)
            pitch = 1f;
        else
            pitch = 0f;
        pressed = false;
    }

    public void YawLeft(bool pressed)
    {
        if (pressed)
            yaw = -1f;
        else
            yaw = 0f;
        pressed = false;
    }

    public void YawRight(bool pressed)
    {
        if (pressed)
            yaw = 1f;
        else
            yaw = 0f;
        pressed = false;
    }
}

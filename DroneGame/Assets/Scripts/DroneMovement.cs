using UnityEngine;
public class DroneMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float verticalSpeed = 6f;

    private bool Fov, Back, Left, Right, Up, Down;
    float maxSpeed;
    float forwardInput;
    float sideInput;
    float verticalInput;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Userinput();
        forwardInput=ForwardMovement();
        sideInput=SideMovement();
        verticalInput = VerticalMovement();
    }
    void FixedUpdate()
    {
        Vector3 moveDir = transform.forward * forwardInput + transform.right * sideInput;
        Vector3 verticalDir = transform.up * verticalInput;
        if (moveDir.sqrMagnitude > 1f)
            moveDir.Normalize();
        rb.AddForce(moveDir * moveSpeed, ForceMode.Acceleration);
        rb.AddForce(verticalDir * verticalSpeed, ForceMode.Acceleration);
        rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
    }
    int ForwardMovement()
    {
        if (Fov && !Back )
        {
            return 1;
        }
        else if (!Fov && Back)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
    int SideMovement()
    {
        if (Left && !Right)
        {
            return -1;
        }
        else if (!Left && Right)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    int VerticalMovement()
    {
        if (Up && !Down)
            return 1;
        else if (!Up && Down)
            return -1;
        else
            return 0;
    }
    void Userinput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Fov = true;
        }
        else
            Fov = false;
        if (Input.GetKey(KeyCode.S))
        {
            Back = true;
        }
        else
            Back = false;
        if (Input.GetKey(KeyCode.A))
        {
            Left = true;
        }
        else
            Left = false;
        if (Input.GetKey(KeyCode.D))
        {
            Right = true;
        }
        else
            Right = false;
        if (Input.GetKey(KeyCode.Space))
        {
            Up = true;
        }
        else
            Up = false;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Down = true;
        }
        else
            Down = false;
    }

}
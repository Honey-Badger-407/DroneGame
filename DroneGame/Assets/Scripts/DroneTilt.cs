using UnityEngine;
public class DroneTilt : MonoBehaviour
{
    private bool Fov, Back, Left, Right;
    public float tiltangle;
    public float tiltspeed;
    public float Rotationspeed;
    float RotationDirection;
    float targetRotation;
    float SidetargetRotation;
    float yaw;
    void Update()
    {
        Userinput();
        ForwardMovement();
        SideMovement();
        yaw = yaw + Rotationspeed * RotationDirection * Time.deltaTime;
        ApplyTilt();
    }
    int ForwardMovement()
    {
        if (Fov && !Back )
        {
            LinearTiltAngle("Fov");
            return 1;
        }
        else if (!Fov && Back)
        {
            LinearTiltAngle("Back");
            return -1;
        }
        else
        {
            LinearTiltAngle("");
            return 0;
        }
    }
    int SideMovement()
    {
        if (Left && !Right)
        {
            SideTiltAngle("L");
            return -1;
        }
        else if (!Left && Right)
        {
            SideTiltAngle("R");
            return 1;
        }
        else
        {
            SideTiltAngle("");
            return 0;
        }
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
        if (Input.GetKey(KeyCode.E))
        {
            RotationDirection = 1;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            RotationDirection = -1;
        }
        else
        {
            RotationDirection = 0;
        }
    }
    void LinearTiltAngle(string direction)
    {
        switch (direction)
        {
            case "Fov":
                targetRotation = tiltangle;
                break;
            case "Back":
                targetRotation =-tiltangle;
                break;
            default:
                targetRotation =0f;
                break;
        }
    }
    void SideTiltAngle(string direction)
    {
        switch (direction)
        {
            case "R":
                SidetargetRotation = -tiltangle;
                break;
            case "L":
                SidetargetRotation = tiltangle;
                break;
            default:
                SidetargetRotation =0f;
                break;
        }
    }
    void ApplyTilt()
    {
        Quaternion target = Quaternion.Euler(targetRotation,yaw, SidetargetRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, target, tiltspeed * Time.deltaTime);
    }
}
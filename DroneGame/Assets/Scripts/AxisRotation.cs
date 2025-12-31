using UnityEngine;

public class AxisRotation : MonoBehaviour
{
    public float Rotationspeed;
    float RotationDirection;
    void Update()
    {
        Userinput();
        transform.Rotate(0f, Rotationspeed * RotationDirection, 0f);
    }
    void Userinput()
    {
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
}

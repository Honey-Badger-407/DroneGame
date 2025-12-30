using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    private bool Fov, Back, Left, Right;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        input();
        LinearMovement();
        SidewaysMovement();
    }
    void FixedUpdate()
    {

    }
    int LinearMovement()
    {
        if (Fov && Back)
        {
            Debug.Log("FovBack");
            return 0;
        }
        else if (Fov)
        {
            Debug.Log("Fov");
            return 1;
        }
        else if (Back)
        {
            Debug.Log("Back");
            return -1;
        }
        else
        {
            Debug.Log("!fov!back");
            return 0;
        }
    }
    int SidewaysMovement()
    {
        if (Left && Right)
        {
            Debug.Log("LR");
            return 0;
        }
        else if (Left)
        {
            Debug.Log("L");
            return 0;
        }
        else if (Right)
        {
            Debug.Log("R");
            return -1;
        }
        else
        {
            Debug.Log("!L!R");
            return 0;
        }
    }
    void input()
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
    }
}


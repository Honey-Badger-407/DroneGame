using UnityEngine;

public class ProplerRotation : MonoBehaviour
{
   [SerializeField] float Rotationspeed =5f;
    void Update()
    {
        transform.Rotate(Rotationspeed * Time.deltaTime, 0, 0);
    }
}

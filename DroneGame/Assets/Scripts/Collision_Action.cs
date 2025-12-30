using Unity.VisualScripting;
using UnityEngine;

public class Collision_Action : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            // Destroy immediately
            Destroy(gameObject);
        }
    }
}

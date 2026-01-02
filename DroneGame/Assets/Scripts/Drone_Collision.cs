using UnityEngine;


public class Drone_Collision : MonoBehaviour
{
    public StopMenu stopMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            Destroy(gameObject);
            stopMenu.OnDeath();
        }
    }
}

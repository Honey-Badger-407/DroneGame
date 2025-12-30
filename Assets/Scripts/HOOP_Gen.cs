using Unity.Collections;
using UnityEngine;

public class HOOP_Gen : MonoBehaviour
{
    public GameObject playerobject;
    public GameObject Hoops;
    public Vector3 Mincords;
    public Vector3 Maxcords;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 HoopPos = Hoops.transform.position;
            Hoops.transform.position = new Vector3(Random.Range(Mincords.x, Maxcords.x),Random.Range(Mincords.y, Maxcords.y), HoopPos.z + 20f );
            
        }

    }
}

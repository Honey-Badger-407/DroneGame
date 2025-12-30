using UnityEngine;

public class Collectibles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject modelPrefab;
    [SerializeField] int minX, maxX, minZ, maxZ;
    [SerializeField] public int count ;
    [SerializeField] int Y;
    public int[] RandX;
    public int[] RandZ;
    void Start()
    {
        RandX = new int[count];
        RandZ = new int[count];
        for(int i = 0;i<count;i++)
        {
            RandX[i] = Random.Range(minX, maxX);
            RandZ[i] = Random.Range(minZ, maxZ);
            Vector3 spawnPos = new Vector3(RandX[i], Y, RandZ[i]);
            GameObject NewItem = Instantiate(modelPrefab, spawnPos, Quaternion.identity);
            CollectibleManager.Instance.RegisterCollectible(NewItem.transform);

        }
    }
}

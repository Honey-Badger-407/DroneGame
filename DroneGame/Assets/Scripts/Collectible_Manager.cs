using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance; // Singleton for easy access

    public List<Transform> collectibles = new List<Transform>();
    public Transform FirstCollectible;
    void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        RegisterCollectible(FirstCollectible);
    }
    public void RegisterAllCollectibles()
    {
        GameObject[] foundCollectibles = GameObject.FindGameObjectsWithTag("Collectible");

        foreach (GameObject obj in foundCollectibles)
        {
            Transform collectibleTransform = obj.transform;

            // Only add if not already in the list
            if (!collectibles.Contains(collectibleTransform))
            {
                RegisterCollectible(collectibleTransform);
            }
        }
    }


    // Add collectible to list when spawned
    public void RegisterCollectible(Transform collectible)
    {
        collectibles.Add(collectible);
    }

    // Remove collectible when collected/destroyed
    public void UnregisterCollectible(Transform collectible)
    {
        collectibles.Remove(collectible);
    }

    // Get closest collectible to a given position
    public Transform GetClosestCollectible(Vector3 playerPos)
    {
        if ( collectibles == null)
        {
            RegisterAllCollectibles();
        }
        Transform closest = null;
        float minDistance = Mathf.Infinity;

        foreach (Transform c in collectibles)
        {
            if (c == null) continue; // skip destroyed collectibles
            float dist = Vector3.Distance(playerPos, c.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                closest = c;
            }
        }

        return closest;
    }
}

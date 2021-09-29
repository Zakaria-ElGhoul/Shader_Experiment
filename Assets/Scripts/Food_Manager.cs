using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Manager : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public GameObject particle;
    public Transform[] spawnPoints;
    public List<GameObject> spawnedObjects;
    public int spawnCount;
    public int objectIndex;
    public int spawnIndex;

    private void Start()
    {
        InvokeRepeating("Spawner", 1f, 0.5f);
    }

    void Spawner()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            objectIndex = Random.Range(0, objectsToSpawn.Length);
            spawnIndex = Random.Range(0, spawnPoints.Length);
            GameObject game = Instantiate(particle, spawnPoints[spawnIndex].position, Quaternion.identity);
            GameObject go = Instantiate(objectsToSpawn[objectIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
            spawnedObjects.Add(go);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Gizmos.DrawSphere(spawnPoints[i].position, 0.5f);
        }
    }
}
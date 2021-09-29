using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Manager : MonoBehaviour
{
    public GameObject[] fruitObject;
    public GameObject[] SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Spawn()
    {
        for (int i = 0; i < SpawnPoint.Length; i++)
        {
            Instantiate(fruitObject[i], SpawnPoint[i].transform);
        }
    }
}

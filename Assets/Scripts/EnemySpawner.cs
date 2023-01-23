using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool GameOver = false;
    public GameObject CactusPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCactus", 0f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCactus()
    {
        if(GameOver) CancelInvoke();
        else Instantiate(CactusPrefab);
    }
}

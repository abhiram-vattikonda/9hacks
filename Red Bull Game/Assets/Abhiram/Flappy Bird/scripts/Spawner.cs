using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{

    [SerializeField] private Transform poles;

    private float spawnRate = 1.5f;
    private float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnRate;
    }


    private void Update()
    {   
        if (Jumping.instance.jumpedAtleastOnce)
        {
            if (spawnTimer < 0)
            {
                Transform pole = Instantiate(poles, PoleSpawnPosition(), Quaternion.identity);
                spawnTimer = spawnRate;
            }
            else
            { spawnTimer -= Time.deltaTime; }
        }
    }

    private Vector3 PoleSpawnPosition()
    {
        return new Vector3 (transform.position.x, Random.Range(-3f, 3f), 1.5f);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceRock : MonoBehaviour
{
    [SerializeField] private GameObject rockIntantiate;
    private float spawnLimitX = 10f;
    private float spawnLimitZ = 20f;
    private float spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RockIntantiate", 2f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RockIntantiate()
    {
        Instantiate(rockIntantiate, new Vector3(Random.Range(-spawnLimitX, spawnLimitX), 2f, spawnLimitZ), transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceRock : MonoBehaviour
{
    [SerializeField]private GameObject rockIntantiate;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RockIntantiate",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RockIntantiate()
    {
        Instantiate(rockIntantiate,new Vector3(0,0,20),transform.rotation);
    }
}

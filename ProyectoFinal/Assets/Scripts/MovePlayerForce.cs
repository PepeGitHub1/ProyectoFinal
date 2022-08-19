using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerForce : MonoBehaviour
{
    [SerializeField]
    [Range(5f, 2000f)] private float speed = 5f;
    [SerializeField]
    [Range(5f, 2000f)] private float maxSpeed = 5f;

    private Vector3 inputs = Vector3.zero;


    private Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        if()
        playerRB.AddForce(inputs * speed, ForceMode.Force);
    }



}

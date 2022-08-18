using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerForce : MonoBehaviour
{
    [SerializeField]
    [Range(5f, 2000f)] private float speed = 5f;

    private Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(inputHorizontal, 0, inputVertical);

        playerRB.AddForce(direction * speed, ForceMode.Force);
    }
}

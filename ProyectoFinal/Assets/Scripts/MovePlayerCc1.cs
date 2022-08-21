using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerCc1 : MonoBehaviour
{
    private CharacterController PlayerCC;
    private Vector3 direction;
    public float speed;
    private float gravity;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCC = GetComponent<CharacterController>();
        speed = 10f;
        gravity = -9.81f;
    }

    // Update is called once per frame
    void Update()
    {   
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        direction.y = gravity*Time.deltaTime;
        PlayerCC.Move(direction * speed * Time.deltaTime);

  




        
    }
}

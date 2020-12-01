using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpingForce;
    private bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Raycast to identify if player is touching the ground, allowing them to jump.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.01f)) {
            canJump = true;
        }
        ProcessInput();


    }
    void ProcessInput() {
        //Mov in the XZ plane
        if (Input.GetKey("right") | Input.GetKey("d")) {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;    
        }
        if (Input.GetKey("left") | Input.GetKey("a")) {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;    
        }
        if (Input.GetKey("up") | Input.GetKey("w")) {
            transform.position += Vector3.forward * movementSpeed * Time.deltaTime;    
        }
        if (Input.GetKey("down") | Input.GetKey("s")) {
            transform.position += Vector3.back * movementSpeed * Time.deltaTime;    
        }
        //Check for Jumping
        if (canJump && Input.GetKeyDown("space")) {
            canJump = false;
            GetComponent<Rigidbody>().AddForce(0, jumpingForce, 0);
        }
    }
}

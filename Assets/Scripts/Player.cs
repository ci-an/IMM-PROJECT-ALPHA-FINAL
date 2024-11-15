using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGameOver; //Boolean variable to see whether the game has ended or is ongoing
    private Vector3 direction; //Declare direction varaible to move
    public float gravityModifier = -10.0f; //Initialize gravityModifier variable to apply gravity on player
    public float updraft = 5.0f; //Initialize updraft variable to push against gravity
    private Rigidbody playerRigid;

    private void Start() {

        //Get rigid body component from <RigidBody>
        playerRigid = GetComponent<Rigidbody>();

        //Apply a small amount of updraft at the start of game
        playerRigid.AddForce(Vector3.up * 4, ForceMode.Impulse);
    }

    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * updraft;
        }

        //Apply gravity on every frame
        direction.y += gravityModifier * Time.deltaTime;

        //Update players position using rigidbody component
        playerRigid.velocity = new Vector3(0, direction.y, 0);
    }

    private void OnCollisionEnter(Collision collision) {
    Debug.Log("Trigger Entered with: " + collision.gameObject.name);

    if(collision.gameObject.tag == "Obstacle") {
        Debug.Log("Hit an obstacle!");
        FindObjectOfType<GameState>().isGameOver();
    } else if(collision.gameObject.tag == "Scoring") {
        Debug.Log("Hit a scoring object!");
        FindObjectOfType<GameState>().IncreaseScore();
    }
}
}

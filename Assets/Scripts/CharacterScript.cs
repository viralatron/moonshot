using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public int health, maxHealth, attack;

    public float speed, jumpHeight, gravityValue;


    private bool groundedCharacter;
    private Vector3 playerVelocity;
    private CharacterController controller;
    private Camera cam;
    private Transform mesh;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cam = Camera.main;
        mesh = transform.GetChild(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAtPosition(Input.mousePosition);
        groundedCharacter = controller.isGrounded;
        if (groundedCharacter && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float vMovement = Input.GetAxis("Vertical");
        float hMovement = Input.GetAxis("Horizontal");
        bool jumpButton = Input.GetButton("Jump");

        if( vMovement != 0f || hMovement != 0f)
            Move(hMovement, vMovement, speed);
        if(jumpButton && groundedCharacter) {
            Jump(jumpHeight);
        }
        if(!groundedCharacter)
            Fall(gravityValue);
    }

    void onHit(int damage){
        health -= damage;
        if(health <= 0){
            Debug.Log("dead"); // death animation? dunno
        }
    }

    void onHeal(int amount){
        if(health < maxHealth)
            health += amount;
        if(health > maxHealth)
            health = maxHealth;
    }

    void Attack(){
        // now how am I going to attack?
    }
    void Jump(float height){
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        controller.Move(playerVelocity * Time.deltaTime);
    }
    void Move(float x, float z, float speed){
        controller.Move(new Vector3(x, 0, z) * speed * Time.deltaTime);
    }

    void Fall(float gravity) {
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void LookAtPosition(Vector3 position){

        // use a raycast to find position
        Ray ray = cam.ScreenPointToRay(position);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(ray, out rayLength)){
            Vector3 target = ray.GetPoint(rayLength);
            mesh.LookAt(target);
            Debug.DrawLine(mesh.position, target, Color.blue);
        }
    }
}

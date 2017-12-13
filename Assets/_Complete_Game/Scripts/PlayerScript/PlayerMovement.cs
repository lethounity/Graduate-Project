using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    Vector3 movement;
    Rigidbody playerRB;

     Animator anim;
     int floorMask;
     float camRayLength = 100f;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
	}

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRB.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRB.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool running = (h != 0f || v != 0f);
        anim.SetBool("IsRunning", running);

        bool idle = (h == 0f && v == 0f);
        anim.SetBool("IsIdle", idle);
    }
}

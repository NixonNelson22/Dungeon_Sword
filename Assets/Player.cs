using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

using UnityEngine.InputSystem.EnhancedTouch;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Finger finger;
    [SerializeField]
    float moveSpeed;
    void Start()
    {
        float x= finger.currentTouch.startScreenPosition.x; 
    }
    private void OnEnable()
    {
	EnhancedTouchSupport.Enable();
    }
    private void OnDisable() {
        EnhancedTouchSupport.Disable();        
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down),out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            transform.position = new Vector3( hit.point.x , hit.point.y +1f, hit.point.z );
        }
        if(Input.GetKey(KeyCode.W)){
            MovPos( Vector3.forward,Vector3.zero);
        }
        if(Input.GetKey(KeyCode.S)){
            MovPos( Vector3.back,Vector3.zero);
        }
	if(Input.GetKey(KeyCode.A))
	{
	    MovPos(Vector3.zero,new Vector3(0f,-12f,0f));
	}
	if(Input.GetKey(KeyCode.D))
	{
	    MovPos(Vector3.zero,new Vector3(0f,12f,0f));
	}
        // 	get the hit.collider and get the transform of the hit point change the y value of player to the hit position.y
        //	change the transform of the sword to hit the enemy 
        //	get the inputaction and use it for controling the player using joystick like control 
	
    }
    private void MovPos(Vector3 direction,Vector3 rotation)
    {
	    transform.position += transform.TransformDirection(direction*Time.deltaTime* moveSpeed);
	    transform.eulerAngles += transform.TransformDirection(rotation * Time.deltaTime* moveSpeed);
    }

}

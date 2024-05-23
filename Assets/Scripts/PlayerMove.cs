using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Rendering;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    [SerializeField] private FloatingJoystick joystick;
    [HideInInspector]
    public Vector3 movementVector;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticallVector;

    [SerializeField] float speed = 4f;
    
    private void Start() {
        lastHorizontalVector = -1f;
        lastVerticallVector = 1f;
    }
    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        /*movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
        if(movementVector.x !=0) {
            lastHorizontalVector = movementVector.x;
            lastVerticallVector = movementVector.y; 
        }
        if(movementVector.y !=0) {
            lastVerticallVector = movementVector.y; 
        }

        movementVector *= speed;

        rgbd2d.velocity = movementVector;*/
        rgbd2d.velocity = new Vector3(joystick.Horizontal * speed, joystick.Vertical * speed, rgbd2d.velocity.y);
        // UnityEngine.Debug.Log(rgbd2d.velocity);
    }
}

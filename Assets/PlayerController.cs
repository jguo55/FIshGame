using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;


    [SerializeField] Camera cam;
    [SerializeField] float walkFov;
    [SerializeField] float sprintFov;
    [SerializeField] float smoothing;

    float fovVelocity;


    // Update is called once per frame
    void Update()
    {
        //s and w, -1 to 1
        float forward = Input.GetAxis("Vertical");

        //a and d, -1 to 1
        float right = Input.GetAxis("Horizontal");

        Vector3 movement = transform.forward * forward + transform.right * right;

        //Vector3 movement = transform.TransformDirection(new Vector3(right, 0, forward));

        movement.Normalize();


        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        float speed = isSprinting ? sprintSpeed : walkSpeed; //turing

        float targetFov;
        if(movement.magnitude > 0) {
            targetFov = isSprinting ? sprintFov : walkFov;
            cam.fieldOfView = isSprinting ? sprintSpeed : walkSpeed; //turing
        }
        else {
            targetFov = walkFov;
        }
        
        cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, targetFov, ref fovVelocity, smoothing);

        controller.Move(movement*Time.deltaTime*speed);
    }
}

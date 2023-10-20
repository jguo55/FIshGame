using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensitivity;
    [SerializeField] float clampAngle;
    [SerializeField] Transform body;

    Vector3 eulerAngles;

    void Start(){
        eulerAngles = transform.eulerAngles;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotate = new Vector3(-mouseY, mouseX, 0);

        eulerAngles += rotate;

        eulerAngles.x = Mathf.Clamp(eulerAngles.x, -clampAngle, clampAngle); //so the head doesn't roll over

        transform.localEulerAngles = Vector3.right*eulerAngles.x;
        body.eulerAngles = Vector3.up*eulerAngles.y;
    }
}

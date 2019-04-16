using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController CC;
    private Camera cam;
    private Vector3 moveVect;
    private Vector3 turnVect;
    private float fallVect;

    public float movementSpeed = 8f;
    public float mouseSensetivity = 4f;
    public float gravityAcceleration = 9.8f;

    // Start is called before the first frame update
    void Start()
    {
        CC = transform.GetComponent<CharacterController>();
        cam = transform.GetComponentInChildren<Camera>();
        moveVect = Vector3.zero;
        turnVect = Vector3.zero;
        fallVect = 0f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveVect = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        turnVect = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);

        if (!CC.isGrounded)
        {
            fallVect += gravityAcceleration * Time.deltaTime;
            moveVect += new Vector3(0f, -fallVect, 0f);
        }
        else fallVect = 0.1f;
    }

    void FixedUpdate()
    {
        CC.Move(transform.TransformVector(moveVect) * movementSpeed * Time.deltaTime);
        CC.transform.Rotate(new Vector3(0f, turnVect.y * mouseSensetivity, 0f));
        cam.transform.Rotate(new Vector3(turnVect.x * mouseSensetivity, 0f, 0f));

        moveVect = Vector3.zero;
        turnVect = Vector3.zero;
    }
}

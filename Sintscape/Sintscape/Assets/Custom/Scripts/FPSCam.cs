using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCam : MonoBehaviour
{
	public float mouseSensitivity;
	public float moveSpeed;
	public float jumpForce;
	public Transform head;
	public LayerMask mask;

	Rigidbody rb;
	float xRotation;

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * 100;
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 65f);
		head.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * 100;
		transform.Rotate(new Vector3(0, mouseX, 0));
		if (Input.GetKeyDown("space") && CheckGrounded())
		{
			Debug.Log(CheckGrounded());
			rb.AddForce(transform.up * jumpForce * 10, ForceMode.Impulse);
		}
	}

	private void FixedUpdate()
	{
		rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed / 100) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed / 100));
	}

	private bool CheckGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, 0.5f);	
	}
}
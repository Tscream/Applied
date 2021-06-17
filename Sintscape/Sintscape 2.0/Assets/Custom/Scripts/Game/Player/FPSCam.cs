using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FPSCam : MonoBehaviour
{
	public float mouseSensitivity;
	public float moveSpeed;
	public float jumpForce;
	public Transform head;
	public LayerMask mask;

	Rigidbody rb;
	float xRotation;

	[SerializeField] private PhotonView pv;

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody>();

        if (!pv.IsMine)
        {
			Destroy(GetComponentInChildren<Camera>().gameObject);
			Destroy(rb);
        }

	}

	private void Update()
	{
        if (!pv.IsMine)
        {
			return;
        }

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
		if (!pv.IsMine)
		{
			return;
		}

		rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed / 100) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed / 100));
	}

	private bool CheckGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, 10f);
		Debug.Log("Feest");
	}
}
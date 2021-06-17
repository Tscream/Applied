using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhysicsGrab : MonoBehaviour
{
	//Public
	public float m_InteractionDistance = 200;
	public float m_Speed = 10;
	public float m_ThrowStrength = 15;

    //Private
    [SerializeField] private Transform m_Camera;
	[SerializeField] private GameObject m_GrabPos;
	[SerializeField] private GameObject CurrentInteractable;
	[SerializeField] private Rigidbody CurRigidbody;

	[SerializeField] private PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
		CurrentInteractable = null;
	}

	// Update is called once per frame
	void Update()
    {
		if (!pv.IsMine)
		{
			return;
		}

		if (Input.GetMouseButtonDown(0))
		{
			Interact();
		}
        if (Input.GetMouseButtonDown(2))
        {
            if (CurrentInteractable)
            {
                CurRigidbody.angularDrag = 0.05f;
                CurRigidbody = null;
				CurrentInteractable.tag = "interactable";
                CurrentInteractable = null;
			}
		}
        if (Input.GetMouseButtonUp(1))
        {
            if (CurrentInteractable)
            {
                CurrentInteractable.GetComponent<Rigidbody>().AddForce(m_Camera.forward * m_ThrowStrength, ForceMode.Impulse);
                CurRigidbody.angularDrag = 0.05f;
                CurRigidbody = null;
				CurrentInteractable.tag = "interactable";
                CurrentInteractable = null;
			}
		}

    }

	void Interact()
	{
		if (!CurrentInteractable)
		{
            Ray InteractionRay = new Ray(m_Camera.position, m_Camera.forward);
            RaycastHit hitInfo;
            Debug.DrawLine(m_Camera.position, m_Camera.forward * m_InteractionDistance);
			if (Physics.Raycast(InteractionRay,out hitInfo, m_InteractionDistance))
			{
				if (hitInfo.collider.gameObject.tag == "Interactable")
				{
					CurrentInteractable = hitInfo.collider.gameObject;
					CurrentInteractable.tag = null;
					CurRigidbody = CurrentInteractable.GetComponent<Rigidbody>();					
					CurRigidbody.rotation = Quaternion.Euler(Vector3.zero);
					CurRigidbody.angularDrag = 2;
					Debug.Log("Grab hit Gameobject: " + hitInfo.collider.gameObject.name);
				}
				if (hitInfo.collider.gameObject.tag == "Number")
				{
					RandomCode._instance.Inputnumber(hitInfo.collider.gameObject.name);
				}
                if (hitInfo.collider.gameObject.tag == "WrongImage")
                {
                    GameObject puzzleimage = GameObject.Find("ImagePuzzle");
                    ImagePuzzle script = (ImagePuzzle)puzzleimage.GetComponent(typeof(ImagePuzzle));
                    script.WrongImage();      
                }
                if (hitInfo.collider.gameObject.tag == "RightImage")
                {
                    GameObject puzzleimage = GameObject.Find("ImagePuzzle");
                    ImagePuzzle script = (ImagePuzzle)puzzleimage.GetComponent(typeof(ImagePuzzle));
                    script.RightImage();
                }
            }
		}
	}

	private void FixedUpdate()
	{
		if (!pv.IsMine)
		{
			return;
		}

		if (CurrentInteractable && CurrentInteractable.GetComponent<Rigidbody>() != null)
		{
			CurrentInteractable.GetComponent<Rigidbody>().velocity = (m_GrabPos.transform.position - CurrentInteractable.transform.position) * m_Speed;
		}
	}
}

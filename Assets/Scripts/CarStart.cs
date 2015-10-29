using UnityEngine;
using System.Collections;

public class CarStart : MonoBehaviour {
	private Rigidbody parentRigidBody;

	// Use this for initialization
	void Start () {
		parentRigidBody = transform.parent.GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision Collision)
	{
		if(parentRigidBody.isKinematic)
		{
			parentRigidBody.isKinematic = false;
		}

	}
}

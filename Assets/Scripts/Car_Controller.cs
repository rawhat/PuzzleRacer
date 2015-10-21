using UnityEngine;
using System.Collections;

public class Car_Controller : MonoBehaviour
{
    public float carSpeed;

    private Rigidbody carRigidbody;

	// Use this for initialization
	void Start ()
    {
        carRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //for floaty movement
        carRigidbody.AddForce (movement * carSpeed);

        //for faster reacting movement
        //carRigidbody.velocity(movement * carSpeed);
    }
}

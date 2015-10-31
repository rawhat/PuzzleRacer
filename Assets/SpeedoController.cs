using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityStandardAssets.Vehicles.Car;


public class SpeedoController : MonoBehaviour {

    public Rigidbody carRigidbody;
    private float maxRotation = -270f;
    private RawImage speedometer;
    public CarController carController;

    void Start()
    {
        speedometer = GetComponent<RawImage>();
        carController = GameObject.FindObjectOfType<CarController>();
    }

	void Update () {
        Vector3 rot = new Vector3(0f, 0f, maxRotation * (carRigidbody.velocity.magnitude / carController.MaxSpeed));
        speedometer.rectTransform.localRotation = Quaternion.Euler(rot);
	}
}

using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour {

	public Transform cam;
	public Vector3 offset;
	public float maxForce = 10f;
	public float lerpConst = 0.2f;

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		//Move ball
		Vector3 force = Vector3.zero;
		force += Vector3.right * Input.GetAxis("Horizontal");
		force += Vector3.forward * Input.GetAxis("Vertical");
		force *= maxForce;
		rb.AddForce(force);

		//Move camera
		Vector3 targetPos = transform.position;
		targetPos += offset;

		cam.position = Vector3.Lerp(cam.position, targetPos, lerpConst);
    }
}

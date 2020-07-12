using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float dashSpeed;
	public float dashCooldown;

	Rigidbody myRigidbody;
	Camera mainCamera;
	Vector3 pointToLook;
	bool canDash = true;

    // Start is called before the first frame update
    void Start() {
        myRigidbody = GetComponent<Rigidbody>();
		mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update() {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayLength;
		if (groundPlane.Raycast(cameraRay, out rayLength)) {
			pointToLook = cameraRay.GetPoint(rayLength);
			//transform.LookAt(pointToLook);
		}

		if (Input.GetMouseButton(0) && pointToLook != null && canDash) { // On LMB dash!
			canDash = false;
			Vector3 dashDirection = Vector3.Normalize(new Vector3(pointToLook.x - transform.position.x, 0, pointToLook.z - transform.position.z));
			
			Dash(dashDirection);

			StartCoroutine("ResetCanDash");
		}
    }

	void Dash(Vector3 direction) {
		myRigidbody.velocity = Vector3.zero;
		myRigidbody.AddForce(direction*20*dashSpeed, ForceMode.Impulse);
		transform.LookAt(direction);
	}

	IEnumerator ResetCanDash() {
		yield return new WaitForSeconds(dashCooldown);
		canDash = true;
	}

	public bool CanDash() {
		return canDash;
	}
}

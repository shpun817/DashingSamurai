using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate : MonoBehaviour {

	public float amount = 65f;

	Vector3 direction;

    // Start is called before the first frame update
    void Start() {
        direction = transform.right;
    }

    private void OnTriggerEnter(Collider other) {
		Rigidbody rb = other.GetComponent<Rigidbody>();
		if (rb) {
			rb.velocity = rb.velocity/2;
			rb.AddForce(direction*amount, ForceMode.Impulse);

			Destroy(gameObject);
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public bool fixedInterval = true;
	public float interval = 1f;
	public bool fixedStrength = true;
	public float strength = 20f;

	Rigidbody rb;

    // Start is called before the first frame update
    void Awake() {
        StartCoroutine("Move");
		rb = GetComponent<Rigidbody>();
    }

	IEnumerator Move() {

		// Determine a direction
		Vector3 randomDirection = (new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f))).normalized;

		// Apply force
		if (!fixedStrength) {
			strength = Random.Range(15f, 30f);
		}

		if (rb) {
			rb.velocity = randomDirection*strength;
		}

		if (!fixedInterval) {
			interval = Random.Range(1, 5);
		}

		yield return new WaitForSeconds(interval);
		StartCoroutine("Move");
	}
}

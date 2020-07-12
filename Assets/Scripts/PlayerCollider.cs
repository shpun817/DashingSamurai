using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

	public float toughness = 30f;

	public GameObject deathBurst;

	// Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

	private void OnCollisionEnter(Collision other) {
		Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
		Animator animator = other.gameObject.GetComponent<Animator>();
		if (rb) {
			float speed = rb.velocity.magnitude;
			if (speed > toughness) {
				if (animator) {
					animator.SetTrigger("Attack");
				}
				Die();
			}
		}
	}

	void Die() {
		GameObject obj = Instantiate(deathBurst, transform.position, transform.rotation);
		ParticleSystem burst = obj.GetComponent<ParticleSystem>();
		burst.Play();
		Destroy(obj, 1);
		Destroy(gameObject);
	}

}

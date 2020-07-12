using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerSpeed : MonoBehaviour {

	public Rigidbody player;
	Text txt;

	private void Start() {
		txt = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update() {
        
		txt.text = player.velocity.magnitude.ToString("F1") + " m/s";

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDashCharge : MonoBehaviour {

	public PlayerMovement player;

	float chargeValue = 100f;
	float lastDashTime;

	Text text;

	private void Start() {
		text = GetComponent<Text>();
		text.color = Color.red;
	}

    // Update is called once per frame
    void Update() {
        if (!player.CanDash() && chargeValue == 100f) {
			chargeValue = 0f;
			lastDashTime = Time.time;
			text.color = Color.gray;
		}

		chargeValue = (Time.time - lastDashTime) / player.dashCooldown * 100;
		if (chargeValue > 100f) {
			chargeValue = 100f;
			text.color = Color.red;
		}

		text.text = chargeValue.ToString("F1") + "%";
    }

}

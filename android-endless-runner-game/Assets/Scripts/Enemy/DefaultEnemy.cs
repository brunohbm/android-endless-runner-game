using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : MonoBehaviour {

	public float speed;
	public float xPosition;

	void Update () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.left * speed;

		if (xPosition >= transform.position.x) {
			Destroy (gameObject);
		}

		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo(0).IsName("End")) {
			Destroy (gameObject);
		}
	}
}

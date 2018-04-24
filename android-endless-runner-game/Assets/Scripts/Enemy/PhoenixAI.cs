using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixAI : MonoBehaviour {

	public float speed;
	public float xPosition;

	public Transform endDirection;
	public GameObject father;

	private bool die;

	void Update () {
		if (!die) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.left * speed;
		}

		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo(0).IsName("PhoenixDie")) {
			speed = 0.0f;
			gameObject.tag = "Untagged";
		}

		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo(0).IsName("End")) {
			die = true;
			transform.rotation = new Quaternion (0, 0, 0, 0);
			Destroy (GetComponent<Rigidbody2D>());
		}

		if (die) {
			transform.position = Vector3.MoveTowards (transform.position, endDirection.position, 4.0f * Time.deltaTime);
			if (Vector3.Distance(transform.localPosition, endDirection.localPosition) <= 0.1){
				Destroy (father);
			}
		}

		if (xPosition >= transform.position.x) {
			Destroy (father);
		}
	}
}

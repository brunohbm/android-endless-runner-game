using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2D;

	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		rb2D.velocity = Vector2.down * speed;
	}
		
	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Enemy") {
			Destroy (collider.gameObject);
			Destroy (gameObject);
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.gameObject.tag == "Platform") {
			Destroy (gameObject);
		}
	}
}

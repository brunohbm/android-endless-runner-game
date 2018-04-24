using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWithAttackController : MonoBehaviour {
	
	public float speed;
	public float xPosition;

	public float distance;

	private Animator animator;
	private Transform player;

	void Start () {
		animator = GetComponent<Animator> ();
		player = GameObject.Find("Player").transform;
	}

	void Update () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.left * speed;

		if (Vector3.Distance (player.position, transform.position) <= distance) {
			distance = 0;
			animator.SetTrigger ("attack");
		}

		if (xPosition >= transform.position.x) {
			Destroy (gameObject);
		}

		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo(0).IsName("Dead")) {
			speed = 0;
		}

		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo(0).IsName("End")) {
			Destroy (gameObject);
		}
	}
}

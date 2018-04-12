using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float jumpForce;
	public bool onFloor;

	private Rigidbody2D rb2D;
	private Animator animator;
	private Score score;

	void Start () {
		score = FindObjectOfType<Score> ();
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	void Update () {
		if (!onFloor) {
			JumpAnimation ();
			return;
		}
		if (onFloor && CrossPlatformInputManager.GetButtonDown("jump")) {
			Jump ();
		}
	}

	public void Jump() {
		rb2D.AddForce (Vector2.up * jumpForce, ForceMode2D.Force);
	}

	void JumpAnimation() {
		if (rb2D.velocity.y > 0) {
			animator.SetTrigger ("jump");
			return;
		}

		if (rb2D.velocity.y < 0) {
			animator.SetTrigger ("fall");
			animator.ResetTrigger ("jump");
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Platform") {			
			onFloor = true;
			animator.SetBool ("onFloor", true);
			animator.ResetTrigger ("fall");
		}

		if (collision.gameObject.tag == "Enemy") {			
			score.SaveScore ();
			SceneManager.LoadScene ("GameOver", LoadSceneMode.Single);
		}
	}

	void OnCollisionExit2D (Collision2D collision) {
		if (collision.gameObject.tag == "Platform") {
			onFloor = false;
			animator.SetBool ("onFloor", false);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2D;
	private Score score;

	void Start () {
		score = FindObjectOfType<Score> ();
		rb2D = GetComponent<Rigidbody2D> ();
		rb2D.velocity = Vector2.down * speed;
	}
		
	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Enemy") {
			StartCoroutine (Kill(collider.gameObject));
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.gameObject.tag == "Platform") {
			Destroy (gameObject);
		}
	}

	IEnumerator Kill (GameObject enemy) {
		enemy.GetComponent<Animator> ().SetTrigger("die");
		yield return new WaitForSeconds (0.06f);
		Destroy (enemy);
		this.score.AddScore (1);
		Destroy (this.gameObject);
	}
}

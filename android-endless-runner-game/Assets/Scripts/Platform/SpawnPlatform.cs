using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {

	public Vector3 endPosition = new Vector3 (-10.6f, -2.73f, 0);
	public float speed;

	void Update () {
		Moviment ();
	}

	void Moviment () {
		transform.position = Vector3.MoveTowards (transform.position, endPosition, speed);
		if (Vector3.Distance (transform.position, endPosition) == 0)
			Destroy (gameObject);
	}
}


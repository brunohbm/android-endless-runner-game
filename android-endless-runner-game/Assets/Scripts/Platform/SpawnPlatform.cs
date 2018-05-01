using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {

	public Vector3 endPosition;

	void Update () {
		Moviment ();
	}

	void Moviment () {
		transform.position = Vector3.MoveTowards (transform.position, endPosition, 0.05f);
		if (Vector3.Distance (transform.position, endPosition) == 0)
			Destroy (gameObject);
	}
}


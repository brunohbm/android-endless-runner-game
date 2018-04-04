using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Values;

public class PlatformAnimationControler : MonoBehaviour {

	void Update () {
		Moviment ();
		TestPosition ();
	}

	void Moviment () {
		transform.position = Vector3.MoveTowards (transform.position, Platform.endPosition, Platform.speed);
		if (Vector3.Distance (transform.position, Platform.endPosition) == 0)
			transform.position = Platform.startPosition;
	}

	void TestPosition () {
		if (transform.position.Equals (Platform.endPosition))
			transform.position = Platform.startPosition;
	}
}

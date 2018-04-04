using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public float speed;

	public Transform startImage;
	public Transform endImage;

	private Vector3 startPosition;
	private Vector3 endPosition;

	void Start () {
		float xPosition = Vector3.Distance (startImage.localPosition, endImage.localPosition) + startImage.localPosition.x;	
		startPosition = new Vector3 (xPosition, startImage.localPosition.y, 0);
		endPosition = endImage.localPosition;
	}

	void Update () {
		Move (startImage);
		Move (endImage);
	}

	void Move (Transform image) {
		image.localPosition = Vector3.MoveTowards (image.localPosition, endPosition, speed);
		if (Vector3.Distance (image.localPosition, endPosition) <= 0.05) {			
			image.localPosition = startPosition;
		}
	}
}

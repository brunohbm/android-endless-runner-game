using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResize : MonoBehaviour {

	public float defaultWidht;
	public float defaultHeight;

	void Start () {
		GetComponent<Camera> ().aspect = defaultWidht / defaultHeight;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GunController : MonoBehaviour {

	public float shotInterval;

	public GameObject bulletPrefab;

	private bool canShot = true;

	void Update () {
		if (CrossPlatformInputManager.GetButtonDown ("fire") && canShot) { 
			canShot = false;
			StartCoroutine (Shot ());
		}
	}

	public IEnumerator Shot () {
		Instantiate (bulletPrefab, transform.position, transform.rotation);
		yield return new WaitForSeconds (shotInterval);
		canShot = true;
	}
}

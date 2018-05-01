using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesInstantiateController : MonoBehaviour {

	public float instanceInterval;

	public GameObject[] enemies;

	private bool canInstance = true;
	private float controlTime;

	void Update () {
		if (canInstance) {
			canInstance = false;
			StartCoroutine (InstantiateEnemy ());
		}
	}

	IEnumerator InstantiateEnemy () {
		int i = Random.Range (0, enemies.Length);
		Instantiate (enemies [i]);
		if (enemies [i].tag == "Enemy") {
			controlTime = 0.5f;
		} else { 
			controlTime = 1;
		}
		yield return new WaitForSeconds (instanceInterval * controlTime);
		canInstance = true;
	}

	void OnEnable() {
		canInstance = true;
	}
}

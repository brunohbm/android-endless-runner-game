using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesInstantiateController : MonoBehaviour {

	public float instanceInterval;

	public GameObject[] enemies;

	private bool canInstance = true;

	void Update () {
		if (canInstance) {
			canInstance = false;
			StartCoroutine (InstantiateEnemy ());
		}
	}

	IEnumerator InstantiateEnemy () {
		int i = Random.Range (0, enemies.Length);
		Instantiate (enemies [i]);
		yield return new WaitForSeconds (instanceInterval);
		canInstance = true;
	}
}

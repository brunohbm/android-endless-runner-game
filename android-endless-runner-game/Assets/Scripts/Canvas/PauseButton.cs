using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

	private bool paused;

	public GameObject pausePanel;
	public GameObject enemiesInst;

	void Start () {
		paused = false;
	}

	void Update () {
		if (CrossPlatformInputManager.GetButtonDown("pause")) {
			paused = !paused;
			ChangeMenuState (paused);
		}
	}

	void ChangeMenuState (bool state) {
		if (state) {
			ActiveMenu ();
			return;
		}
		DesactiveMenu ();
	}

	void ActiveMenu () {
		if (GameObject.FindWithTag("Enemy") != null) 
		Destroy (GameObject.FindWithTag("Enemy"));
		
		pausePanel.SetActive (true);
		enemiesInst.SetActive (false);
	}

	void DesactiveMenu () {
		pausePanel.SetActive (false);
		enemiesInst.SetActive (true);
	}
}

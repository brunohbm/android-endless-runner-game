using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour {

	void Update () {
		if (CrossPlatformInputManager.GetButtonDown ("start")) {
			StartGame ();
			return;
		}

		if (CrossPlatformInputManager.GetButtonDown ("quit")) {
			QuitGame ();
		}
	}

	void StartGame () {
		SceneManager.LoadScene ("Game", LoadSceneMode.Single);
	}

	void QuitGame () {
		Application.Quit ();
	}
}

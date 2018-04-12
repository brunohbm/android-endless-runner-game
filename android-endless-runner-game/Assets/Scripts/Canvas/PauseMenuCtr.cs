using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PauseMenuCtr : MonoBehaviour {

	void Update () {
		if (CrossPlatformInputManager.GetButtonDown("menu")) {
			SceneManager.LoadScene ("Menu");
			return;
		}

		if (CrossPlatformInputManager.GetButtonDown("scoreScene")) {
			SceneManager.LoadScene ("GameOver");
			FindObjectOfType<Score> ().SaveScore ();
		}
	}
}

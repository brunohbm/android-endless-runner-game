using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameOverScreen : MonoBehaviour {

	void Update () {
		if (CrossPlatformInputManager.GetButtonDown ("return"))
			SceneManager.LoadScene ("Game", LoadSceneMode.Single);

		if (CrossPlatformInputManager.GetButtonDown ("menu"))
			SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

	private bool paused;

	private Image btnImage;

	public GameObject pausePanel;
	public GameObject enemiesInst;
	public Sprite newSprite;

	void Start () {
		paused = false;
		btnImage = GetComponent<Image> ();
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

		ChangeSprite ();
		pausePanel.SetActive (true);
		enemiesInst.SetActive (false);
	}

	void DesactiveMenu () {
		ChangeSprite ();
		pausePanel.SetActive (false);
		enemiesInst.SetActive (true);
	}

	void ChangeSprite() {
		Sprite oldSprite = btnImage.sprite;
		btnImage.sprite = newSprite;
		newSprite = oldSprite;
	}
}

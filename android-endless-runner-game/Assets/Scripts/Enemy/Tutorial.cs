using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public Transform player;
	public Transform enemy;
	public GameObject enemiesInst;
	public Image goImage;
	public Image rightImage;
	public Image leftImage;

	PlayerController playerController;
	GunController gunController;

	int step = 0;

	void Start () {
		if (PlayerPrefs.GetInt("record", 0) > 0) {
			Destroy (enemy.gameObject);
			FinishTutorial ();
		}
		playerController = FindObjectOfType<PlayerController> ();
		gunController = FindObjectOfType<GunController> ();
	}

	void Update () {
		if (enemy != null) {
			if (Vector3.Distance(enemy.position, player.position) <= 1.3F && step == 0) {
				JumpAction ();
				return;
			}

			if (Vector3.Distance(enemy.position, player.position) >= 2.5F && step == 1) {
				ShotAction ();
			}
			return;
		}

		if (step == 3) {
			StartCoroutine (ImagesControl(goImage, 0.04F));
			step++;
		}

		if (step == 5) {
			FinishTutorial ();
		}
	}

	void JumpAction() {
		StartCoroutine (ImagesControl(rightImage, 0.01F));
		playerController.Jump ();
		step++;
	}

	void ShotAction () {
		StartCoroutine (ImagesControl(leftImage, 0.01F));
		StartCoroutine (gunController.Shot());
		step++;
	}

	IEnumerator ImagesControl (Image image, float time) {
		for (int cont = 0; cont < 20; cont ++)  {
			image.color += new Color (0, 0, 0, 0.05F);
			yield return new WaitForSeconds (time);
		}

		for (int cont = 0; cont < 20; cont ++)  {
			image.color -= new Color (0, 0, 0, 0.05F);
			yield return new WaitForSeconds (time);
		}						

		if (step >= 2)
			step++;
	}

	void FinishTutorial () {
		enemiesInst.SetActive (true);
		Destroy (goImage.gameObject);
		Destroy (leftImage.gameObject);
		Destroy (rightImage.gameObject);
		Destroy (gameObject);
	}
}

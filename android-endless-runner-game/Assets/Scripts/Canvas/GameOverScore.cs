using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

	private Text scoreText;
	private Text recordText;

	void Start () {
		scoreText = gameObject.transform.Find ("Score").GetComponent<Text>();
		recordText = gameObject.transform.Find ("Record").GetComponent<Text>();
		SetScore ();
		SetRecord ();
	}

	void SetRecord () {
		int score = PlayerPrefs.GetInt("score");
		int record = PlayerPrefs.GetInt("record", 0);

		if (score > record) {
			PlayerPrefs.SetInt ("record", score);
			record = score;
		}

		recordText.text = record.ToString ();
	}

	void SetScore () {
		scoreText.text = PlayerPrefs.GetInt ("score").ToString ();
	}
}

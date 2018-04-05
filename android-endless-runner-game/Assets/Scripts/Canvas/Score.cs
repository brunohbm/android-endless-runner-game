using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private Text score;

	void Start () {
		score = GetComponent<Text> ();
	}

	public void AddScore (int points) {
		int totalScore = int.Parse (score.text) + points;
		score.text = totalScore.ToString();
	}

	public void SaveScore () {
		PlayerPrefs.SetInt ("score", int.Parse(score.text));
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int score = 0;

	private static Text scoreText;

	void Start(){
		scoreText = GameObject.Find("score").GetComponent<Text>();
		scoreText.text = "score\n" + 0;
	}
	
	public static void IncreaseScore(int val){
		score = int.Parse(Regex.Match(scoreText.text, @"\d+").Value) + 1;
		scoreText.text = "score\n" + score;

		if(score % 10 == 0){
			DifficultyManager.SpeedUp();
			Debug.Log ("getting harder ;)");

		}
	}
}

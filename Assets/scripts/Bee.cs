using UnityEngine;
using System.Collections;

public class Bee : MonoBehaviour {
	private Renderer renderer;
	private GameObject enemyManager;
	private bool becameVisible = false;
	private Vector3 startPos;
	private float flySpeed;

	void Awake(){
		renderer = GetComponent<Renderer> ();
		startPos = transform.position;
		flySpeed = Random.Range (1, 4);
	}

	void Update () {
		Move ();

		if(renderer.isVisible){
			becameVisible = true;
		}

		if(!renderer.isVisible && becameVisible){
			gameObject.SetActive(false);
			becameVisible = false; 
			ScoreManager.IncreaseScore(1); //should use an event instead
		}
	}

	void Move(){
		//basic trigonometry baffles local programmer
		transform.position = new Vector3(transform.position.x - 1 * Time.deltaTime * EnemyManager.enemySpeed, startPos.y + Mathf.Sin(Time.time * flySpeed), 0);
	}
}

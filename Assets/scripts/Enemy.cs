using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public Vector3 spawnOffset;
	
	private Renderer childRenderer;
	private GameObject enemyManager;
	private bool becameVisible = false;

	void Awake(){
		childRenderer = GetComponentInChildren<Renderer>();
	
	}
	
	void Update () {
		transform.position += Vector3.left * Time.deltaTime * EnemyManager.enemySpeed;

		if(childRenderer.isVisible){
			becameVisible = true;
		}

		if(!childRenderer.isVisible && becameVisible){
			gameObject.SetActive(false);
			becameVisible = false; 
			ScoreManager.IncreaseScore(1); //should use an event instead
		}
	}
}

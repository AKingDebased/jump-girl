using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public Vector3 spawnOffset;
	
	private Renderer childRenderer;
	private GameObject enemyManager;
	private bool becameVisible = false;

	void Awake(){
		spawnOffset = new Vector3(transform.position.x,-1.0f,transform.position.z);
		childRenderer = transform.GetChild (0).GetComponent<Renderer>();
		enemyManager = GameObject.Find ("enemy manager");
	}
	
	void Update () {
		transform.position += Vector3.left * Time.deltaTime * EnemyManager.enemySpeed;

		if(childRenderer.isVisible){
			becameVisible = true;
		}

		if(!childRenderer.isVisible && becameVisible){
			gameObject.SetActive(false);
			becameVisible = false; 
			enemyManager.SendMessage ("SpawnEnemy"); //this has gotta go
		}
	}
}

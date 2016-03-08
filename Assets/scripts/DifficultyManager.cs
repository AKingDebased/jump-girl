using UnityEngine;
using System.Collections;

public class DifficultyManager : MonoBehaviour {

	public float spawnTimeMin = 2.0f;
	public float spawnTimeMax = 5.0f;

	private static int increaseValue = 3;
	private EnemyManager enemyManager;
	private float timer;
	private float spawnTime;

	void Start(){
		enemyManager = GameObject.Find ("enemy manager").GetComponent<EnemyManager> ();
		spawnTime = Random.Range (spawnTimeMin, spawnTimeMax);
	}

	void Update(){
		timer += Time.deltaTime;

		if (timer >= spawnTime) {
			enemyManager.SpawnEnemy ();
			spawnTime = Random.Range (spawnTimeMin, spawnTimeMax);
			timer = 0.0f;
		}
	}

	//should use event system to target ground, bg elements, & enemies
	public static void SpeedUp(){

	}


}

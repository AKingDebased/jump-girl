using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

	public GameObject[] enemies;
	public Transform spawnPoint;
	public List<GameObject> pooledEnemies;
	public static float enemySpeed = 3.0f;

	private GameObject enemyContainer;

	void Awake(){
		pooledEnemies = new List<GameObject>();
		enemyContainer = GameObject.Find ("enemies");
		CreatePool ();
		SpawnEnemy ();
	}
	

	public void SpawnEnemy(){
		GameObject enemy = GetPooledEnemy();
		enemy.transform.position = spawnPoint.position;
		enemy.SetActive(true);
	}

	void CreatePool(){
		foreach(GameObject enemy in enemies){
			GameObject newEnemy = (GameObject)Instantiate (enemy);
			newEnemy.transform.SetParent(enemyContainer.transform);
			newEnemy.SetActive(false);
			pooledEnemies.Add(newEnemy);
		}
	}

	public GameObject GetPooledEnemy(){
		//int randNum = Random.Range(0,3);

		for(int i = 0; i < pooledEnemies.Count; i++){
			if(!pooledEnemies[i].activeInHierarchy){
				return pooledEnemies[i];
			}
		}

		return null;
	}
}

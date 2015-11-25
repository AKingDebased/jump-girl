using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

	public GameObject[] enemies;
	public Transform spawnPoint;
	public List<GameObject> pooledEnemies;

	private GameObject enemyContainer;

	void Awake(){
		enemyContainer = GameObject.Find ("enemies");
		CreatePool ();
		SpawnEnemy ();
	}

	public void SpawnEnemy(){
		GameObject enemy = GetPooledEnemyAtRandom ();
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

	GameObject GetPooledEnemyAtRandom(){
		int randNum = Random.Range(0,3);

		for(int i = 0; i < pooledEnemies.Count; i++){
			if(!pooledEnemies[i].activeInHierarchy && i == randNum){
				return pooledEnemies[i];
			}
		}

		return null;
	}
}

using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	public static float platformSpeed = 3.5f;
	public Transform spawn;
	public GameObject[] platforms;
	public List<GameObject> pooledPlatforms;
	public float spawnTime = 1.0f;

	private GameObject platformContainer;
	private float timer = 0.0f;

	void Awake(){
		platformContainer = GameObject.Find ("platforms");
		CreatePool ();
	}
//
//	void Update(){
//		timer += Time.deltaTime;
//
//		if(timer >= spawnTime){
//			SpawnPlatform();
//			timer = 0.0f;
//		}
//	}

	public void SpawnPlatform(){
		GameObject randPlatform = GetRandomPlatform();

		randPlatform.transform.position = spawn.position;

	}
	
	void CreatePool(){
		foreach(GameObject platform in platforms){
			GameObject newPlatform = (GameObject)Instantiate (platform);
			newPlatform.transform.SetParent(platformContainer.transform);
			newPlatform.SetActive(false);
			pooledPlatforms.Add(newPlatform);
		}
	}

	GameObject GetRandomPlatform(){
		int randNum = Random.Range (0,3);

		for(int i = 0; i < pooledPlatforms.Count; i++){
			if(!pooledPlatforms[i].activeInHierarchy && i == randNum){
				pooledPlatforms[i].SetActive(true);
				return pooledPlatforms[i];
			}
		}

		return null;
	}
}

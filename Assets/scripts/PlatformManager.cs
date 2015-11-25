using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	public static float platformSpeed = 2.5f;
	public Transform spawn;
	public GameObject[] platforms;

	private GameObject platformContainer;
	public List<GameObject> pooledPlatforms;

	void Awake(){
		platformContainer = GameObject.Find ("platforms");
		CreatePool ();
	}

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

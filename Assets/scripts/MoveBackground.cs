using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {

	private Transform offscreenSpawn;

	void Awake(){
		offscreenSpawn = GameObject.Find ("offscreen bg spawn").transform;
	}

	void OnBecameInvisible(){
		transform.position = offscreenSpawn.position;
		Debug.Log ("resetting");
	}

	void Update(){
		transform.position += Vector3.left * Time.deltaTime * BackgroundManager.bgSpeed;
	}
}

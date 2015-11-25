using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

	public static float bgSpeed = 2.5f;
	public Transform offScreenSpawn;
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "background"){
			other.gameObject.transform.position = offScreenSpawn.position;
		}
	}
}

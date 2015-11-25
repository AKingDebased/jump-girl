using UnityEngine;
using System.Collections;

public class GroundManager : MonoBehaviour {
	
	public static float groundSpeed = 4.5f;
	public Transform offScreenSpawn;
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "ground"){
			other.gameObject.transform.position = offScreenSpawn.position;
		}
	}
}

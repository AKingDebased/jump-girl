using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {
	
	void Update(){
		transform.position += Vector3.left * Time.deltaTime * PlatformManager.platformSpeed;
	}
}

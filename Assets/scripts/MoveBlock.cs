using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {
	
	void Update(){
		transform.position += Vector3.left * Time.deltaTime * GroundManager.groundSpeed;
	}
}

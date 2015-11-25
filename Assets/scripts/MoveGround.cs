using UnityEngine;
using System.Collections;

public class MoveGround : MonoBehaviour {

	void Update(){
		transform.position += Vector3.left * Time.deltaTime * GroundManager.groundSpeed;
	}
}

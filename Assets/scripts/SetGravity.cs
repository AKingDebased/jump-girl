using UnityEngine;
using System.Collections;

public class SetGravity : MonoBehaviour {

	public float strength = -9.81f;

	void Start () {
		Physics.gravity = new Vector3(0, strength, 0);
		Debug.Log (Physics.gravity);
	
	}
	

}

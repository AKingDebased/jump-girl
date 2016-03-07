using UnityEngine;
using System.Collections;

public class ScrollGround : MonoBehaviour {

	public float speed = 5f;
	
	private Renderer renderer;

	void Start(){
		renderer = GetComponent<Renderer>();
	}

	void Update () {
		Vector2 offset = new Vector2(Time.deltaTime / speed,0);

		renderer.material.mainTextureOffset += offset;
	}
}

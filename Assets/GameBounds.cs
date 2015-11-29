using UnityEngine;
using System.Collections;

public class GameBounds : MonoBehaviour {

	private Vector3 gameBounds;
	private BoxCollider2D collider;

	void Awake(){
		collider = GetComponent<BoxCollider2D>();
	}

	void Start () {
		gameBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
		collider.size = new Vector2(gameBounds.x,gameBounds.y);
	
	}
	

}

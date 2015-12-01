using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	private BoxCollider2D collider;
	private Vector3 convertedWidth;

	void Awake(){
		collider = GetComponent<BoxCollider2D>();
		convertedWidth = Camera.main.WorldToScreenPoint(collider.bounds.size);
	}

	void Update(){
		transform.position += Vector3.left * Time.deltaTime * PlatformManager.platformSpeed;

		Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
		if(screenPos.x <= -convertedWidth.x / 2){
			screenPos.x = Screen.width + convertedWidth.x;
			transform.position = Camera.main.ScreenToWorldPoint(screenPos);
		}
	}
	
	public void Despawn(){
		gameObject.SetActive(false);
	}
}
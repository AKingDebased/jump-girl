﻿using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	
	private BoxCollider2D collider;
	private Vector3 convertedWidth;
	private bool becameVisible = false;
	private Renderer endBlockRenderer;
	private GameObject platformManager;

	void Awake(){
		collider = GetComponent<BoxCollider2D>();
		convertedWidth = Camera.main.WorldToScreenPoint(collider.bounds.size);
		endBlockRenderer = transform.Find ("end block").GetComponent<Renderer>();
		platformManager = GameObject.Find ("platform manager");
	}

	void Update(){
		transform.position += Vector3.left * Time.deltaTime * PlatformManager.platformSpeed;

//		Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
//		if(screenPos.x <= -convertedWidth.x / 2){
//			screenPos.x = Screen.width + convertedWidth.x;
//			transform.position = Camera.main.ScreenToWorldPoint(screenPos);
//		}

		if(endBlockRenderer.isVisible){
			becameVisible = true;
		}

		if(!endBlockRenderer.isVisible && becameVisible){
			Despawn ();
			becameVisible = false; 
			platformManager.SendMessage ("SpawnPlatform"); //this has gotta go
		}
	}
	
	public void Despawn(){
		gameObject.SetActive(false);
	}
}
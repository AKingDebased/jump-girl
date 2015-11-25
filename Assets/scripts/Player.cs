using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpPower = 1.0f;
	public LayerMask groundLayer;
	
	private Rigidbody2D rigidBody;
	private bool isGrounded;
	private Animator anim;
	private Collider2D collider;

	void Start () {
		collider = GetComponent<Collider2D>();
		rigidBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update(){
		isGrounded = Physics2D.IsTouchingLayers(collider,groundLayer);
		anim.SetBool("isGrounded",isGrounded);
	}

	void FixedUpdate () {
		if(Input.GetKeyDown("space") && isGrounded){
			rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpPower);
		}
	}
}

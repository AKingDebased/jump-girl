using UnityEngine;
using System.Collections;

public class Jumping : MonoBehaviour {

	public float jumpPower = 1.0f;
	public float bodyToGround = .6f;
	
	private Rigidbody2D rigidBody;
	private bool isGrounded;
	private int groundLayer;
	private Animator anim;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		groundLayer = LayerMask.NameToLayer("ground");
	}

	void Update(){
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,bodyToGround);
		isGrounded = (hit.collider != null);
		anim.SetBool("isGrounded",isGrounded);
	}

	void FixedUpdate () {
		if(Input.GetKeyDown("space") && isGrounded){
			rigidBody.AddForce(Vector2.up * jumpPower);
		}
	}
}

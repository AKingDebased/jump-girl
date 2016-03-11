using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpPower = 1.0f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float groundCheckRadius = 1.0f;
	
	private Rigidbody2D rigidBody;
	private bool isGrounded;
	private Animator anim;
	private Collider2D collider;
	private float deathForce = 400f;

	void Start () {
		collider = GetComponent<Collider2D>();
		rigidBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update(){
		isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
		anim.SetBool("isGrounded",isGrounded);

		if(Input.GetKeyDown("space") && isGrounded){
			rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpPower);
		}
	}
		
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "enemy") {
			Die ();
		}
	}

	void Die(){
		collider.enabled = false;
		anim.SetTrigger ("isDead");

		//seriously need some kind of subscription system to handle speed of background and enemies
		EnemyManager.enemySpeed = 0f;
		rigidBody.velocity = Vector2.zero; //make sure the mario-death-force doesn't fly off the screen
		rigidBody.AddForce (Vector2.up * Time.deltaTime * deathForce,ForceMode2D.Impulse);
		StartCoroutine (DelayedDestroy(3));
	}

	IEnumerator DelayedDestroy(float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		Debug.Log("waited " + delayTime + " seconds");
		Destroy (gameObject);
	}
}

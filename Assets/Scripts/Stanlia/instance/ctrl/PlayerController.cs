using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 0.01f;
	public float jumpTime = 0.5f;
	public float jumpSpeed = 0.5f;
	// Use this for initialization
	private GameObject player;
	private bool isGrounded = true;
	private Animator playerAnimator;
	public bool FaceRight { get; private set; }
	public float jumpDelay = 0.5f;
	public float currentJumpDelay = 0.0f;
//	private bool flipSprite = false;
	void Start () {
		//get the player
		player = GameObject.Find ("link");
		playerAnimator = player.GetComponent<Animator> ();
		FaceRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
		Vector3 moveVector = new Vector3 (0, 0, 0);
		float factor = 1.0f;
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) {
			if (Input.GetKey(KeyCode.LeftArrow)) {
//				flipSprite = true;
				factor = -1.0f;
			}

			if (isGrounded){
				if (!stateInfo.IsName("Base.player_run")) {
					playerAnimator.SetInteger ("player_state", 1);			
				}
				else {
					playerAnimator.SetInteger("player_state", 2);
					factor *= 2f;
				}
			}
			flipSprite(factor>0);
		} else {
			if (isGrounded) playerAnimator.SetInteger ("player_state", 0);
			factor = 0f;
		}
		moveVector.x += factor * speed;

		transform.position += moveVector;

		if (Input.GetKey (KeyCode.Space) && isGrounded && currentJumpDelay <= 0.0f) {
			isGrounded = false;
			playerAnimator.SetBool ("is_grounded", false);
			player.gameObject.rigidbody2D.AddForce(Vector3.up * jumpSpeed);
		}
		if (currentJumpDelay > 0.0f) currentJumpDelay -= Time.deltaTime;
	}
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Block" && !isGrounded){
			isGrounded = true;

			playerAnimator.SetBool("is_grounded", true);
			currentJumpDelay = jumpDelay;
		}
	}
	private void flipSprite(bool isRight)
	{
		if (isRight == FaceRight)
			return;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		FaceRight = !FaceRight;
	}
}

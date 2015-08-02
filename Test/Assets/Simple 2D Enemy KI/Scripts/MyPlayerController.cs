using UnityEngine;
using System.Collections;

/*
 * Example player for PlayerFollowing on Scene:
 * 
 * 2 EnemyAutoWalkAndPlayerFollowing
 */
public class MyPlayerController : MonoBehaviour {

	public float MoveForce = 700f;
	public float MaxSpeed = 0.05f;
	public float JumpForce = 27f;

	public Transform GroundCheck;
	private bool grounded = false;
	private LayerMask whatIsGround;
	
	private Animator anim = null;

	private float highestJumpCoordinate = 0.0f;
	private BoxCollider2D PlayerBoxCollider;
	[HideInInspector]
	public PolygonCollider2D PlayerPolygonCollider;
	//added
	private bool PlayerDie = false;

	[HideInInspector]
	public bool PlayerBlinkt = false;

	private bool jump = false;
	private bool facingRight = true;
	private bool jumpInProgress = false;
	private float horizontal;

	//added
	public Renderer rend;


	void Awake(){
		rend = GetComponent<Renderer>();
		rend.enabled = true;

		anim = GetComponent<Animator> ();

		whatIsGround = LayerMask.GetMask (EnemyAWConst.GROUND);

		InitRigidbodyUndCollider();
	}

	public void InitRigidbodyUndCollider(){

		transform.parent = null;
		
		PlayerPolygonCollider = GetComponent<PolygonCollider2D> ();
		PlayerPolygonCollider.enabled = true;
		
		PlayerBoxCollider = GetComponent<BoxCollider2D>();
		PlayerBoxCollider.enabled = true;
		PlayerBoxCollider.isTrigger = false;
		
		if (GetComponent<Rigidbody2D>() == null) {
			gameObject.AddComponent<Rigidbody2D> ();
			
			GetComponent<Rigidbody2D>().mass = 2;
			GetComponent<Rigidbody2D>().gravityScale = 3;
			GetComponent<Rigidbody2D>().fixedAngle = true;
			GetComponent<Rigidbody2D>().interpolation =  RigidbodyInterpolation2D.Interpolate;
			GetComponent<Rigidbody2D>().angularDrag = 0.05f;
			GetComponent<Rigidbody2D>().drag = 1;
		}
	}

	private bool InitJumpBeforeFixedUpdate(){

		bool doJump = true;

		// Dont jump if cursor down
		if(Input.GetButtonDown(EnemyAWConst.VERTICAL)){
			if((Input.GetAxis(EnemyAWConst.VERTICAL) < 0)) {
				doJump = false;
			}
		}
		
		if(doJump){
			jump = true;
		}			


		if(jump){

			if(GetComponent<Rigidbody2D>() != null){
				highestJumpCoordinate = gameObject.transform.localPosition.y;
			}
		}
		
		return jump;
	}


	void Update(){


		if(gameObject.transform.position.y >  5.0f){
			rend.enabled = true;
		}

		grounded = Physics2D.OverlapCircle (GroundCheck.position, 0.15f, whatIsGround);
			
		if (PlayerDie) {

			int rotateValue = 16;
			
			if(facingRight){
				rotateValue *= -1;
			}
			
			transform.Rotate(0, 0, rotateValue);

			if(GetComponent<Rigidbody2D>() != null){
				Destroy(GetComponent<Rigidbody2D>());
			}

			PlayerPolygonCollider.enabled = false;
			Destroy (gameObject, 2);

			Application.LoadLevel(Level.CurrentLevel);

		} else {
			if (grounded) {
				anim.SetBool(EnemyAWConst.GROUND, true);
				anim.SetBool (EnemyAWConst.JUMP, false);
				
				anim.SetFloat( EnemyAWConst.SPEED, Mathf.Abs( horizontal ) );
			} else {
				anim.SetBool(EnemyAWConst.GROUND, false);
				anim.SetBool (EnemyAWConst.JUMP, true);
				
				anim.SetFloat( EnemyAWConst.SPEED, 0.0f);
			}
			
			if( grounded && Input.GetButtonDown(EnemyAWConst.VERTICAL)) {
				InitJumpBeforeFixedUpdate();
			}
			
			if (jumpInProgress) {
				
				// Player jump through the walls
				float actualY = gameObject.transform.localPosition.y;
				
				if(actualY > highestJumpCoordinate){
					highestJumpCoordinate = actualY;
				} else {
					PlayerBoxCollider.isTrigger = false;
					jumpInProgress = false;
					
				}
			}
		}
	}
	
	void FixedUpdate () {

		if (!PlayerDie) {
			horizontal = Input.GetAxis(EnemyAWConst.HORIZONTAL);
			horizontal = Mathf.Clamp( horizontal, -1f, 1f );
			
			if(GetComponent<Rigidbody2D>() != null){
				if( horizontal * GetComponent<Rigidbody2D>().velocity.x < MaxSpeed )
					GetComponent<Rigidbody2D>().AddForce( Vector2.right * horizontal * MoveForce );
				
				if( Mathf.Abs( GetComponent<Rigidbody2D>().velocity.x ) > MaxSpeed )
					GetComponent<Rigidbody2D>().velocity = new Vector2( Mathf.Sign( GetComponent<Rigidbody2D>().velocity.x ) * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y );
			}
			
			if( horizontal > 0f && !facingRight ) {
				Flip();
			
				
			} else if( horizontal < 0f && facingRight ) {
				Flip();

			}
			
			if (jump) {
				jump = false;
				
				if (grounded) {
					
					PlayerBoxCollider.isTrigger = true;
					
					GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
					GetComponent<Rigidbody2D>().AddForce (Vector2.up * JumpForce, ForceMode2D.Impulse);
					
					jumpInProgress = true;
					
				}
			}
		}
	}
	
	void Flip(){
		
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals (EnemyAWConst.ENEMY)) {
			PlayerDie = true;
		}

		if (col.gameObject.tag.Equals (EnemyAWConst.SHOT)) {
			PlayerDie = true;
			Destroy (col.gameObject);
		}
		if(col.gameObject.tag.Equals(EnemyAWConst.COLLIDER)){
			rend.enabled = false;
			gameObject.transform.position = new Vector3(0, 5.39f, 0);
		}
	}
}

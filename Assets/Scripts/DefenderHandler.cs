using UnityEngine;
using System.Collections;

public class DefenderHandler : MonoBehaviour {

	public Camera myCamera;

	[Range (0, 5)]		
	public float movingSpeed;


	private GameObject playerParent;
	private Defender defender;
	
	private Vector2 destination;
	private float xSpeed, ySpeed;
	// Use this for initialization
	void Start () {	
		playerParent = GameObject.Find("Player");	
		if (!playerParent) {playerParent = new GameObject("Player");}
		
		defender = GameObject.FindObjectOfType<Defender>();
		if (defender) {
			defender.transform.parent = playerParent.transform;
		}
		
		destination = defender.transform.position;
	}

	void OnMouseDown(){ 
		if (!defender.isMoving) {
			defender.isMoving = true;
			MovePlayer();
		}
	}

	void Update () {
		if (defender.isMoving) {
			Vector2 currentPos = new Vector2 (Mathf.RoundToInt(defender.transform.position.x), Mathf.RoundToInt(defender.transform.position.y));
			Vector2 offset = new Vector2 (Mathf.Abs (defender.transform.position.x - destination.x),
										  Mathf.Abs (defender.transform.position.y - destination.y));			
										  
			if (defender.transform.position.x < destination.x && offset.x >= 0.1f) {
				defender.transform.Translate(Vector3.right * Time.deltaTime * xSpeed);
				FaceDefenderRight ();
			} else if (defender.transform.position.x > destination.x && offset.x >= 0.1f) {
				defender.transform.Translate(Vector3.left * Time.deltaTime * xSpeed);
				FaceDefenderLeft ();
			}
					
			if (defender.transform.position.y < destination.y && offset.y >= 0.1f ) {
				defender.transform.Translate(Vector3.up * Time.deltaTime * ySpeed); 
			} else if (defender.transform.position.y > destination.y && offset.y >= 0.1f) {
				defender.transform.Translate(Vector3.down * Time.deltaTime * ySpeed);
			}
			
			if (currentPos == destination && offset.x <= 0.1f && offset.y <= 0.1f) {
			
				FaceDefenderRight();
			
				defender.isMoving = false;
				defender.SetRunning (false);
				defender.transform.position = destination;
			}
		}
	}

	void FaceDefenderLeft ()
	{
		Vector3 theScale = defender.transform.localScale;
		if (theScale.x > 0) {
			theScale.x *= -1;
			defender.transform.localScale = theScale;
		}
	}

	Vector3 FaceDefenderRight ()
	{
		Vector3 theScale = defender.transform.localScale;
		if (theScale.x < 0) {
			theScale.x *= -1;
			defender.transform.localScale = theScale;
		}
		return theScale;
	}

	void MovePlayer ()
	{
		destination = MousePosition();
		float xOffset = Mathf.Abs (defender.transform.position.x - destination.x);
		float yOffset = Mathf.Abs (defender.transform.position.y - destination.y);
		
		if (xOffset == 0 && yOffset == 0) {
			defender.isMoving = false;
			return;
		}
		
		if (xOffset > yOffset) {
			xSpeed = movingSpeed;
			ySpeed = xSpeed / xOffset * yOffset;
		} else if (yOffset > xOffset) {
			ySpeed = movingSpeed;
			xSpeed = ySpeed / yOffset * xOffset;
		} else {
			xSpeed = ySpeed = movingSpeed;
		}
		
		defender.SetAttack (false);
		defender.isMoving = true;
		defender.SetRunning (true);

	}
	
	Vector2 MousePosition (){
		return SnapToGrid(CalculateWorldPointOfMouseClick());
	}
	
	Vector2 SnapToGrid (Vector2 rawWorldPos){
		Vector2 v = new Vector2 (Mathf.RoundToInt(rawWorldPos.x), Mathf.RoundToInt(rawWorldPos.y));
		
		// Make sure the player never moves out of the grid's boundaries (The grid size is 5 x 9 )
		if (v.x < 1) { v.x = 1;}
		else if (v.x > 9) { v.x = 9;}
		if (v.y < 1) { v.y = 1;}
		else if (v.y > 5) { v.y = 5;}
		return v;
	}
	
	Vector2 CalculateWorldPointOfMouseClick () {
		Vector3 p = myCamera.ScreenToWorldPoint(Input.mousePosition);
		return new Vector2 (p.x, p.y);
	}
}

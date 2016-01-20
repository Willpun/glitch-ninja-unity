using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;

	private float mySpeed;
	private GameObject currentTarget;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * mySpeed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D other){
//		Debug.Log (name + " trigger enter with " + other);
	}
	
	public void SetSpeed(float speed){
		mySpeed = speed;
	}
	
	// Called from animator at the time of the actual blow
	public void StrikeCurrentTarget(float damage){
	
		if(currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if(health) {
				health.DealDamage(damage);
			}
		}
	}
	
	public void Attack (GameObject obj) {
		currentTarget = obj;
	}
}

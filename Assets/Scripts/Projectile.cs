using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;
	[Tooltip ("How many targets can be hit by this projectile before it got destroyed")]
	public int numberOfTargetsPierced = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
		if (speed <= 2.5f) {
			transform.Translate(Vector3.down * 0.35f * Time.deltaTime );
			Destroy (gameObject, 1.25f);
		}
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		Health health = collider.GetComponent<Health>();
		if (health && collider.GetComponent<Attacker>()) {
			health.DealDamage(damage);
			if (numberOfTargetsPierced <= 1) {
				Destroy (gameObject);
			} else {
				numberOfTargetsPierced--;
			}
		}
		
	}
}

using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float explosionDamage = 1;
	public AudioClip sound;
	
	private AudioSource audioSource;
	GameObject explosionParent;
	
	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
		explosionParent = GameObject.Find("Explosions");
		if (!explosionParent) {
			explosionParent = new GameObject ("Explosions");
		}
		transform.parent = explosionParent.transform;
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		Health health = collider.GetComponent<Health>();
		if (health && collider.GetComponent<Defender>()) {
			health.DealDamage(explosionDamage);
		}
	}
	
	void PlaySound() {
		audioSource.clip = sound;
		audioSource.Play();
	}
}

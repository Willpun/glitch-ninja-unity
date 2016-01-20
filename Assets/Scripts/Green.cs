using UnityEngine;
using System.Collections;

public class Green : MonoBehaviour {
	
	public AudioClip getHitSound;
	
	private Animator anim;
	private Attacker attacker;
	private AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
		audioSource = GetComponent<AudioSource>();
		if(!audioSource) {
			audioSource = gameObject.AddComponent<AudioSource>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		
		GameObject obj = collider.gameObject;
		
		// Do nothing if not colliding with Defender
		if (!obj.GetComponent<Defender>()) {
			return;
		} else {
			anim.SetTrigger ("TriggerAttack");
			attacker.Attack (obj);
		}		
	}
	
	void PlayGetHitSound() {
		audioSource.clip = getHitSound;
		audioSource.Play ();
	}
}
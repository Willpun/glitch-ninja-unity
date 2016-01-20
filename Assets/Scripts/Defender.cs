using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public AudioClip getHitSound;
	public bool isMoving;

	private AudioSource audioSource;	
	private Animator anim;

	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		if(!audioSource) {
			audioSource = gameObject.AddComponent<AudioSource>();
		}
		
		anim = GetComponent<Animator>();
		
		isMoving = false;
	}
	
	public void SetAttack(bool b){
		anim.SetBool ("IsAttacking", b);
	}
	
	public void SetRunning(bool b) {
		anim.SetBool ("IsRunning", b);
	}
	
	void PlayGetHitSound() {
		audioSource.clip = getHitSound;
		audioSource.Play ();
	}

}

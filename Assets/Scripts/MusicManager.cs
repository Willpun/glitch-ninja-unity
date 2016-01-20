using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] musicArray;
	
	private AudioSource audioSource;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip music = musicArray[level];
		if (music){
			audioSource.clip = music;
			if(level < musicArray.Length - 2){
				audioSource.loop = true;
			} else {
				audioSource.loop = false;
			}
			audioSource.Play ();
		} else {
			audioSource.Stop ();
		}
	}
	
	public void ChangeVolume (float value) {
		audioSource.volume = value;
	}
}

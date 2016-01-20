using UnityEngine;
using System.Collections;

public class setStartMusic : MonoBehaviour {

	private MusicManager musicManager;
	// Use this for initialization
	void Start () {
		musicManager = FindObjectOfType<MusicManager>();
		musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

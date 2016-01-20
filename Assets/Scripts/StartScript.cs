using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Unpause() {
		Time.timeScale = 1;
		GameObject startButton = GameObject.Find("StartButton");
		if (startButton) {
			Destroy(startButton);
		}
	}
}

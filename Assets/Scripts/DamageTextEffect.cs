using UnityEngine;
using System.Collections;

public class DamageTextEffect : MonoBehaviour {

	[Range (0, 1)]
	public float risingSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * risingSpeed * Time.deltaTime);
	}
}

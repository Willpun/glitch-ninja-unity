using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnergyDisplay : MonoBehaviour {

	private int currentEnergy = 100;
	public enum Status {SUCCESS, FAILURE};
	// Use this for initialization
	void Start () {
		DisplayEnergy();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void IncreaseEnergy(int amount) {
		currentEnergy += amount;
		DisplayEnergy();
	}
	
	public Status DecreaseEnergy(int amount) {
		if(currentEnergy >= amount) {
			currentEnergy -= amount;
			DisplayEnergy();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	public void DisplayEnergy() {
		GetComponent<Text>().text = currentEnergy.ToString();
	}
}

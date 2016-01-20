using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LimitBreak : MonoBehaviour {

	public enum Status {LEVEL0, LEVEL1, LEVEL2, MAX};
	public float amountOfDamageNeededForMax = 450;
	public AudioClip[] soundEffect = new AudioClip[3];

	private Text myText;
	private Status barLevel;
	private float damageCounter = 0;
	
	private Defender myDefender;
	private Health myHealth;
	private HealthBar playerHealthBar;
	private AudioSource myAudioSource;

	// Use this for initialization
	void Start () {
		myDefender = FindObjectOfType<Defender>();
		myHealth = myDefender.GetComponent<Health>();
		myAudioSource = myDefender.GetComponent<AudioSource>();
		if(!myAudioSource) {
			myAudioSource = myDefender.gameObject.AddComponent<AudioSource>();
		}
		
		
		myText = transform.parent.GetComponentInChildren<Text>();
		myText.text = " ";
		barLevel = Status.LEVEL0;
		damageCounter = 0;
		
		playerHealthBar = FindObjectOfType<HealthBar>();
	}
	
	public void HandleLimitBreak(float damage){
		if (barLevel != Status.MAX) {
			damageCounter += damage;
			ChargingTheBar();
		}
	}
	
	// TODO 
	public void UseLimitBreak () {
	
		float myMaxHealth = myHealth.GetMaxHealth();
		
		switch (barLevel) {
			case Status.LEVEL0:
				Debug.Log ("Not Enough to execute a limitbreak action");
				break;
				
			case Status.LEVEL1:
				// TODO
				float one_third = myMaxHealth / 3;
				if (myHealth.health < myMaxHealth) {
					float h = myHealth.health + one_third;
					if (h > myMaxHealth) { myHealth.health = myMaxHealth; }
					else { myHealth.health = h; }
					Reset ();
				
					myAudioSource.clip = soundEffect[0];
					myAudioSource.Play ();
				}
				break;
				
			case Status.LEVEL2:
				// TODO
				float two_third = myMaxHealth * 2 / 3;
				if (myHealth.health < myMaxHealth) {
					float h = myHealth.health + two_third;
					if (h > myMaxHealth) { myHealth.health = myMaxHealth; }
					else { myHealth.health = h; }
					Reset ();
					
					myAudioSource.clip = soundEffect[1];
					myAudioSource.Play ();
				}
				break;
			case Status.MAX:
				// TODO
				if (myHealth.health < myMaxHealth) {
					myHealth.health = myMaxHealth;
					Reset();
					
					myAudioSource.clip = soundEffect[2];
					myAudioSource.Play ();
				}
				break;
		}

		playerHealthBar.UpdateDisplay(myHealth.health);
		ChargingTheBar();
	}

	void Reset ()
	{
		barLevel = Status.LEVEL0;
		float one_third = amountOfDamageNeededForMax / 3;
		if (damageCounter >= amountOfDamageNeededForMax) {
			damageCounter = 0;
		} else if (damageCounter >= (one_third * 2)){
			damageCounter -= (one_third * 2);
		} else if (damageCounter >= one_third) {
			damageCounter -= one_third;
		}
	}
	
	void ChargingTheBar() {
		float fillAmount = damageCounter / amountOfDamageNeededForMax;
		Image barImage = GetComponent<Image>();
		Color lerpedColor = Color.Lerp (Color.magenta, Color.blue, fillAmount);
		
		barImage.fillAmount = fillAmount;
		barImage.color = lerpedColor;
		
		if (fillAmount >= 1) {
			barLevel = Status.MAX;
			myText.text = "Press to Heal!";
			
			barImage.color = Color.red;
			
		} else if (fillAmount >= 0.6666) {
			barLevel = Status.LEVEL2;
			myText.text = "Press to Heal!";
		} else if (fillAmount >= 0.3333) {
			barLevel = Status.LEVEL1;
			myText.text = "Press to Heal!";
		} else {
			barLevel = Status.LEVEL0;
			myText.text = " ";
		}
	}
}

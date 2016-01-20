using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100f;
	public int scoreValue = 0;
	
	public GameObject damageTextPrefab;
	public GameObject explosionPrefab;

	private Animator anim;
	private LimitBreak limitBreak;
	private HealthBar playerHealthBar;
	private LevelManager levelManager;
	private float maxHealth;
	
	private ScoreKeeper scoreKeeper;
	
	// Use this for initialization
	void Start () {
		maxHealth = health;
		
		levelManager = FindObjectOfType<LevelManager>();
		
		anim = GetComponent<Animator>();
		
		limitBreak = FindObjectOfType<LimitBreak>();
		
		if (GetComponent<Defender>()) {
			playerHealthBar = FindObjectOfType<HealthBar>();
			playerHealthBar.SetMaxHealth (maxHealth);
			playerHealthBar.UpdateDisplay (health);
		}
		
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
		
	}
	
	public float GetMaxHealth () {
		return maxHealth;
	}
	
	public void DealDamage (float damage){
		health -= damage;
		
		limitBreak.HandleLimitBreak(damage);
		
		anim.SetTrigger ("TriggerGetHit");
		DisplayDamage(damage);
		
		if (GetComponent<Defender>()) {
			playerHealthBar.UpdateDisplay (health);
		}
		
		if (health <= 0) {
			// Optionally trigger animation
			DestroyObj(); // remove this line and you put it in the Death Animation in the future
		}
	}
	
	public void DestroyObj(){
		Destroy (gameObject, 0.25f);
		
		if (GetComponent<Attacker>()) {
			scoreKeeper.Score(scoreValue);
			Invoke ("Explosion", 0.24f);
		} else if (GetComponent<Defender>()) {
			levelManager.LoadLevel ("03b Lose");
		}
	}

	void Explosion ()
	{
		GameObject explosion = Instantiate (explosionPrefab, transform.position, Quaternion.identity) as GameObject;
		explosion.GetComponent<Animator> ().SetTrigger ("ExplosionTrigger");
		Destroy (explosion, 1.0f);
	}
	
	public void DisplayDamage(float damage){
		Vector3 pos = damageTextPrefab.transform.position + transform.position;
		GameObject newText = Instantiate (damageTextPrefab, pos, Quaternion.identity) as GameObject;
		newText.transform.parent = transform;
		
		newText.GetComponent<TextMesh>().text = damage.ToString();
		Destroy (newText, 0.25f);
		
	}

}
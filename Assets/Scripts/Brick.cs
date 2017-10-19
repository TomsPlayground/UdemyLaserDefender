using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public float crackVolume = 0.3f;
	public AudioClip explosion;	
	public float explosionVolume = 0.7f;	
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int maxHits;
	private LevelManager winning;
	private int timesHit;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		winning = GameObject.FindObjectOfType<LevelManager>();
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
	}

	
	void OnCollisionEnter2D (Collision2D brickCollider){
		if (isBreakable) {
			HandleHits ();
		}
	}
			
	void HandleHits () {
		timesHit++;
		maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			breakableCount--;
			Destroy (gameObject);
			AudioSource.PlayClipAtPoint (explosion, transform.position, explosionVolume);
			winning.BrickDestroyed();
		} else {
			AudioSource.PlayClipAtPoint (crack, transform.position, crackVolume);
			LoadSprites();
		}
	}
	
	void Puff () {
		GameObject puff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		puff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Brick sprite missing");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

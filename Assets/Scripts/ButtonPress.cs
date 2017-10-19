using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonPress : MonoBehaviour {

	public AudioClip crack;
	public float crackVolume = 0.3f;
	public Button yourButton;

	// Use this for initialization
	void Start () {
	
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
			
	}
	
	void TaskOnClick(){
		AudioSource.PlayClipAtPoint (crack, transform.position, crackVolume);
	}
}

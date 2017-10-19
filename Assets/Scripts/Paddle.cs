using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {	
	
	public bool autoPlay = false;
	public float leftPaddleMax = 0.5f;
	public float rightPaddleMax = 15.5f;
	
	private Ball ball;
	
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	void Update(){
		if (autoPlay == false){
		MoveWithMouse ();
		} else {
			AutoPlay();
		}
	}
	
	void AutoPlay() {
		Vector3 ballPos = ball.transform.position;
		Vector3 paddlePos = new Vector3 (Mathf.Clamp(ballPos.x, leftPaddleMax, rightPaddleMax), transform.position.y, 0);
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse () {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3 (Mathf.Clamp(mousePosInBlocks, leftPaddleMax, rightPaddleMax), transform.position.y, 0);
		this.transform.position = paddlePos;
	}
	
}

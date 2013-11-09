using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour {
	GameController aGameController; 
	private string stringSeconds;
	
	// Use this for initialization
	void Start () {
	aGameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();			
	}
	
	void OnGUI(){
		GUI.Label (new Rect (0, 0, 170, 30), "Score: " + aGameController.playerScore.ToString (), "box");
		
		//color = aGameController.nextColor;
		//GUI.Label (new Rect (0, Screen.height - 200, 0, 200, 200), GUIContent("Next Color", color), "box");
		
		FormatTimer ();
		if (aGameController.secondsRemaining <= 10) {
			GUI.Label (new Rect (Screen.width - 170, 0, 170, 30), "Time Remaining: " + stringSeconds, "box");//and make the label text red
		}
		else { 
			GUI.Label (new Rect (Screen.width - 170, 0, 170, 30), "Time Remaining: " + stringSeconds, "box");
		}
}
	
	void FormatTimer () {
		if (aGameController.secondsRemaining < 10) {
			stringSeconds = "0" + aGameController.secondsRemaining.ToString (); 
		} 
		else {
			stringSeconds = aGameController.secondsRemaining.ToString ();
		}
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}

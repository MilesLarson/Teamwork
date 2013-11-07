using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private Color[] allColors = new Color [5];
	public GameObject randomWhiteCube;
	public Color nextColor = Color.blue;
	public bool keyPress = false;

	// Use this for initialization
	void Start () {
		Instantiate(randomWhiteCube);
	}
	
	// Update is called once per frame
	void Update () {
		if(turn){
			keyPress = false;
			DetermineNextCubeColor();
			ProcessKeyboardInput();
			DestroyCube();
		}
		CheckPlayerScore();
		EndGameTimer();
		
	}
	
	//Does this when buttons 1-5 are pressed
	void ProcessKeyboardInput () {
		if(Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown (KeyCode.Alpha1)){
			//send cube of 'color specified' into row corresponding with keypress
			//specify all cubes with Y value 0, and change a random.range X value of an available cube
			//Check cubes in Y of O for any white cubes. If no white end game, if there are white pick a random X of those white cubes and change color
			//If X value isn't white and next isn't white etc. end the game.
			//else if random.range check an X for Whiteness, and if it is white change the color.
			randomWhiteCube.renderer.material.color = nextColor;
			keyPress = true;
		}
		if(Input.GetKeyDown (KeyCode.Keypad2) || Input.GetKeyDown (KeyCode.Alpha2)){
			randomWhiteCube.renderer.material.color = nextColor;
			keyPress = true;
		}
		if(Input.GetKeyDown (KeyCode.Keypad3) || Input.GetKeyDown (KeyCode.Alpha3)){
			randomWhiteCube.renderer.material.color = nextColor;
			keyPress = true;
		}
		if(Input.GetKeyDown (KeyCode.Keypad4) || Input.GetKeyDown (KeyCode.Alpha4)){
			randomWhiteCube.renderer.material.color = nextColor;
			keyPress = true;
		}
		if(Input.GetKeyDown (KeyCode.Keypad5) || Input.GetKeyDown (KeyCode.Alpha5)){
			randomWhiteCube.renderer.material.color = nextColor;
			keyPress = true;
		}
		
		
	}
	
	//Destroys a cube
	void DestroyCube () {
		if(keyPress != false){
			Destroy(randomWhiteCube);
			justDestroyedCube = true;
		}
		//plusForm would be a variable returned by our scoring function
		if(plusForm == true){
			allPlusCubes.renderer.material.color = Color.gray;
			Destroy(allCubesInPlusForm.Collider);
		}
	}
	
	void DetermineNextCubeColor () {
		colorNumber = Random.Range(0,4);
		nextColor.renderer.material.color = allColors[colorNumber];
		allColors[0] = Color.blue;
		allColors[1] = Color.black;
		allColors[2] = Color.green;
		allColors[3] = Color.red;
		allColors[4] = Color.yellow;
		
	}
	
	//we need to color an active cube at a random X value, in the specified Y coordinate.
}

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private Color[] allColors = new Color [5];
	public GameObject randomWhiteCube;
	public Color nextColor;
	public bool keyPress = false;
	//set up some floats to keep track of seconds elapsed
	public float timer;
	public float seconds, secondsRemaining;
	public GameObject cube;
	//these variables determine the dimensions of the grid of cubes that will be created
	private int gridWidth = 8, gridHeight = 5;
	//sets up a 2 dimensional array of GameObjects that will be used to keep track of the cubes
	private GameObject[,] allCubes;
	
	
	
	// Use this for initialization
	void Start () {
		Instantiate(randomWhiteCube); //what does the randomwhitecube do? -Aaron
		
		allColors[0] = Color.blue;
		allColors[1] = Color.black;
		allColors[2] = Color.green;
		allColors[3] = Color.red;
		allColors[4] = Color.yellow;
		
		//sets the array to contain an equal amount of GameObject elements as there are cubes generated.
		allCubes = new GameObject [gridWidth, gridHeight];
		//the following for loops in conjunction with the Instantiate function below generate a grid of cubes. The first part of the for loops just creates a variable, then the conditions are set so that the for loops will not loop more than gridWidth and gridHeight times respectively. These conditions must be met if the for loop is to continue running.  One cube is generated per loop of each for function so the grid is gridHeight x gridWidth. Then a command to increase x and y by one is given as what to do at the conclusion of the method. The loops then start over with incrementally higher x and y values.
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {
				//the following line sets the contents of the array. It states that for each value of x and y assign the gameobject returned by the instantiate function to that value of the array. This creates an array that contains all of the cubes that have been instantiated into the scene.
				allCubes [x, y] = (GameObject)Instantiate (cube, new Vector3 (x * 2, y * 2, 0), Quaternion.identity);
				//sets the cube just instantiated to the x and y values in the CubeBehavior script. The x and y values for each cube are now stored for later reference.
				allCubes [x, y].GetComponent<CubeBehavior> ().x = x;
				allCubes [x, y].GetComponent<CubeBehavior> ().y = y;
			}
		}
	
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
		RunGameTimer();
		
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
			//make color disappear from next cube area of the GUI. nextCube.renderer.enabled = false. then Ill have to re-enable it when a new turn starts, this could be put into the update loop. 
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
		nextColor = allColors[colorNumber];
	}

	//this method is run when a cube is clicked. The location of the cube that was clicked and its color are passed into this function. 
	public void ProcessClickedCube (GameObject clickedCube, int x, int y, Color clickedColor) {	
		//if you click an inactive colored cube, make it active. (If the x and y values of the cube clicked are equal to the x and y values assigned to the colored cube and that colored cube isnt active then make the colored cube active and spotlight that cube that has been clicked).
		if (x == coloredCube.x && y == coloredCube.y && this.coloredCube.active == false) {
			//put a spotlight on or highlight the cube in some other way.  
		}
		//if (clickedCube.renderer.material.color !== Color.white && //this cube isnt active )
		//	coloredCube.x = x;
		//	coloredCube.y = y;
		//	coloredCube.active = true;
			//highlight the cube in this location
			
			
			
			//old coloredCube.active = false
			//take away spotlight from old coloredCube.active 
			//this coloredCube.active = true; (how do I specify which coloredCube is being referenced. this is also a problem in the if statement, cuz it has to be this specific colored cube thats inactive, not just any of the colored cubes.  
			
		
		//otherwise, if you click an active colored cube, make it inactive (If the x and y values of the cube clicked are equal to the x and y values assigned to the colored cube and there is an active colored cube, make the airplane no longer active and turn the cube that has been clicked red).
		else if (x == coloredCube.x && y == coloredCube.y && this.coloredCube.active) { //else if (coloredCube.renderer.material.color !== Color.white && //this cube is active) {
			//make the spotlight go away
			//this.coloredCube.active = false;
		} 
		//otherwise, if you click an available cube adjacent to an active colored cube, set the location of the colored cube to the cube clicked and change the color of the cube clicked to that of the colored cube.
		else if (this.coloredCube.active && ((x == coloredCube.x + 1 || x == coloredCube.x - 1) || (y == coloredCube.y + 1 || y == coloredCube.y - 1 ))) {
			allCubes [this.coloredCube.x , this.coloredCube.y].renderer.material.color = Color.white; //is this gonna work? cuz we need to specify which coloredCube were turning white. We need a way to keep track of multiple colored cubes. Maybe using the this command will work but Im not sure. 
			this.coloredCube.x = x;
			this.coloredCube.y = y;
			allCubes [coloredCube.x , coloredCube.y].renderer.material.color = clickedColor;
		}
	}
	
	
	
	//this method effectively creates a timer that counts up each second and loads the next level if the timer reaches 60. 
	void RunGameTimer () {
		//the amount of time (in seconds) that has elapsed since the last frame is added to the variable timer. This causes timer variable to increase based on how many seconds have elapsed.
		timer += Time.deltaTime;
		//since timer is measuring seconds, every time it reaches one, the seconds variable is increased incrementally. The seconds variable is then set to 0 so that it can count back up to 1 again and add keep track of the next second
		if (timer >= 1f) {
			seconds++;
			timer = 0f;
		}
		//if 60 seconds elapse, proceed to the game summary screen
		if (seconds >= 60) {
			Application.LoadLevel("GameSummary");
		}
		secondsRemaining = 60 - seconds; 
	}
	
	//we need to color an active cube at a random X value, in the specified Y coordinate.
}

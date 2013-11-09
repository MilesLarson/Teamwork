using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {
	public int x, y;
	GameController aGameController;
	// Use this for initialization
	void Start () {
	//The following line sets the variable aGameController to the script GameControllerFinal. It does this by finding the GameObject upon which GameControllerFinal is placed, then getting the specific component of that game object that is the script GameControllerFinal.
		aGameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();			
	}
	
	//this method instructs that when a game object is clicked, the method in the GameController script called ProcessClickedCube should be run using the gameobject that was clicked and its X and Y coordinates as the argument for the function.
	void OnMouseDown (){
		aGameController.ProcessClickedCube (this.gameObject, x, y, this.gameObject.renderer.material.color);
		//aGameController.ProcessClickedCube(this.gameObject, x, y);	
	}
}

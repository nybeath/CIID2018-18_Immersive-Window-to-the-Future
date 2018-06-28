using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using Kino;

public class nearfuturetest : MonoBehaviour {
	Enemy lastCup;
	orange lastOrange; 

	public string lastfiducialtracked; 
	public string currentfiducialtracked; 

   	void Start () {
	   	lastCup = null;
		lastOrange = null; 
		lastfiducialtracked = "null"; 
   	}

  	public void whichFiducial(string fiducial) {
	   if (fiducial == "cup") {
		   currentfiducialtracked = "cup";
	   } else if (fiducial == "orange") {
		   currentfiducialtracked = "orange"; 
	   }

	   if (currentfiducialtracked == lastfiducialtracked) {
		   // Do nothing
	   } else {
			lastCup = null;
			lastOrange = null; 
	   }
	//    if (fiducial == "postit") {
	// 	   currentfiducialtracked = "postit"; 
	//    }
   	}
   
	void Update () {
	   if (currentfiducialtracked == "cup") {
		   FindClosestCup(); 
	   }
	   if (currentfiducialtracked == "orange") {
		   FindClosestOrange(); 
	   }
	//    if (currentfiducialtracked == "postit") {
	// 	   FindClosestPostIt(); 
	//    }
     } 

	//CUP FUTURES
    void FindClosestCup()
    {
	Enemy nCup;
    Enemy eCup;
    Enemy sCup;
    Enemy wCup;

    GameObject northCup = GameObject.Find("cupFiducial/cupNorth");
    GameObject eastCup = GameObject.Find("cupFiducial/cupEast");
    GameObject southCup = GameObject.Find("cupFiducial/cupSouth");   
    GameObject westCup = GameObject.Find("cupFiducial/cupWest"); 

    nCup = northCup.GetComponent<Enemy>();
    eCup = eastCup.GetComponent<Enemy>();
    sCup = southCup.GetComponent<Enemy>();
    wCup = westCup.GetComponent<Enemy>();

    // calculate closest distance		
    float distanceToClosestEnemy = Mathf.Infinity;
 		
    Enemy closestEnemy = null;  
 		
    Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

 		 foreach (Enemy currentEnemy in allEnemies) {
 			 float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			 if (distanceToEnemy < distanceToClosestEnemy) {
 				 distanceToClosestEnemy = distanceToEnemy;
                                closestEnemy = currentEnemy;
			}
		}

	Enemy currentCup = closestEnemy;

	if (currentCup == lastCup) {
		// GameObject mainCamera = GameObject.Find("Main Camera");
		// AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
		// glitchy.setGlitchboolean(false); 
	} else {
		print("registered a change to: " + currentCup + " from: " + lastCup); 
		if (currentCup == sCup) {

			GameObject mainCamera = GameObject.Find("Main Camera");
			AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
			glitchy.setGlitchboolean(true); 

			for (int i = 1; i < SceneManager.sceneCount; i++) {
				Scene currentscene = SceneManager.GetSceneAt(i);
				Debug.Log("Current SCENE is '" + currentscene.name + "'.");
				SceneManager.UnloadSceneAsync(currentscene.name);
			}
			SceneManager.LoadScene("Cup2", LoadSceneMode.Additive);
			print("south"); 
		}
		if (currentCup == nCup) {

			GameObject mainCamera = GameObject.Find("Main Camera");
			AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
			glitchy.setGlitchboolean(true); 

			for (int i = 1; i < SceneManager.sceneCount; i++) {
				Scene currentscene = SceneManager.GetSceneAt(i);
				Debug.Log("Current SCENE is '" + currentscene.name + "'.");
				SceneManager.UnloadSceneAsync(currentscene.name);
			}

			int cointoss = Random.Range(0,2); 
			if (cointoss == 0) {
				SceneManager.LoadScene("Cup4", LoadSceneMode.Additive);
			} else if (cointoss == 1) {
				SceneManager.LoadScene("Cup5", LoadSceneMode.Additive);
			}
			print("north"); 
		}
		if (currentCup == eCup) {

			GameObject mainCamera = GameObject.Find("Main Camera");
			AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
			glitchy.setGlitchboolean(true); 

			for (int i = 1; i < SceneManager.sceneCount; i++) {
				Scene currentscene = SceneManager.GetSceneAt(i);
				Debug.Log("Current SCENE is '" + currentscene.name + "'.");
				SceneManager.UnloadSceneAsync(currentscene.name);
			}
			SceneManager.LoadScene("Cup1", LoadSceneMode.Additive);
			print("east"); 
		}
		if (currentCup == wCup) {

			GameObject mainCamera = GameObject.Find("Main Camera");
			AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
			glitchy.setGlitchboolean(true); 

			for (int i = 1; i < SceneManager.sceneCount; i++) {
				Scene currentscene = SceneManager.GetSceneAt(i);
				Debug.Log("Current SCENE is '" + currentscene.name + "'.");
				SceneManager.UnloadSceneAsync(currentscene.name);
			}
			SceneManager.LoadScene("Cup3", LoadSceneMode.Additive);
			print("west"); 
		} 
		lastCup = currentCup; 
	} 
    }

	//CHANNEL ORANGE 
	void FindClosestOrange()
    {
	orange northside;
    orange eastside;
    orange southside;
    orange westside;
    GameObject northWindow = GameObject.Find("orangeFiducial/orangeNorth");
    GameObject eastWindow = GameObject.Find("orangeFiducial/orangeEast");
    GameObject southWindow = GameObject.Find("orangeFiducial/orangeSouth");   
    GameObject westWindow = GameObject.Find("orangeFiducial/orangeWest"); 

    northside = northWindow.GetComponent<orange>();
    eastside = eastWindow.GetComponent<orange>();
    southside = southWindow.GetComponent<orange>();
    westside = westWindow.GetComponent<orange>();

    // calculate closest distance		
    float distanceToClosestOrange = Mathf.Infinity;
 		
    orange closestEnemy = null;  
 		
    orange[] allEnemies = GameObject.FindObjectsOfType<orange>();

 		foreach (orange currentEnemy in allEnemies) {
 			 float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			 if (distanceToEnemy < distanceToClosestOrange) {
 				 distanceToClosestOrange = distanceToEnemy;
                                closestEnemy = currentEnemy;
			}
		}

	orange currentOrange = closestEnemy;

	if (currentOrange == lastOrange) {
		// GameObject mainCamera = GameObject.Find("Main Camera");
		// AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
		// glitchy.setGlitchboolean(false); 
	} else {
		if (currentOrange == southside) {
			GameObject mainCamera = GameObject.Find("Main Camera");
			AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
			glitchy.setGlitchboolean(true); 


			for (int i = 1; i < SceneManager.sceneCount; i++) {
				Scene currentscene = SceneManager.GetSceneAt(i);
				Debug.Log("Current SCENE is '" + currentscene.name + "'.");
				SceneManager.UnloadSceneAsync(currentscene.name);
			}
			SceneManager.LoadScene("juicing", LoadSceneMode.Additive);
			print("HEY THIS IS SHOULD BE A GROWING TREE"); 
		}
		if (currentOrange == northside) {

			GameObject mainCamera = GameObject.Find("Main Camera");
			AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
			glitchy.setGlitchboolean(true); 

			for (int i = 1; i < SceneManager.sceneCount; i++) {
				Scene currentscene = SceneManager.GetSceneAt(i);
				Debug.Log("Current SCENE is '" + currentscene.name + "'.");
				SceneManager.UnloadSceneAsync(currentscene.name);
			}
			SceneManager.LoadScene("GrowingTree", LoadSceneMode.Additive);

			print("ORANGE north"); 
		}
		if (currentOrange == eastside) {

			GameObject mainCamera = GameObject.Find("Main Camera");
			AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
			glitchy.setGlitchboolean(true); 

			for (int i = 1; i < SceneManager.sceneCount; i++) {
				Scene currentscene = SceneManager.GetSceneAt(i);
				Debug.Log("Current SCENE is '" + currentscene.name + "'.");
				SceneManager.UnloadSceneAsync(currentscene.name);
			}
			SceneManager.LoadScene("OrangeCutting", LoadSceneMode.Additive);
			print("ORANGE east"); 
		}
		if (currentOrange == westside) {

			GameObject mainCamera = GameObject.Find("Main Camera");
			AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
			glitchy.setGlitchboolean(true); 

			for (int i = 1; i < SceneManager.sceneCount; i++) {
				Scene currentscene = SceneManager.GetSceneAt(i);
				Debug.Log("Current SCENE is '" + currentscene.name + "'.");
				SceneManager.UnloadSceneAsync(currentscene.name);
			}
			SceneManager.LoadScene("RottingOrange", LoadSceneMode.Additive);
			print("ORANGE west"); 
		} 
		lastOrange = currentOrange; 
	} 
    }

	// // IDEATION NATION

	// void FindClosestPostIt()
    // {
    // GameObject northWindow = GameObject.Find("postItsFiducial/FiducialObjects/North");
    // GameObject eastWindow = GameObject.Find("postItsFiducial/FiducialObjects/East");
    // GameObject southWindow = GameObject.Find("postItsFiducial/FiducialObjects/South");   
    // GameObject westWindow = GameObject.Find("postItsFiducial/FiducialObjects/West"); 

    // northside = northWindow.GetComponent<Enemy>();
    // eastside = eastWindow.GetComponent<Enemy>();
    // southside = southWindow.GetComponent<Enemy>();
    // westside = westWindow.GetComponent<Enemy>();

    // // calculate closest distance		
    // float distanceToClosestEnemy = Mathf.Infinity;
 	
    // Enemy closestEnemy = null;  
 		
    // Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

 	// 	foreach (Enemy currentEnemy in allEnemies) {
 	// 		 float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
	// 		 if (distanceToEnemy < distanceToClosestEnemy) {
 	// 			 distanceToClosestEnemy = distanceToEnemy;
    //                             closestEnemy = currentEnemy;
	// 		}
	// 	}

	// Enemy currentWindow = closestEnemy;

	// if (currentWindow == lastWindow) {
	// 	// GameObject mainCamera = GameObject.Find("Main Camera");
	// 	// AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
	// 	// glitchy.setGlitchboolean(false); 
	// } else {
	// 	// print("THE CURRENT WINDOW IS: " + currentWindow + " AND LAST WINDOW WAS: " + lastWindow);
	// 	// print(southside);
	// 	if (currentWindow == southside) {
	// 		Debug.Log("THIS IS A SOUTHSIDE POSTIT");
	// 		// GameObject mainCamera = GameObject.Find("Main Camera");
	// 		// AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
	// 		// glitchy.setGlitchboolean(true); 

	// 		// for (int i = 1; i < SceneManager.sceneCount; i++) {
	// 		// 	Scene currentscene = SceneManager.GetSceneAt(i);
	// 		// 	Debug.Log("Current SCENE is '" + currentscene.name + "'.");
	// 		// 	SceneManager.UnloadSceneAsync(currentscene.name);
	// 		// }
	// 		// SceneManager.LoadScene("ORANGE1", LoadSceneMode.Additive);
	// 	}
	// 	if (currentWindow == northside) {
	// 		Debug.Log("THIS IS A NORTHSIDE POSTIT");
	// 		// GameObject mainCamera = GameObject.Find("Main Camera");
	// 		// AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
	// 		// glitchy.setGlitchboolean(true); 

	// 		// for (int i = 1; i < SceneManager.sceneCount; i++) {
	// 		// 	Scene currentscene = SceneManager.GetSceneAt(i);
	// 		// 	Debug.Log("Current SCENE is '" + currentscene.name + "'.");
	// 		// 	SceneManager.UnloadSceneAsync(currentscene.name);
	// 		// }
	// 		// SceneManager.LoadScene("Cup4", LoadSceneMode.Additive);
	// 	}
	// 	if (currentWindow == eastside) {
	// 		Debug.Log("THIS IS A EASTSIDE POSTIT");
	// 		// GameObject mainCamera = GameObject.Find("Main Camera");
	// 		// AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
	// 		// glitchy.setGlitchboolean(true); 

	// 		// for (int i = 1; i < SceneManager.sceneCount; i++) {
	// 		// 	Scene currentscene = SceneManager.GetSceneAt(i);
	// 		// 	Debug.Log("Current SCENE is '" + currentscene.name + "'.");
	// 		// 	SceneManager.UnloadSceneAsync(currentscene.name);
	// 		// }
	// 		// SceneManager.LoadScene("Cup1", LoadSceneMode.Additive);
	// 	}
	// 	if (currentWindow == westside) {
	// 		Debug.Log("THIS IS A WESTSIDE POSTIT");
	// 		// GameObject mainCamera = GameObject.Find("Main Camera");
	// 		// AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
	// 		// glitchy.setGlitchboolean(true); 

	// 		// for (int i = 1; i < SceneManager.sceneCount; i++) {
	// 		// 	Scene currentscene = SceneManager.GetSceneAt(i);
	// 		// 	Debug.Log("Current SCENE is '" + currentscene.name + "'.");
	// 		// 	SceneManager.UnloadSceneAsync(currentscene.name);
	// 		// }
	// 		// SceneManager.LoadScene("Cup3", LoadSceneMode.Additive);
	// 	} 
	// 	lastWindow = currentWindow; 
	// } 
    // }
}
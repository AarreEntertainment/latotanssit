using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour {
    bool activated = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && !activated){
            activated = true;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("game");
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<UnityEngine.UI.Text>().text = "Joo okei, sun aikas oli: \n"+ PlayerPrefs.GetString("time");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown && Time.timeSinceLevelLoad>5)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
        }
	}
}

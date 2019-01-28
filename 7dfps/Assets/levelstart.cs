using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelstart : MonoBehaviour {

    bool started = false;
    public bool dead = false;
    float deathTime = 0;
    // Use this for initialization
    void Start() {

    }

    public void win() {
        PlayerPrefs.SetString("time", System.TimeSpan.FromSeconds((int)Time.timeSinceLevelLoad).ToString());
        UnityEngine.SceneManagement.SceneManager.LoadScene("win");
    }
	
	// Update is called once per frame
	void Update () {
        if (!started) {
            GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 1 - (Time.time/4));
            if (GetComponent<UnityEngine.UI.Image>().color.a <= 0)
            {
                started = true;
            }
        }
        if (dead)
        {
            deathTime += Time.deltaTime / 5;
            GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0+deathTime);
            if (GetComponent<UnityEngine.UI.Image>().color.a >0.8) UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
        }
	}
}

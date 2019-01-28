using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCounter : MonoBehaviour {
    public float counter;
    public levelstart levelController;
	// Use this for initialization
	void Start () {
        counter = transform.childCount;
	}
	public void reduce()
    {
        counter--;
        if(counter<=0)
        {
            levelController.win();
        }

    }
	// Update is called once per frame
	void Update () {
		
	}
}

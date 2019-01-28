using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null)
        {
            if (Camera.main.gameObject != null)
                transform.rotation = Camera.main.transform.parent.rotation;
        }

    }
}

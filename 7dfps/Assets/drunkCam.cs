using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drunkCam : MonoBehaviour {
    public float kanni;
    public Camera cam;
    UnityEngine.PostProcessing.PostProcessingProfile prof;
    float origVal = 60;
    float origlens = 5;
	// Use this for initialization
	void Start () {
        prof = GetComponent<UnityEngine.PostProcessing.PostProcessingBehaviour>().profile;
        cam = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float focdis;
        if (kanni > 0)
        {
            if (kanni > 20) focdis = 5;
            else focdis = kanni/4;

            cam.fieldOfView = (origVal - kanni / 2) - kanni * Mathf.Sin(Time.time);
            UnityEngine.PostProcessing.DepthOfFieldModel.Settings settig = prof.depthOfField.settings;
            settig.focusDistance = (origlens - focdis / 2) - focdis * Mathf.Sin(Time.time);
            prof.depthOfField.settings = settig;
        }
        else
        {
            cam.fieldOfView = origVal;
            UnityEngine.PostProcessing.DepthOfFieldModel.Settings settig = prof.depthOfField.settings;
            settig.focusDistance =origlens;
            prof.depthOfField.settings = settig;

        }

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioGroupRandomizer : MonoBehaviour {
    public bool music;
    public AudioSource currentAudio;
	// Use this for initialization
	void Start () {
        if (music)
        {
            playAudio();
        }
	}

    public void playAudio()
    {
        Transform audio = transform.GetChild(Random.Range(0, transform.childCount - 1));
        currentAudio = audio.GetComponent<AudioSource>();
        currentAudio.Play();
    }

    // Update is called once per frame
    void Update () {
        if (music)
        {
            if (!currentAudio.isPlaying)
            {
                playAudio();
            }
        }
	}
}

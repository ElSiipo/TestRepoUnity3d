using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTriggerSound : MonoBehaviour {

    public AudioClip goalClip;
    public float volume = 0.66f;
    AudioSource audio;
    
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(!audio.isPlaying)
        {
            Debug.Log("The trigger is fired");
            audio.PlayOneShot(goalClip, volume);
        }
    }
}

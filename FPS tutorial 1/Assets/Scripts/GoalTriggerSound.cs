using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        if(!audio.isPlaying && ValidateAllTargetsHit())
        {
            Debug.Log("The trigger is fired");
            audio.PlayOneShot(goalClip, volume);
        }
    }

    private bool ValidateAllTargetsHit()
    {
        var targets = GameObject.FindGameObjectsWithTag("Target").Where(t => t.name.Equals("Target", StringComparison.InvariantCultureIgnoreCase));
        var allObjectsHit = false;

        foreach (var target in targets)
        {
            allObjectsHit = target.GetComponent<MeshRenderer>().material.color == Color.green;
        }

        return allObjectsHit;

        //return targets.All(p => p.name == "Target" && p.GetComponent<Renderer>().material.color == Color.green);
        //return targets.All(p => p.name == "Target" && p.GetComponent<MeshRenderer>().material.color == Color.green);
    }
}

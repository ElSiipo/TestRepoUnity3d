using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBulletHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//var target = GetComponent<GameObject>()
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
            gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
}

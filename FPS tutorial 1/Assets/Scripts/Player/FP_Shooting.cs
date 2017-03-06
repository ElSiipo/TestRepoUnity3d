using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Shooting : MonoBehaviour {

    public GameObject bullet_Prefab;
    private Camera cam;
    float bulletImpulse = 100f;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        //GameObject bullet = (GameObject)Instantiate(bullet_Prefab, cam.transform.position, cam.transform.rotation);
        //GetComponent<Rigidbody>().velocity = cam.transform.forward * bulletImpulse;

        var bullet = Instantiate(bullet_Prefab, cam.transform.forward, cam.transform.rotation);
        GetComponent<Rigidbody>().velocity = cam.transform.forward * bulletImpulse;

        

        //bullet.rigidbody.AddForce(transform.forward * Speed);

        //var spawnPoint : Transform;
        //var bullet = Instantiate(bullet_Prefab, Spawn.)
    }
}

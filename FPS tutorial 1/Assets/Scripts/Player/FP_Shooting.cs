using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Shooting : MonoBehaviour {

    public GameObject bullet_Prefab;
    private Camera mainCam;

    float spawnDistance = 1.0f;
    float bulletImpulse = 50f;

    // Use this for initialization
    void Start ()
    {
        mainCam = Camera.main;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        var bulletPossition = mainCam.transform.position + spawnDistance * mainCam.transform.forward;
        var bullet = Instantiate(bullet_Prefab, bulletPossition, mainCam.transform.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletImpulse;

        Destroy(bullet, 2.0f);
    }
}

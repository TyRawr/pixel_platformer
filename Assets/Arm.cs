using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


    public Camera playerCamera;
    private Vector2 worldMousePos;
	// Update is called once per frame
	void Update () {
 
    }

    private void FixedUpdate()
    {
        
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);



        float f = Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad);
        //Debug.Log(f);
    }
}

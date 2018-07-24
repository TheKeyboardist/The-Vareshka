using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {
    public float _speed = 20.0f;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if(transform.position.y > 6f)
        {
                Destroy(this.gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;

public class RotateFanScript : MonoBehaviour {

    private float delta = 0f;
    private float speed = 1.5f;
	
	// Update is called once per frame
	void Update () 
    {
        delta += Time.deltaTime * speed;
        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, 
            this.gameObject.transform.rotation * Quaternion.Euler(0, 10, 0), Mathf.Min(delta, 1));
	}
}

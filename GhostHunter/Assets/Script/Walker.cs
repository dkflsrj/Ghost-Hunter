using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {

    // Use this for initialization
    public Transform Destination;
    public float Speed;
    public float StopRange = 1;
    public float MeanZ;
    public float FloatRange = 1;
    public float floating = 0;
	void Start ()
    {
        MeanZ = this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Destination != null)
        {
            this.transform.LookAt(Destination);
            if (Vector3.Distance(this.transform.position, Destination.position) > StopRange)
            {
                this.transform.Translate(0, 0, 0.1f);
            }
        }
	}
}

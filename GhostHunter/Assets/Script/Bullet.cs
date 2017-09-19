using UnityEngine;
using System.Collections;
using System;

public class Bullet : MonoBehaviour
{
    public AudioClip Sound_Create;
    public float Speed = 10;
    public Vector3 Direction = Vector3.zero;
    public Camera aCamera;
    public int Lifetime_s = 10;
    float CreationDate;
    public void SetDirection(Vector3 Direction, Camera aCamera)
    {
        this.Direction = Direction;
        this.aCamera = aCamera;
    }
    // Use this for initialization
	void Start ()
    {
        CreationDate = Time.time;
        this.GetComponent<AudioSource>().Play();
        

    }
    
	
	// Update is called once per frame
	void Update ()
    {
        if(Direction != Vector3.zero)
        {
            transform.Translate(Vector3.forward * Speed);
            if((Time.time - CreationDate) > Lifetime_s)
            {
                Destroy(this.gameObject);
            }
            //float Distance = Vector3.Distance(aCamera.transform.position, this.transform.position);
            //if (Distance > 1)
            //{
            //    this.GetComponent<LensFlare>().brightness *= 10 / Distance;
            //}
            //else if(Distance > 100)
            //{
            //    Destroy(this.gameObject);
            //}
        }

	}
}

using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Bullet = null;
    public float Speed = 1;
    public float RotSpeed = 5;
    public Animator Anim;
    public bool Light_IsOn
    {
        get { return flashlight.enabled; }
        set { flashlight.enabled = value; }

    }
    [SerializeField] UnityStandardAssets.Characters.FirstPerson.MouseLook m_MouseLook;
    Camera aCamera;
    Light flashlight;
    bool flashlight_IsPressed = false;
    bool Mouse_IsPressed = false;
    public float cooldown_s = 2;
    float cooldown = 0;
    public float FireDelay_s = 1;
    float FireDelay = 0;
    // Use this for initialization
    void Start ()
    {
        aCamera = this.GetComponentInChildren<Camera>();
        m_MouseLook.Init(transform, aCamera.transform);
        //flashlight = this.GetComponentInChildren<Light>();
        Anim = GetComponentInChildren<Animator>();

	}
	
	// Update is called once per frame
	void Update ()
    {

        m_MouseLook.LookRotation(transform, aCamera.transform);
        //flashlight.transform.rotation = aCamera.transform.rotation;
        
        if (Input.GetKey(KeyCode.L))
        {
            if(!flashlight_IsPressed)
            {
                flashlight_IsPressed = true;
                Light_IsOn = !Light_IsOn;
            }
        }
        else
        {
            flashlight_IsPressed = false;
        }

        if (Input.GetMouseButton(0))
        {
            if (!Mouse_IsPressed)
            {
                if (Time.time > cooldown)
                {
                    cooldown = Time.time + cooldown_s;
                    FireDelay = Time.time + FireDelay_s;
                    StartCoroutine(PlayAnimation());
                    StartCoroutine(FireTheBall());
                }
            }
        }
        else { Mouse_IsPressed = false; }

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();

        }
        m_MouseLook.UpdateCursorLock();
    }

    private IEnumerator FireTheBall()
    {
        while(FireDelay > Time.time)
        {
            yield return new WaitForSeconds(0.1f);
        }
        GameObject Fireball = (GameObject)Instantiate(Bullet, transform.position, aCamera.transform.rotation);
        Fireball.GetComponent<Bullet>().SetDirection(aCamera.transform.forward, aCamera);

    }

    IEnumerator PlayAnimation()
    {
        Anim.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(1);
        Anim.SetBool("IsAttacking", false);

    }
}

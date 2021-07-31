using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    bool isPressed = false;
    Material mat;
    public AudioSource C;
    public AudioClip C1;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        C = GetComponent<AudioSource>();
    }
    public void Pressed()
    {
        isPressed = true;
    }

    public void Released()
    {
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            mat.color = Color.cyan;
            C.PlayOneShot(C1);
        }
        else
        {
            mat.color = Color.magenta;
            //aud.Stop();
        }
    }
}

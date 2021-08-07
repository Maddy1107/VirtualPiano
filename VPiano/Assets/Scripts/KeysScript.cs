using System;
using UnityEngine;

public class KeysScript : MonoBehaviour
{

    /// <summary>
    /// Constant variables
    /// </summary>

    float KeyRotAngle = 10f;

    Color KeyPressColor = Color.cyan;

    /// <summary>
    /// Changeable variables
    /// </summary>

    Material KeyMat;

    AudioSource KeySound;

    Quaternion KeyOrigRot;
    Quaternion KeyCurrRot;    

    Color KeyOrigColor;
    Color KeyCurrColor;

    bool KeyIsPressed = false;

    float KeyMovesmoothness;
    //private DateTime m_prevCollisionTime;

    private void Start()
    {
        KeyMat = GetComponent<Renderer>().material;

        KeySound = GetComponent<AudioSource>();

        KeyOrigColor = KeyMat.color;
        KeyCurrColor = KeyOrigColor;

        KeyOrigRot = transform.localRotation;
        KeyCurrRot = KeyOrigRot;
    }

    private void Update()
    {
        KeyMat.color = KeyCurrColor;

        if(KeyIsPressed)
        {
            KeyMovesmoothness = 10f;
        }
        else
        {
            KeyMovesmoothness = 2f;
        }
        transform.localRotation = Quaternion.Lerp(transform.localRotation, KeyCurrRot, KeyMovesmoothness * Time.deltaTime);
    }

    private void KeyPressed()
    {
        KeyIsPressed = true;

        //m_prevCollisionTime = System.DateTime.Now;

        UIManager.instance.showName(gameObject);

        KeyCurrColor = KeyPressColor;
        KeyCurrRot = Quaternion.Euler(0f, 0f, KeyRotAngle);

        KeySound.Play();
    }

    private void KeyUnPressed()
    {
        KeyIsPressed = false;

        KeyCurrColor = KeyOrigColor;
        KeyCurrRot = KeyOrigRot;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (System.DateTime.Now.Subtract(m_prevCollisionTime).TotalMilliseconds < 500)
            //return;

        if (!collision.gameObject.CompareTag("Keys"))
        {
            if(!KeyIsPressed)
            {
                KeyPressed();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Keys"))
        {
            KeyUnPressed();
        }
    }

    
}

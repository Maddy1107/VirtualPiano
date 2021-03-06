using UnityEngine;

public class KeysScript : MonoBehaviour
{

    /// <summary>
    /// Constant variables
    /// </summary>

    float KeyRotAngle = 10f;

    Color KeyPressColor = Color.magenta;

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

    float Keysmoothness;

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
        Smoothening();
    }

    /// <summary>
    /// Make the key movement smoother
    /// </summary>
    private void Smoothening()
    {
        Keysmoothness = KeyIsPressed ? 10f : 5f;
        
        transform.localRotation = Quaternion.Lerp(transform.localRotation, KeyCurrRot, Keysmoothness * Time.deltaTime);
        KeyMat.color = Color.Lerp(KeyMat.color, KeyCurrColor, Keysmoothness * Time.deltaTime);
    }

    /// <summary>
    /// When Key is pressed
    /// </summary>
    public void KeyPressed()
    {
        KeyIsPressed = true;

        UIManager.instance.showName(gameObject);

        KeyCurrColor = KeyPressColor;
        KeyCurrRot = Quaternion.Euler(0f, 0f, KeyRotAngle);

        KeySound.Play();
    }

    /// <summary>
    /// When Key press is done
    /// </summary>
    public void KeyUnPressed()
    {
        KeyIsPressed = false;

        KeyCurrColor = KeyOrigColor;
        KeyCurrRot = KeyOrigRot;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Keys"))
        {
            if(!KeyIsPressed &&
            LeftHandDetailsExtractor.instance.GetHandDirection().y <= 0.4f)
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

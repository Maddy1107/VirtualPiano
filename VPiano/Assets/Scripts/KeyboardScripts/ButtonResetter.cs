using UnityEngine;

[RequireComponent(typeof(KeysScript))]
public class ButtonResetter : MonoBehaviour
{
    public float Timer = 0.001f;
    private float timer;
    private bool isPressed;
    private bool isCountingDown;
    KeysScript ks;

    private void Awake()
    {
        ks = GetComponent<KeysScript>();
        isPressed = false;
        isCountingDown = false;
    }

    private void OnEnable()
    {
        PlayMIDI.PressButton += PressButton;
    }

    private void OnDisable()
    {
        PlayMIDI.PressButton -= PressButton;
    }

    private void PressButton(GameObject gameObj)
    {
        if (gameObj == gameObject)
        {
            timer = Timer;
            isPressed = true;
            isCountingDown = true;
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime * 10;

        if (timer <= 0 && isCountingDown)
        {
            ks.KeyUnPressed();
            isPressed = false;
            isCountingDown = false;
        }
    }
}

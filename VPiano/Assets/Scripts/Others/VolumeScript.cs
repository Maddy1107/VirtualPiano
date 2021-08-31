using UnityEngine;

public class VolumeScript : MonoBehaviour
{
    float vol = 1.0f;

    private void Update()
    {
        vol = Mathf.Clamp(vol, 0.0f, 1.0f);

        Debug.Log(vol);

        AudioListener.volume = vol;
    }

    public void IncreaseVol()
    {
        vol += 0.1f;
    }

    public void DecreaseVol()
    {
        vol -= 0.1f;
    }
}

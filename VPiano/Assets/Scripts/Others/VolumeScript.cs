using UnityEngine;
using UnityEngine.UI;


public class VolumeScript : MonoBehaviour
{
    public float sliderval;

    private void Update()
    {
        sliderval = GetComponent<Slider>().value;

    }
    public void AdjustVolume()
    {
        AudioListener.volume = sliderval;
    }
}

using UnityEngine.UI;
using UnityEngine;

public class BPMScript : MonoBehaviour
{
    public static float BPMsliderval;

    private void Update()
    {
        BPMsliderval = GetComponent<Slider>().value;
    }

    public static float GetBPM()
    {
        return BPMsliderval;
    }
}

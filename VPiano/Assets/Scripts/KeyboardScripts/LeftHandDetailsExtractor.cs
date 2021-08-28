using UnityEngine;
using Leap;
using Leap.Unity;

public class LeftHandDetailsExtractor : MonoBehaviour
{
    public static LeftHandDetailsExtractor instance;

    Hand hand;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        hand = GetComponent<CapsuleHand>().GetLeapHand(); ;
    }

    public Vector3 GetHandPos()
    {
        return hand.PalmPosition.ToVector3();
    }
}

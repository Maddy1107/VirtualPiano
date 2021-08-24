using UnityEngine;
using Leap;
using Leap.Unity;

public class RightHandDetailsExtractor : MonoBehaviour
{
    public static RightHandDetailsExtractor instance;

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

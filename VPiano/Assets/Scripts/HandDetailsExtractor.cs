using UnityEngine;
using Leap;
using Leap.Unity;

public class HandDetailsExtractor : MonoBehaviour
{
    public static HandDetailsExtractor instance;

    Hand hand;

    Controller controller;

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

    /*public bool GetHandLeft()
    {
        return hand.IsLeft;
    }

    public bool GetHandRight()
    {
        return hand.IsRight;
    }*/

}

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

    /// <summary>
    /// Get the hand component.
    /// </summary>
    void Update()
    {
        //if (gameObject.activeSelf)
        //{
            hand = GetComponent<CapsuleHand>().GetLeapHand(); ;
        //}
    }

    /// <summary>
    /// Get hand position
    /// </summary>
    /// <returns></returns>
    public Vector3 GetHandPos()
    {
        return hand.PalmPosition.ToVector3();
    }
}

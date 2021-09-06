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

    /// <summary>
    /// Get the hand component.
    /// </summary>
    void Update()
    {
        GetallFilesFromDir.GetFilesfromDir();
        hand = GetComponent<CapsuleHand>().GetLeapHand(); ;
    }

    /// <summary>
    /// Get hand position
    /// </summary>
    /// <returns></returns>
    public Vector3 GetHandPos()
    {
        return hand.PalmPosition.ToVector3();
    }

    /// <summary>
    /// Get hand Direction
    /// </summary>
    /// <returns></returns>
    public Vector3 GetHandDirection()
    {
        return hand.Direction.ToVector3();
    }
}

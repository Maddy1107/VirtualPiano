using UnityEngine;
using Leap;
using Leap.Unity;

public class CameraController : MonoBehaviour
{
    Controller controller;
    Hand hand;

    private void Start()
    {
        controller = new Controller();
    }
    private void Update()
    {
        Hand hand_ = GetComponent<CapsuleHand>().GetLeapHand();
        Debug.Log(hand_.IsLeft); ;
    }
}

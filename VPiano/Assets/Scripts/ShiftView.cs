using UnityEngine;

public class ShiftView : MonoBehaviour
{
    float LeapRigEndLeft;
    float LeapRigEndRight;

    float CameraEndLeft = 26f;
    float CameraEndRight = 45f;

    public GameObject LeapRigObj;

    Vector3 LeapRigTarget;
    Vector3 CameraTarget;

    float smoothness = 2f;

    private void Start()
    {
        LeapRigTarget = LeapRigObj.transform.position;
        CameraTarget = Camera.main.transform.position;
    }

    private void Update()
    {
        float LeapRigEndLeft = LeapRigObj.transform.position.x - (LeapRigObj.transform.localScale.x / 2);
        float LeapRigEndRight = LeapRigObj.transform.position.x + (LeapRigObj.transform.localScale.x / 2);
        float HandXPos = HandDetailsExtractor.instance.GetHandPos().x;

        if (HandXPos <= LeapRigEndLeft)
        { ViewShift("Left"); }
        else if (HandXPos >= LeapRigEndRight)
        { ViewShift("Right"); }

        Shift();
        Debug.Log("Hand PosX = " + HandXPos);
        Debug.Log("LeftEnd = " + LeapRigEndLeft);
        Debug.Log("RightEnd = " + LeapRigEndRight);
    }

    public void Shift()
    {
        LeapRigObj.transform.position = Vector3.Lerp(LeapRigObj.transform.position, LeapRigTarget, smoothness * Time.deltaTime);
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, CameraTarget, smoothness * Time.deltaTime);
    }

    public void ViewShift(string direction)
    {
        if (direction == "Left")
        {
            if (Camera.main.transform.position.x < CameraEndLeft)
                return;

            LeapRigTarget.x = LeapRigEndLeft;
            CameraTarget.x = CameraEndLeft;
        }
        else if (direction == "Right")
        {
            if (Camera.main.transform.position.x < CameraEndRight)
                return;

            LeapRigTarget.x = LeapRigEndRight;
            CameraTarget.x = CameraEndRight;
        }
    }
}

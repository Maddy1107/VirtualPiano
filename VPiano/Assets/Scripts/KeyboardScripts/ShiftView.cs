using UnityEngine;

public class ShiftView : MonoBehaviour
{
    float EndLeft = 25f;
    float EndRight = 55f;

    float shiftAmount = 1.5f;

    public GameObject LeapRigObj;

    [SerializeField] Vector3 LeapRigTarget;
    [SerializeField] Vector3 CameraTarget;

    float smoothness = 2f;

    float LeapRigEndLeftBound;
    float LeapRigEndRightBound;
    float LeftHandXPos;
    float RightHandXPos;

    private void Start()
    {
        LeapRigTarget = LeapRigObj.transform.position;
        CameraTarget = Camera.main.transform.position;
    }

    private void Update()
    {
        if (LeftHandDetailsExtractor.instance != null)
        {
            if (LeftHandDetailsExtractor.instance.GetHandDirection().y <= 0.4f)
            {
                ShiftCheck();
            }
        }

        Shift();
    }

    public void ShiftCheck()
    {
        LeapRigEndLeftBound = LeapRigTarget.x - 7;
        LeapRigEndRightBound = LeapRigTarget.x + 7;
        
        LeftHandXPos = LeftHandDetailsExtractor.instance.GetHandPos().x;
        RightHandXPos = RightHandDetailsExtractor.instance.GetHandPos().x;


        if (LeftHandXPos <= LeapRigEndLeftBound &&
            LeftHandXPos <= LeapRigTarget.x)
        {
            ViewShift("Left");
        }

        if (RightHandXPos >= LeapRigEndRightBound &&
            RightHandXPos >= LeapRigTarget.x)
        {
            ViewShift("Right");
        }
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
            if (Camera.main.transform.position.x >= EndLeft)
            {
                LeapRigTarget.x -= shiftAmount;
                CameraTarget.x -= shiftAmount;
            }            
        }
        else if (direction == "Right")
        {
            if (Camera.main.transform.position.x <= EndRight)
            {
                LeapRigTarget.x += shiftAmount;
                CameraTarget.x += shiftAmount;
            }       
        }
    }
}

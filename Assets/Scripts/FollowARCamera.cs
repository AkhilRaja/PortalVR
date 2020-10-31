using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowARCamera : MonoBehaviour
{
    public Transform aRCoreCamera;

    public Text debugText;

    Vector3 smoothedPosition;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float speed = 7.5f; 
    private float maxSpeed;

    //Magic number that works well
    private Vector3 headRotationCorrection = new Vector3(0, 0, 0.0159f);


    public float mirrorAngle = 0;
    private Quaternion deltaPosition;

    void Update()
    {
        if (mirrorAngle != 0f)
        {
            deltaPosition = Quaternion.AngleAxis(mirrorAngle, Vector3.up) * deltaPosition;
        }

        startPosition = this.transform.position;
        endPosition = aRCoreCamera.transform.position - headRotationCorrection; 
        maxSpeed = speed * Time.deltaTime;
        //Lerping to smooth out the movement
        smoothedPosition = Vector3.Lerp(startPosition, endPosition, maxSpeed);

        this.transform.position = smoothedPosition;
        debugText.text = smoothedPosition.ToString();
    }
}

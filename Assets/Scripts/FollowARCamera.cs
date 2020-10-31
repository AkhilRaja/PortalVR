using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowARCamera : MonoBehaviour
{
    public Transform aRCoreCamera;

    public Text tulisan;

    Vector3 smoothedPosition;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float speed = 7.5f; //2.5 works also with some slow down
    private float maxSpeed;

    // 0.0159 is the distance the camera is away from the head. This leads to position changes when turning the had and we wanna avoid that. The current setting need still more refinement. 
    private Vector3 headRotationCorrection = new Vector3(0, 0, 0.0159f);


    public float mirrorAngle = 0;
    private Quaternion deltaPosition;

    // the update method is twice as fast as the ARCore Camera. To avoid jittering we use Lerp to smooth out the movement at the start and the end of the movement.
    void Update()
    {

        //correct the delta vector by given angle
        if (mirrorAngle != 0f)
        {
            deltaPosition = Quaternion.AngleAxis(mirrorAngle, Vector3.up) * deltaPosition;
        }

        startPosition = this.transform.position;
        endPosition = aRCoreCamera.transform.position - headRotationCorrection; // TODO not sure if headRotationCorrection even helps.
        maxSpeed = speed * Time.deltaTime;
        // Using Lerp this way is a trick. TODO: There are probably better solutions which should also be tested and might reduce lag further.
        smoothedPosition = Vector3.Lerp(startPosition, endPosition, maxSpeed);

        this.transform.position = smoothedPosition;
        tulisan.text = smoothedPosition.ToString();
    }
}

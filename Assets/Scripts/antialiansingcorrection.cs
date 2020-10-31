using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antialiansingcorrection : MonoBehaviour
{
    void Start()
    {
        // higher values up to 4 ight look better but 2 is recommendet for mobile VR.
        QualitySettings.antiAliasing = 2;
    }
}

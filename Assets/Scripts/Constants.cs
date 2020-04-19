using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    /*
        0.2723999          -0.97       -3.56094110167
        0.5954437          -3.17       -5.32376108774
       -2.2348060          -9.64        4.31357352719
    */
    const float _backgroundCenterPositionXMultiplier = -3.56094110167f;
    const float _backgroundCenterPositionYMultiplier = -5.32376108774f;
    const float _backgroundCenterPositionZMultiplier = 4.31357352719f;

    [SerializeField]
    Vector3 _backgroundCenterPositionMultiplier =
    new Vector3(_backgroundCenterPositionXMultiplier, _backgroundCenterPositionYMultiplier, _backgroundCenterPositionZMultiplier);

    public Vector3 BackgroundCenterPositionMultiplier
    {
        get { return _backgroundCenterPositionMultiplier; }
        set { _backgroundCenterPositionMultiplier = value; }
    }

    [SerializeField]
    float _backgroundCenterScaleMultiplier = 1.0f;

    public float BackgroundCenterScaleMultiplier
    {
        get { return _backgroundCenterScaleMultiplier; }
        set { _backgroundCenterScaleMultiplier = value; }
    }
}

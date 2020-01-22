using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWander : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

        
    public Transform[] points;
    public int currentPointIndex=0;
    public Transform lookAtTarget;

    private bool _started = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _started = !_started;
            StartCoroutine(CameraTransition(points[currentPointIndex%points.Length],10.0f));
            currentPointIndex++;
            
        }
    }

    IEnumerator CameraTransition(Transform nextPoint,float time)
    {
        float i = 0;
        float rate = 1 / time;

        Vector3 fromPos = transform.position;

        while (i<1)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(fromPos,nextPoint.position,i);


            //Quaternion targetRotation = Quaternion.LookRotation(nextPoint.position-transform.position);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,i);

            Quaternion targetRotation = Quaternion.LookRotation(lookAtTarget.position-transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,i);

            yield return 0;
        }
        if (_started) {
            currentPointIndex++;
            StartCoroutine(CameraTransition(points[currentPointIndex%points.Length],10.0f));
        }

    }
}
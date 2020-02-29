using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 targetCameraPosition = target.position + offset;

        transform.position =
            Vector3.Lerp(transform.position, // 0 Min
            targetCameraPosition,            // 100 Max
            smoothing * Time.deltaTime);     // 0.5 = 50

        //deltatime == FPS 60 이다. == 0.01666667 1초에 60번 그린다.
    }

}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    public float smoothness = 10f;

    private void Start()
    {
        transform.position = target.position + offset;
    }
    void LateUpdate()
    {
        Vector3 playerPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, playerPos, smoothness * Time.deltaTime);
        transform.position = smoothedPos; 
    }

}

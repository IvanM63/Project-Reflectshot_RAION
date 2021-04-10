using UnityEngine;

public class followCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothFactor;

    private void FixedUpdate() {
        Follow();
    }

    void Follow() {
        Vector3 targetPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPos;
    }
}

using UnityEngine;
using System.Collections;

public class MyCameraFollow : MonoBehaviour {
    public Transform target;
    public float smoothTime = 1f;

    Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = - target.position + transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCameraPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCameraPos, Time.deltaTime * smoothTime);
        transform.LookAt(target);
	}
}

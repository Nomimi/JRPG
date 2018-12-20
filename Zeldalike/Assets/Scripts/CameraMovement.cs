using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    public float smoothing;

    public Vector2 maxXPosition = new Vector2(3f,0);
    public Vector2 minXPosition = new Vector2(-3f, 0);

    public Vector2 maxYPosition = new Vector2(0f, 1.6f);
    public Vector2 minYPosition = new Vector2(0f,-1.6f);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (transform.position.x != target.position.x || transform.position.y != target.position.y)
        {

            Vector3 targetPosition= new Vector3(target.position.x, target.position.y, this.transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minXPosition.x, maxXPosition.x);

            targetPosition.y = Mathf.Clamp(targetPosition.y, minYPosition.y, maxYPosition.y);


            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
	}
}

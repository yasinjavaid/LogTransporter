using UnityEngine;
using System.Collections;

public class vRotateObject : MonoBehaviour {
    public Vector3 rotationSpeed;
	
	// Update is called once per frame
	void LateUpdate () {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
	}
}

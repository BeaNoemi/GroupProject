using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	private Transform myTransform;
	private Camera mCamera;
    private Quaternion OriginalRotation;

    private float RotationX = 0f;
    private float RotationY = 0f;

    public float sensitivityX = 200f;
	public float sensitivityY = 20f;
	public float minimumY = 0f;
	public float maximumY = 10f;

    void Awake(){
        myTransform = transform;
        mCamera = Camera.mainCamera;
        OriginalRotation = transform.localRotation;
    }

	void FixedUpdate(){
        RotationY -= Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;
        RotationY = Mathf.Clamp(RotationY, minimumY, maximumY);

        //mCamera.transform.position = new Vector3(mCamera.transform.position.x, RotationY, mCamera.transform.position.z);
        //mCamera.transform.LookAt(myTransform);
	}
}
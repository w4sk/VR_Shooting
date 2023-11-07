using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAvatar : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] float step = 5.0f;
    Quaternion targetRot;
    bool isCCW;

    private void RotateObject(float speed)
    {
        // Spaceキーが押されている間、回転を実行

        float rotationAmount = speed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }

    // Update is called once per frame
    void Update()
    {
        targetRot = Quaternion.AngleAxis(180 / createAvatarSelector.avatarNum, Vector3.up);

        if(!SelectMotionController.isAvatarSelected)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.LTouch)){
                // this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRot, step);
                isCCW = false;
                RotateObject(speed);
            }
                if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch)){
                // this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRot, step);
                isCCW = true;
                RotateObject(-speed);
            }
        }
        

        
    }
        
}

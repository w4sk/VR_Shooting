using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAnimationController : MonoBehaviour
{
    private Animator controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<Animator>();
        ResetAnimation();
        controller.SetTrigger("stop");
    }

    void ResetAnimation()
    {   
        controller.ResetTrigger("walkF");
        controller.ResetTrigger("walkB");
        controller.ResetTrigger("walkR");
        controller.ResetTrigger("walkL");
        // controller.ResetTrigger("stop");
    }

    // Update is called once per frame
    void Update()
    {
        // 前進Animation
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.LTouch)){
            ResetAnimation();
            controller.SetTrigger("walkF");
        }

        // 後退Animation
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.LTouch)){
            ResetAnimation();
            controller.SetTrigger("walkB");
        }

        // 右横歩き
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.LTouch)){
            ResetAnimation();
            controller.SetTrigger("walkR");
        }

        // 左横歩き
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch)){
            ResetAnimation();
            controller.SetTrigger("walkL");
        }

        // idle状態
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.LTouch)
            || OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.LTouch)
            || OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.LTouch)
            || OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch)
        ){
            ResetAnimation();
            controller.SetTrigger("stop");
        }

    }
}

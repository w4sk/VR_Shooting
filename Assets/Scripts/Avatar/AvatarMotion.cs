using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Animator animator = GetComponent<Animator>();
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.Touch)){
            animator.SetBool("isPressA", true);
            Debug.Log("Pressd!");
        }
    }
}

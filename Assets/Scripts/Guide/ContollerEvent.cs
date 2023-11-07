using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ContollerEvent : MonoBehaviour
{

    public GameObject A;
    public GameObject B;
    public GameObject X;
    public GameObject Y;

    public GameObject ZR1;
    public GameObject ZR2;
    // public GameObject ZL1;
    // public GameObject ZL2;

    public GameObject Rstick;
    public GameObject Lstick;
    void Start()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {

// A(Button.One)--------------------------------------------------------------
    if(OVRInput.Get(OVRInput.Button.One))
    {
        Debug.Log("Aボタンを押しています");

    }

    if(OVRInput.GetDown(OVRInput.Button.One))
    {
        Debug.Log("Aボタンを押しました");
        A.GetComponent<Renderer>().material.color = Color.green;
    }

    if(OVRInput.GetUp(OVRInput.Button.One))
    {
        Debug.Log("Aボタンを離しました");
        A.GetComponent<Renderer>().material.color = Color.white;
    }
// B(Button.Two)--------------------------------------------------------------
    if(OVRInput.Get(OVRInput.Button.Two))
    {
        Debug.Log("Bボタンを押しています");

    }

    if(OVRInput.GetDown(OVRInput.Button.Two))
    {
        Debug.Log("Bボタンを押しました");
        B.GetComponent<Renderer>().material.color = Color.green;
    }

    if(OVRInput.GetUp(OVRInput.Button.Two))
    {
        Debug.Log("Bボタンを離しました");
        B.GetComponent<Renderer>().material.color = Color.white;
    }
// X(Button.Three)--------------------------------------------------------------
    if(OVRInput.Get(OVRInput.Button.Three))
    {
        Debug.Log("Xボタンを押しています");

    }

    if(OVRInput.GetDown(OVRInput.Button.Three))
    {
        Debug.Log("Xボタンを押しました");
        X.GetComponent<Renderer>().material.color = Color.green;
    }

    if(OVRInput.GetUp(OVRInput.Button.Three))
    {
        Debug.Log("Xボタンを離しました");
        X.GetComponent<Renderer>().material.color = Color.white;
    }
// --------------------------------------------------------------
    if(OVRInput.Get(OVRInput.Button.Four))
    {
        Debug.Log("Yボタンを押しています");

    }

    if(OVRInput.GetDown(OVRInput.Button.Four))
    {
        Debug.Log("Yボタンを押しました");
        Y.GetComponent<Renderer>().material.color = Color.green;
    }

    if(OVRInput.GetUp(OVRInput.Button.Four))
    {
        Debug.Log("Yボタンを離しました");
        Y.GetComponent<Renderer>().material.color = Color.white;
    }
// --------------------------------------------------------------
//     if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
//     {
//         Debug.Log("ZL1ボタンを押しています");

//     }

//     if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
//     {
//         Debug.Log("ZL1ボタンを押しました");
//         ZL1.GetComponent<Renderer>().material.color = Color.green;
//     }

//     if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
//     {
//         Debug.Log("ZL1ボタンを離しました");
//         ZL1.GetComponent<Renderer>().material.color = Color.white;
//     }
// // --------------------------------------------------------------
//     if(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
//     {
//         Debug.Log("ZL2ボタンを押しています");

//     }

//     if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
//     {
//         Debug.Log("ZL2ボタンを押しました");
//         ZL2.GetComponent<Renderer>().material.color = Color.green;
//     }

//     if(OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
//     {
//         Debug.Log("ZL2ボタンを離しました");
//         ZL2.GetComponent<Renderer>().material.color = Color.white;
//     }
// --------------------------------------------------------------
    if(OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
    {
        Debug.Log("ZR1ボタンを押しています");

    }

    if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
    {
        Debug.Log("ZR1ボタンを押しました");
        ZR1.GetComponent<Renderer>().material.color = Color.green;
    }

    if(OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
    {
        Debug.Log("ZR1ボタンを離しました");
        ZR1.GetComponent<Renderer>().material.color = Color.white;
    }
// --------------------------------------------------------------
    if(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
    {
        Debug.Log("ZR2ボタンを押しています");

    }

    if(OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
    {
        Debug.Log("ZR2ボタンを押しました");
        ZR2.GetComponent<Renderer>().material.color = Color.green;
    }

    if(OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
    {
        Debug.Log("ZR2ボタンを離しました");
        ZR2.GetComponent<Renderer>().material.color = Color.white;
    }




// スティック
    Vector2 leftStickValue = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
    // Debug.Log("[左手]" + "\nX:" + leftStickValue.x + "\nY:" + leftStickValue.y);
    if(leftStickValue.x != 0 && leftStickValue.y != 0)
    {
        Lstick.GetComponent<Renderer>().material.color = Color.green;
    }
    else
    {
        Lstick.GetComponent<Renderer>().material.color = Color.white;
    }

    Vector2 rightStickValue = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
    // Debug.Log("[右手]" + "\nX:"+ rightStickValue.x +"\nY:"+ rightStickValue.y);

    if(rightStickValue.x != 0 && rightStickValue.y != 0)
    {
        Rstick.GetComponent<Renderer>().material.color = Color.green;
    }
    else
    {
        Rstick.GetComponent<Renderer>().material.color = Color.white;
    }












    }


}
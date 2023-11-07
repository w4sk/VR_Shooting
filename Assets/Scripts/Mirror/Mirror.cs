using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField] GameObject TrackingCamera;
    [SerializeField] GameObject ReflectionCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // カメラから鏡面へのベクトル
        Vector3 diff = this.transform.position - TrackingCamera.transform.position;
        // 鏡面の垂直ベクトル
        Vector3 normal = this.transform.forward;
        // 鏡面からの反射ベクトル
        Vector3 reflection = diff + 2*(Vector3.Dot(-diff, normal)) * normal;

        ReflectionCamera.transform.position = this.transform.position - reflection;
        // ReflectionCamera.transform.LookAt()
    }
}

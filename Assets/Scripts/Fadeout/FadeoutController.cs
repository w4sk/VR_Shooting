using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeoutController : MonoBehaviour
{
    [SerializeField] GameObject PlayerCenterEye;
    private OVRScreenFade _OVRScreenFade;
    // Start is called before the first frame update
    void Start()
    {
        _OVRScreenFade = PlayerCenterEye.GetComponent<OVRScreenFade>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SelectMotionController.isControllerPrefabOff)
        {
            _OVRScreenFade.enabled = true;
            // 自身を消す

            FadeoutController _FadeoutController = this.GetComponent<FadeoutController>();
            Destroy(_FadeoutController);
        }
    }
}

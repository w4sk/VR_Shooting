using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarControlManager : MonoBehaviour
{
    [SerializeField] private GameObject Avatar;
    private OVRPlayerController _OVRPlayerController;
    // Start is called before the first frame update
    void Start()
    {
        _OVRPlayerController = Avatar.GetComponent<OVRPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SelectMotionController.isCharacterShowCaseMovingFinished)
        {
            _OVRPlayerController.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObjectURP : MonoBehaviour
{
    public OVRScreenFade s_OVRScreenFade;

    [SerializeField] private GameObject CharacterShowCase;
    [SerializeField] private GameObject Floor;

    private bool isFadeOutFirst = true;
    private bool isFadeInFirst = true;
    
    private void Update()
    {
        if(CharacterShowCase.transform.position.y - Floor.transform.position.y < -2.0f && isFadeOutFirst)
        {
            s_OVRScreenFade.FadeOut();
            isFadeOutFirst = false;
        }

        if(SelectMotionController.isCharacterShowCaseMovingFinished && isFadeInFirst)
        {
            s_OVRScreenFade.FadeIn();
            isFadeInFirst = false;
        }
    }
}
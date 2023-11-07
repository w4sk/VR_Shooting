using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMirrorObject : MonoBehaviour
{
    [SerializeField] GameObject MirrorObject;
    // Update is called once per frame
    void Update()
    {
        if(SelectMotionController.isCharacterShowCaseMovingFinished)
        {
            MirrorObject.SetActive(true);
            PlaceMirrorObject placeMirrorObject = this.GetComponent<PlaceMirrorObject>();
            Destroy(placeMirrorObject);
        }

    }
}

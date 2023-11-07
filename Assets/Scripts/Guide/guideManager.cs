using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guideManager : MonoBehaviour
{
    [SerializeField] private GameObject guide;
    private spawnGuide _spawnGuide;
    private bool isSpawnGuideActive = false;

    void Start()
    {
        _spawnGuide = this.GetComponent<spawnGuide>();
    }
    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Three))
        {
            _spawnGuide.enabled = isSpawnGuideActive;
            if(!isSpawnGuideActive)
            {
                guide.SetActive(false);
            }
            isSpawnGuideActive = !isSpawnGuideActive;
        }

        if(SelectMotionController.isCharacterShowCaseMovingFinished)
        {
            guide.SetActive(false);
        }
    }
}

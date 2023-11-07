using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBlinking : MonoBehaviour
{
    [SerializeField] private GameObject[] avatarSelectPhaseButtons;
    [SerializeField] private GameObject[] avatarControlPhaseButtons;

    [SerializeField] private GameObject selectGuide;
    [SerializeField] private GameObject controlGuide;


    [SerializeField] private bool isAvatarSelectPhase = true;
    [SerializeField] private bool isAvatarControlPhase = false;

    private int avatarSelectPhaseButtonCount;
    private int avatarControlPhaseButtonCount;

    public float blinkSpeed = 2.0f; // 点滅の速さ
    private bool isBlinking = false;

    private MeshRenderer[] avatarSelectPhaseRends;
    private MeshRenderer[] avatarControlPhaseRends;

    private Color[] avatarSelectPhaseOriginalColors;
    private Color[] avatarControlPhaseOriginalColors;

    // Start is called before the first frame update
    void Start()
    {   
        avatarSelectPhaseButtonCount = avatarSelectPhaseButtons.Length;
        avatarControlPhaseButtonCount = avatarControlPhaseButtons.Length;

        avatarSelectPhaseRends = new MeshRenderer[avatarSelectPhaseButtonCount];
        avatarControlPhaseRends = new MeshRenderer[avatarControlPhaseButtonCount];

        avatarSelectPhaseOriginalColors = new Color[avatarSelectPhaseButtonCount];
        avatarControlPhaseOriginalColors = new Color[avatarControlPhaseButtonCount];

        
        for(int i = 0; i < avatarSelectPhaseButtonCount; i++)
        {
            avatarSelectPhaseRends[i] = avatarSelectPhaseButtons[i].GetComponent<MeshRenderer>();
            avatarSelectPhaseOriginalColors[i] = Color.green;
        }

        for(int i = 0; i < avatarControlPhaseButtonCount; i++)
        {
            avatarControlPhaseRends[i] = avatarControlPhaseButtons[i].GetComponent<MeshRenderer>();
            avatarControlPhaseOriginalColors[i] = Color.green;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
        float alpha = Mathf.PingPong(Time.time * blinkSpeed, 1.0f);
        
        if(isAvatarSelectPhase)
        {
            selectGuide.SetActive(true);
            controlGuide.SetActive(false);
            for(int i = 0; i < avatarSelectPhaseButtonCount; i++)
            {
                Color newColor = avatarSelectPhaseOriginalColors[i];
                newColor.a = alpha;
                avatarSelectPhaseRends[i].material.color = newColor;
            }
        }

        if(isAvatarSelectPhase && SelectMotionController.isCharacterShowCaseMovingFinished)
        {
            isAvatarSelectPhase = false;
            isAvatarControlPhase = true;
            for(int i = 0; i < avatarSelectPhaseButtonCount; i++)
            {
                Color newColor = avatarSelectPhaseOriginalColors[i];
                newColor.a = 0.0f;
                avatarSelectPhaseRends[i].material.color = newColor;
            }
        } 

        if(isAvatarControlPhase)
        {
            selectGuide.SetActive(false);
            controlGuide.SetActive(true);
            for(int i = 0; i < avatarControlPhaseButtonCount; i++)
            {
                Color newColor = avatarControlPhaseOriginalColors[i];
                newColor.a = alpha;
                avatarControlPhaseRends[i].material.color = newColor;
            }
        }
    }
}

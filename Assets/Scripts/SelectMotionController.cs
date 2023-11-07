using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectMotionController : MonoBehaviour
{
    [SerializeField] GameObject Avatar;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject AvatarShowCase;
    GameObject AvatarSelector;
    GameObject PlayerController;
    [SerializeField] TextMeshPro textMeshPro3D;
    Animator m_Animator;
    public static bool isControllerPrefabOff = false;
    public static bool isAvatarSelected = false;

    // 選んだアバターの名前を保存
    public static string selectedAvatarName = "Avatar1";

    // 移動完了したことを表すbool値
    public static bool isCharacterShowCaseMovingFinished = false;

    // Start is called before the first frame update
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private bool isSelected = false;

    public static bool AvatarSelectComplete = false;

    void Start()
    {
        m_Animator = Avatar.GetComponent<Animator>();
        initialPosition = Avatar.transform.localPosition;
        initialRotation = Avatar.transform.localRotation;
    }

    public void toSelectedMotion()
    {
        // m_Animator = Avatar.GetComponent<Animator>();
        m_Animator.ResetTrigger("notSelected");
        m_Animator.SetTrigger("selected");
        UI.SetActive(true);
    }

    public void toIdleMotion()
    {
        // m_Animator = Avatar.GetComponent<Animator>();
        m_Animator.ResetTrigger("selected");
        m_Animator.SetTrigger("notSelected");
        if(!isSelected){
            Avatar.transform.localRotation = initialRotation;
            Avatar.transform.localPosition = initialPosition;
            UI.SetActive(false);
        }

    }

    public void characterSelected()
    {
        // m_Animator = Avatar.GetComponent<Animator>();

        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch)){
            AvatarSelectComplete = true;
            m_Animator.SetTrigger("completed");
            isSelected = true;
            textMeshPro3D.text = "Avatar Selected!!";

            // ここで，アバターが選択されたことを示すbool値を設定する
            isAvatarSelected = true;

            // ここで，選んだ対象を持ってきたい　   
            selectedAvatarName = Avatar.name;

            StartCoroutine(firstCoroutine());
        }
    }

    IEnumerator firstCoroutine()
    {

        yield return new WaitForSeconds(2f);

        StartCoroutine(moveAvatars());
    }

    [SerializeField] float duration = 5f; // 移動にかかる時間
    [SerializeField] float targetY = -2f; // 目標のY座標

    private Vector3 Avatar_initialPosition;
    private Vector3 Avatar_targetPosition;
    private float elapsedTime = 0f;
    IEnumerator moveAvatars()
    {
        AvatarSelector = GameObject.FindWithTag("AvatarSelector");
        SelectAvatar selectAvatar = AvatarSelector.GetComponent<SelectAvatar>();
        selectAvatar.enabled = false;
        // Avatar Origin movement
        Avatar_initialPosition = AvatarSelector.transform.position;
        Avatar_targetPosition = Avatar_initialPosition;
        Avatar_targetPosition.y = targetY;

        while (elapsedTime < duration)
        {
            AvatarSelector.transform.position = Vector3.Lerp(Avatar_initialPosition, Avatar_targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 移動が完了したら、最終的な位置に設定
        AvatarSelector.transform.position = Avatar_targetPosition;

        // 移動完了したことを表すbool値
        isCharacterShowCaseMovingFinished = true;

        PlayerController = GameObject.FindWithTag("Player");

        // アバターを着る
        GameObject avatarSkin = PlayerController.transform.Find(selectedAvatarName).gameObject;

        if (avatarSkin == null){
            Debug.Log("Avatar Not Found");
            avatarSkin = PlayerController.transform.Find("Avatar1").gameObject;
        }

        avatarSkin.SetActive(true);

        // ControllerPrefabのOn/Off

        isControllerPrefabOff = true;
    
        CharacterController controller = PlayerController.GetComponent<CharacterController>();
        controller.enabled = true;

        


        // LookRotation lookRotation = AvatarShowCase.GetComponent<LookRotation>();
        // lookRotation.enabled = false;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadController: MonoBehaviour
{
    [SerializeField]
    private GameObject GrabHand;
    [SerializeField]
    private GameObject[] M4Magazines = new GameObject[5];

    public static bool isMagazineGrabbed = false;

    public static int MagazineCounter = 0;

    private OVRGrabber m_grabber;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_grabber = GrabHand.GetComponent<OVRGrabber>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {   
            if(m_grabber.grabbedObject == null){
                return;
            }
            else
            {
                if(m_grabber.grabbedObject.tag.Contains("Magazine"))
                {
                    isMagazineGrabbed = true;
                    rigidbody = M4Magazines[MagazineCounter].GetComponent<Rigidbody>();
                    string MagazineTag = m_grabber.grabbedObject.tag;
                }

            }   
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            rigidbody.isKinematic = false;
        }

        if(FpsGunController.isReloadCompleted)
        {
            Debug.Log(MagazineCounter);
            if(MagazineCounter - 1< M4Magazines.Length){
                M4Magazines[MagazineCounter - 1].SetActive(false);
                if(MagazineCounter - 2< M4Magazines.Length)
                {
                    M4Magazines[MagazineCounter].SetActive(true);
                }
            }
            isMagazineGrabbed = false;
        }

    }
}

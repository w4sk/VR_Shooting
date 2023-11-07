using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject[] guns;

    private string[] gunTags = new string[1];
    private int gunNum;

    private Vector3 GunTransform = new Vector3(-0.012f,0.043f,0.087f);

    [SerializeField]
    private Transform parentObject;

    // Start is called before the first frame update
    void Start()
    {
        gunNum = guns.Length;
        Debug.Log(gunNum);
        // tagをキャッシュ
        for(int i=0;i < gunNum; i++)
        {
            gunTags[i] = guns[i].tag;
        }
        
    }



    void OnTriggerEnter(Collider other)
    {
        string otherObjectTag = other.gameObject.tag;
        if(otherObjectTag.Contains("Gun"))
        {
            for(int i=0;i < gunNum; i++)
            {
                if(gunTags[i] == otherObjectTag)
                {   
                    GameObject Gun = GameObject.FindWithTag("Gun/M4");
                    Destroy(Gun);
                    GameObject clone;
                    clone = Instantiate(guns[i], GunTransform, Quaternion.identity, parentObject);
                    clone.transform.localPosition = GunTransform;
                    clone.transform.localRotation = Quaternion.identity;
                }
                else{
                }
            }
        }
    }
}

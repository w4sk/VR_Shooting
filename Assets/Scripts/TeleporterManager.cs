using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterManager : MonoBehaviour
{
    [SerializeField] GameObject teleporter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(SelectMotionController.AvatarSelectComplete)
        {
            StartCoroutine(firstCoroutine());
        }
    }


    IEnumerator firstCoroutine()
    {
        yield return new WaitForSeconds(10f);

        teleporter.SetActive(true);
    }

}

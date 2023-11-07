using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ControllerPrefabs;

    // Update is called once per frame
    void Update()
    {
        if(SelectMotionController.isControllerPrefabOff)
        {
            foreach(GameObject ControllerPrefab in ControllerPrefabs)
            {
                ControllerPrefab.SetActive(false);
            }

            PlayerControllerManager playerControllerManager = this.GetComponent<PlayerControllerManager>();
            Destroy(playerControllerManager);
        }       
    }
}

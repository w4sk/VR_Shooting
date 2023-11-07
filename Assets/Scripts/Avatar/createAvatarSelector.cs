using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createAvatarSelector : MonoBehaviour
{
    public static  int avatarNum = 8;
    [SerializeField] float radius = 5;
    [SerializeField] GameObject[] Avatars = new GameObject[avatarNum];
    [SerializeField] Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < avatarNum; i++){
            float spawnPointAngle = 2 * Mathf.PI / avatarNum * i;
            float x = Mathf.Cos(spawnPointAngle) * radius;
            float z = Mathf.Sin(spawnPointAngle) * radius;
            Vector3 spawnPoint = new Vector3(x, 0.0f, z);
            Instantiate(Avatars[i], spawnPoint, Quaternion.identity, parent);
        }
    }
}

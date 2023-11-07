using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCobotControllerManager : MonoBehaviour
{
    [SerializeField] private Transform ControllerBase;
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject Guide;
    [SerializeField] private GameObject Controller;
    [SerializeField] private float thresholds;
    [SerializeField] private Material baseMaterial;
    [SerializeField] private Material newMaterial;

    private spawnGuide _spawnGuide;
    private MeshRenderer _meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spawnGuide = ControllerBase.GetComponent<spawnGuide>();
        _meshRenderer = Controller.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ControllerBasePosition = ControllerBase.position;
        Vector3 PlayerPosition = Player.position;
        Debug.Log(Vector3.Distance(ControllerBasePosition, PlayerPosition) );
        if(Vector3.Distance(ControllerBasePosition, PlayerPosition) < thresholds)
        {
            _spawnGuide.enabled = true;
            _meshRenderer.material = newMaterial;
        }
        else
        {
            _spawnGuide.enabled = false;
            _meshRenderer.material = baseMaterial;
            Guide.SetActive(false);
        }
    }
}

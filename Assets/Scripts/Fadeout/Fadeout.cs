using UnityEngine;

public class Fadeout: MonoBehaviour {
    // フェードアウトするまでの時間(0.5sec)
    [SerializeField] private float fadeTime;
    private float time;
    private MeshRenderer render;
    private int materialNum;


    void Start () {
        render = this.GetComponent<MeshRenderer>();
        if (render != null)
        {
            materialNum = render.sharedMaterials.Length;
            Debug.Log("Number of materials: " + materialNum);
        }
        else
        {
            Debug.Log("MeshRenderer is not Found");
        }

    }

    void Update () {
        time += Time.deltaTime;

        if (time < fadeTime)
        {
            float alpha = 1.0f - time / fadeTime;

            Material[] materials = render.sharedMaterials;

            foreach (Material material in materials)
            {
                Color color = material.color;
                color.a = alpha;
                material.color = color;
            }
        }
        // else{
        //     Destory();
        // }
    }
}
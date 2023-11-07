using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class spawnGuide : MonoBehaviour
{
    // Scaling Target Object
    [SerializeField] private GameObject guide;
    [SerializeField] private float taegetGuideScalse = 10.0f;
    [SerializeField] private float scaleFactor = 0.01f;  // オブジェクトの拡大率を設定します。
    [SerializeField] private float scaleSpeed = 1.0f;   // オブジェクトの拡大速度を設定します。
    private Vector3 initialScale;     // オブジェクトの初期スケールを保持します。
    private bool isScaling = true;   // オブジェクトが拡大中かどうかを示すフラグ。
    [SerializeField] private float delayTime = 2.0f;

    private VideoPlayer targetVideo;


    private IEnumerator scalingGameObject(float targetScalseRatio)
    {
        while (isScaling)
        {
            // 各軸ごとにスケールを変更せず、均等に拡大します。
            float scaleAmount = scaleFactor * scaleSpeed * Time.deltaTime;
            Vector3 newScale = guide.transform.localScale + Vector3.one * scaleAmount;
            // オブジェクトが一定の大きさに達したら拡大を停止します。
            if (newScale.x >= initialScale.x * targetScalseRatio && newScale.y >= initialScale.y * targetScalseRatio)
            {
                isScaling = false;
            }
            else
            {
                if (newScale.x >= initialScale.x * targetScalseRatio)
                {
                    newScale.x = initialScale.x * targetScalseRatio;
                }
                if (newScale.y >= initialScale.y * targetScalseRatio)
                {
                    newScale.y = initialScale.y * targetScalseRatio;
                }
                guide.transform.localScale = newScale;
            }
            yield return null;
        }
        if(targetVideo != null)
        {
            targetVideo.enabled = true;
            targetVideo.Play();
        }
        
    }

    void Start()
    {
        initialScale = guide.transform.localScale; // オブジェクトの初期スケールを保存します。
        targetVideo = guide.GetComponent<VideoPlayer>();
    }

    void OnEnable()
    {
        StartCoroutine(ExecuteAfterDelay());
        isScaling = true;
    }


    private IEnumerator ExecuteAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        guide.SetActive(true);
        guide.transform.localScale = initialScale;
        yield return new WaitForSeconds(delayTime);

        StartCoroutine(scalingGameObject(taegetGuideScalse));
    }
}
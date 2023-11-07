using System.Collections;
using UnityEngine;

public class FpsGunController : MonoBehaviour
{

    [SerializeField]
    Transform bulletSpawn = null;
    [SerializeField, Min(1)]
    int damage = 1;
    [SerializeField, Min(1)]
    int maxAmmo = 30;
    [SerializeField, Min(1)]
    float maxRange = 30;
    [SerializeField]
    LayerMask hitLayers = 0;
    [SerializeField, Min(0.01f)]
    float fireInterval = 0.1f;
    [SerializeField]
    ParticleSystem muzzleFlashParticle = null;
    [SerializeField]
    GameObject bulletHitEffectPrefab = null;
    [SerializeField]
    float resupplyInterval = 10;
    // [SerializeField]
    // Image ammoGauge = null;
    // [SerializeField]
    // Image resupplyGauge = null;

    [SerializeField]
    bool AutoReloadIsActive = true;
    [SerializeField]
    GameObject[] M4Magazine = new GameObject[5];

    public static bool isReloadCompleted = false;

    [SerializeField]
    bool fireTimerIsActive = false;
    RaycastHit hit;
    WaitForSeconds fireIntervalWait;

    int currentAmo = 0;
    bool resupplyTimerIsActive = false;

    public int CurrentAmo
    {
        set
        {
            currentAmo = Mathf.Clamp(value, 0, maxAmmo);

            // float scaleX = currentAmo / (float)maxAmmo;
            // ammoGauge.rectTransform.localScale = new Vector3(scaleX, 1, 1);
        }
        get
        {
            return currentAmo;
        }
    }

    void Start()
    {
        fireIntervalWait = new WaitForSeconds(fireInterval);  // WaitForSecondsをキャッシュしておく（高速化）

        CurrentAmo = maxAmmo;
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            Fire();
        }

        if(!resupplyTimerIsActive && (AutoReloadIsActive || ReloadController.isMagazineGrabbed))
        {
            StartCoroutine(nameof(ResupplyTimer));
        }

    }

  // 弾の発射処理
    void Fire()
    {
        Debug.Log(CurrentAmo);
        if (fireTimerIsActive || CurrentAmo <= 0 || ReloadController.isMagazineGrabbed || ReloadController.MagazineCounter == 6)
        {
            return;
        }

        muzzleFlashParticle.Play();
        isReloadCompleted = false;

        if(Physics.Raycast(bulletSpawn.position, bulletSpawn.forward, out hit, maxRange, hitLayers, QueryTriggerInteraction.Ignore))
        {
            BulletHit();
        }

        StartCoroutine(nameof(FireTimer));

        CurrentAmo--;
    }

    // 弾がヒットしたときの処理
    void BulletHit()
    {
        // テスト用
        Debug.Log("弾が「" + hit.collider.gameObject.name + "」にヒットしました。");

        Instantiate(bulletHitEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
        if (hit.collider.gameObject.CompareTag("asayu"))
        {
            AudioSource voice = hit.collider.gameObject.GetComponent<AudioSource>();
            voice.Play();
            // voice.enabled = false;
        }
    }

    // 弾を発射する間隔を制御するタイマー
    IEnumerator FireTimer()
    {
        fireTimerIsActive = true;

        yield return fireIntervalWait;

        fireTimerIsActive = false;
    }

    // 一定時間毎に弾薬を全回復するタイマー
    IEnumerator ResupplyTimer()
    {
        resupplyTimerIsActive = true;

        float timer = 0.0f;

        while(timer < resupplyInterval)
        {
            // resupplyGauge.rectTransform.localScale  = new Vector3(timer/resupplyInterval, 1, 1);
            timer += Time.deltaTime;

            yield return null;
        }

        CurrentAmo = maxAmmo;
        Debug.Log("Reloaded");
        ReloadController.MagazineCounter++;
        isReloadCompleted = true;

        resupplyTimerIsActive = false;
    }

    // 弾薬回復タイマーをキャンセルする処理
    public void StopResupplyTimer()
    {
        StopCoroutine(nameof(ResupplyTimer));
        resupplyTimerIsActive = false;
    }

}
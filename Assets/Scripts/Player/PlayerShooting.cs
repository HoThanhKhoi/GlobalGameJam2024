using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //Reference
    private Player player;

    public GameObject bulletPrefab;

    private float bulletFieldOfViewRange;
    private LineRenderer fieldOfViewRenderer;

    private float fireRate;
    private float canFire = 0f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        fieldOfViewRenderer = GetComponent<LineRenderer>();

        fireRate = player.stats.fireRate.GetValue();
        bulletFieldOfViewRange = player.stats.inaccuracy.GetValue();

        Debug.Log("Bullet acc: " + bulletFieldOfViewRange);

        player.stats.fireRate.OnValueChanged += FireRate_OnValueChanged;
        player.stats.inaccuracy.OnValueChanged += Inaccuracy_OnValueChanged;
    }

    private void Inaccuracy_OnValueChanged()
    {
        bulletFieldOfViewRange = player.stats.inaccuracy.GetValue();
    }

    private void FireRate_OnValueChanged()
    {
        fireRate = player.stats.fireRate.GetValue();
    }

    private void Update()
    {
        UpdateConeOfFire();

        if (Input.GetMouseButtonDown(0) && Time.time >= canFire)
        {
            Shoot();
            CameraShake.Instance.ShakeCamera();
        }
    }

    private void UpdateConeOfFire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        fieldOfViewRenderer.SetPosition(0, transform.position);
        fieldOfViewRenderer.SetPosition(1, transform.position + (mousePosition - transform.position).normalized * 30f);

        fieldOfViewRenderer.startWidth = 0.5f;
        fieldOfViewRenderer.endWidth = bulletFieldOfViewRange;

        Color lineColor = Color.black;
        lineColor.a = 0.25f;

        fieldOfViewRenderer.startColor = lineColor;
        fieldOfViewRenderer.endColor = lineColor;
    }

    private void Shoot()
    {
        AudioManager.Instance.Play("SniperSound");

        Vector3 shootDirection = (fieldOfViewRenderer.GetPosition(1) - fieldOfViewRenderer.GetPosition(0)).normalized;

        // Apply random inaccuracy
        float randomInaccuracy = Random.Range(-bulletFieldOfViewRange, bulletFieldOfViewRange);

        Quaternion bulletRotation = Quaternion.LookRotation(Vector3.forward, shootDirection) * Quaternion.Euler(0f, 0f, randomInaccuracy);
        canFire = Time.time + fireRate;

        Instantiate(bulletPrefab, transform.position, bulletRotation);
    }
}
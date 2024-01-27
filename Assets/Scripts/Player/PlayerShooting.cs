using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float bulletFieldOfViewRange = 5f;
    public LineRenderer fieldOfViewRenderer;

    [SerializeField] private float fireRate = 1f;
    private float canFire = 0f;

    private void Start()
    {
        fieldOfViewRenderer = GetComponent<LineRenderer>();
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

        float bulletInaccuracy = 4f;
        fieldOfViewRenderer.startWidth = 0.5f;
        fieldOfViewRenderer.endWidth = bulletInaccuracy;

        Color lineColor = Color.black;
        lineColor.a = 0.25f;

        fieldOfViewRenderer.startColor = lineColor;
        fieldOfViewRenderer.endColor = lineColor;
    }

    private void Shoot()
    {
        Vector3 shootDirection = (fieldOfViewRenderer.GetPosition(1) - fieldOfViewRenderer.GetPosition(0)).normalized;

        // Apply random inaccuracy
        float randomInaccuracy = Random.Range(-bulletFieldOfViewRange, bulletFieldOfViewRange);

        Quaternion bulletRotation = Quaternion.LookRotation(Vector3.forward, shootDirection) * Quaternion.Euler(0f, 0f, randomInaccuracy);
        canFire = Time.time + fireRate;

        Instantiate(bulletPrefab, transform.position, bulletRotation);
    }
}

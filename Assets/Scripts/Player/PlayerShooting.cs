using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletInaccuracy = 5f;
    public LineRenderer lineRenderer;

    [SerializeField] private float fireRate = 1f;
    private float canFire = 0f;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
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


        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + (mousePosition - transform.position).normalized * 30f);

        float bulletInaccuracy = 4f;
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = bulletInaccuracy;

        Color lineColor = Color.gray;
        lineColor.a = 0.25f;

        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
    }

    private void Shoot()
    {
        Vector3 shootDirection = (lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)).normalized;

        // Apply random inaccuracy
        float randomInaccuracy = Random.Range(-bulletInaccuracy, bulletInaccuracy);

        Quaternion bulletRotation = Quaternion.LookRotation(Vector3.forward, shootDirection) * Quaternion.Euler(0f, 0f, randomInaccuracy);
        canFire = Time.time + fireRate;

        if (IsHitEnemy(shootDirection))
        {
            lineRenderer.SetPosition(2, transform.position + shootDirection * Vector2.Distance(IsHitEnemy(shootDirection).transform.position, transform.position));
            IsHitEnemy(shootDirection).transform.GetComponent<Cat>().Hit();
        }
        // Instantiate(bulletPrefab, transform.position, bulletRotation);
    }

    private RaycastHit2D IsHitEnemy(Vector3 shootDirection)
    {
        return Physics2D.Raycast(transform.position, shootDirection, Mathf.Infinity, GameManager.Instance.enemyLayer);
    }
}

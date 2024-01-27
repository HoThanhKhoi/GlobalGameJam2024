// PlayerShooting.cs

using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletInaccuracy = 5f;
    public LineRenderer lineRenderer;

    [SerializeField] private float fireRate = 1f;
    private float canFire = 0f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        UpdateConeOfFire();

        if (Input.GetMouseButtonDown(0) && Time.time >= canFire)
        {
            Shoot();
        }
    }

    void UpdateConeOfFire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Set the positions of the line renderer to form a cone shape
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + (mousePosition - transform.position).normalized * 30f);

        // Set LineRenderer width to match bullet inaccuracy
        float bulletInaccuracy = 4f; // Replace with the actual variable or value
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = bulletInaccuracy;

        // Set LineRenderer material color
        Color lineColor = Color.gray; // Set to your desired color
        lineColor.a = 0.5f; // Set the alpha value for transparency
        lineRenderer.material.color = lineColor;
    }



    void Shoot()
    {
        // Calculate the direction from the player to the mouse position
        Vector3 shootDirection = (lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)).normalized;
        
        // Apply random inaccuracy
        float randomInaccuracy = Random.Range(-bulletInaccuracy, bulletInaccuracy);

        // Calculate bullet rotation using LookRotation
        Quaternion bulletRotation = Quaternion.LookRotation(Vector3.forward, shootDirection) * Quaternion.Euler(0f, 0f, randomInaccuracy);
        canFire = Time.time + fireRate;
        // Instantiate the bullet at the player's position with the calculated rotation
        Instantiate(bulletPrefab, transform.position, bulletRotation);
    }
}

using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletInaccuracy = 5f;
    public LineRenderer gunFieldOfView;
    public LineRenderer bulletLineRenderer;

    [SerializeField] private float fireRate = 1f;
    private float canFire = 0f;

    private void Start()
    {

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

        gunFieldOfView.SetPosition(0, transform.position);
        gunFieldOfView.SetPosition(1, transform.position + (mousePosition - transform.position).normalized * 30f);

        float bulletInaccuracy = 4f;
        gunFieldOfView.startWidth = 0.5f;
        gunFieldOfView.endWidth = bulletInaccuracy;

        Color lineColor = Color.black;
        lineColor.a = 0.25f;

        gunFieldOfView.startColor = lineColor;
        gunFieldOfView.endColor = lineColor;
    }

    private void Shoot()
    {
        Vector3 shootDirection = (gunFieldOfView.GetPosition(1) - gunFieldOfView.GetPosition(0)).normalized;

        Debug.Log(shootDirection);

        // Apply random inaccuracy
        float randomInaccuracy = Random.Range(-bulletInaccuracy, bulletInaccuracy);

        Quaternion bulletRotation = Quaternion.LookRotation(Vector3.forward, shootDirection) * Quaternion.Euler(0f, 0f, randomInaccuracy);
        canFire = Time.time + fireRate;

        //RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, shootDirection, Mathf.Infinity, 1 << GameManager.Instance.playerLayer);

        //if (hitInfo)
        //{
        //    Debug.Log(hitInfo.transform.name);
        //    Cat cat = hitInfo.transform.GetComponent<Cat>();
        //    if(cat != null)
        //    {
        //        cat.Hit();
        //    }

        //    bulletLineRenderer.SetPosition(0, transform.position);
        //    bulletLineRenderer.SetPosition(1, hitInfo.point);    
        //}
        //else
        //{
        //    bulletLineRenderer.SetPosition(0, transform.position);
        //    bulletLineRenderer.SetPosition(1, transform.position + shootDirection * 100f);
        //}

        //bulletLineRenderer.enabled = true;

         Instantiate(bulletPrefab, transform.position, bulletRotation);
    }
}

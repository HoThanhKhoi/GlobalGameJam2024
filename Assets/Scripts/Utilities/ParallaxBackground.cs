using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float startPosX;
    [SerializeField] private float endPosX;

    [SerializeField] private float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * moveSpeed;

        if(transform.position.x <= endPosX)
        {
            transform.position = new Vector3 (startPosX, transform.position.y, transform.position.z);   

        }
    }
}

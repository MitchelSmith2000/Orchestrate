using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothness;

    [SerializeField]
    float leftBoundary;
    [SerializeField]
    float rightBoundary;
    [SerializeField]
    float topBoundary;
    [SerializeField]
    float bottomBoundary;

    private void FixedUpdate()
    {
        Follow();

    }

    void Follow()
    {
        Vector3 targetLocation = target.position + offset;
        Vector3 easyTransition = Vector3.Lerp(transform.position, targetLocation, smoothness * Time.fixedDeltaTime);
        transform.position = easyTransition;

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftBoundary, rightBoundary),
            Mathf.Clamp(transform.position.y, bottomBoundary, topBoundary),
            transform.position.z
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

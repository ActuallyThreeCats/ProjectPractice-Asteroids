using UnityEngine;

public class Wrapper : MonoBehaviour
{
    [SerializeField] private Vector3 pos;
    [SerializeField] private float offset = 0.5f;
    private void Update()
    {
        pos = gameObject.transform.position;
    }
    void LateUpdate()
    {
        Vector3 bounds = Boundries.Instance.screenBounds;
        
        if (pos.x >= bounds.x + offset)
        {
            gameObject.transform.position = new Vector3(-bounds.x, pos.y);
        }
        if (pos.x <= -bounds.x - offset)
        {
            gameObject.transform.position = new Vector3(bounds.x, pos.y);
        }
        if (pos.y <= -bounds.y - offset)
        {
            gameObject.transform.position = new Vector3(pos.x, bounds.y);
        }
        if (pos.y >= bounds.y + offset)
        {
            gameObject.transform.position = new Vector3(pos.x, -bounds.y);
        }


    }
}

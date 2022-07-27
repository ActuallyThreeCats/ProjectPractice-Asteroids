using UnityEngine;

public class Boundries : MonoBehaviour
{
    public static Boundries Instance;
    public Vector2 screenBounds;
    [SerializeField] private Camera cam;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
    }
    private void Update()
    {
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
        

    }
   
}

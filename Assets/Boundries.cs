using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundries : MonoBehaviour
{
    public static Boundries Instance;
    public Vector2 screenBounds;
    [SerializeField] private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Debug.Log(screenBounds);
    }
    private void Update()
    {
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));

    }
    // Update is called once per frame

}

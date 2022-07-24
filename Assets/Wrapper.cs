using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {

        if (gameObject.transform.position.x >= Boundries.Instance.screenBounds.x + 0.5)
        {
            gameObject.transform.position = new Vector3(-Boundries.Instance.screenBounds.x, gameObject.transform.position.y);
        }
        if (gameObject.transform.position.x <= -Boundries.Instance.screenBounds.x - 0.5)
        {
            gameObject.transform.position = new Vector3(Boundries.Instance.screenBounds.x, gameObject.transform.position.y);
        }
        if (gameObject.transform.position.y <= -Boundries.Instance.screenBounds.y - 0.5)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, Boundries.Instance.screenBounds.y);
        }
        if (gameObject.transform.position.y >= Boundries.Instance.screenBounds.y + 0.5)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -Boundries.Instance.screenBounds.y);
        }


    }
}

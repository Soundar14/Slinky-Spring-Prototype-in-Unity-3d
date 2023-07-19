using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z + 50 < PlatformPoolManager.Instance.MainCamera.transform.position.z) 
        {
            Debug.Log("Behind the Cam.."+this.gameObject.name);
            PlatformPoolManager.Instance.ReturnPlatformToPool(this);
            PlatformPoolManager.Instance.spawnPlatform();
        }
    }
}

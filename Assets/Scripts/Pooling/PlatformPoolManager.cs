using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PlatformPoolManager : Singleton<PlatformPoolManager>
{
    public Platform platform;
    public ObjectPool<Platform> platformPool;

    public int initialPoolSize = 10;
    public Transform MainCamera;


    private float spawnZ =0;
    [SerializeField]
    private float platformLength = 50f;

   
    // Start is called before the first frame update
    void Start()
    {
        platformPool = new ObjectPool<Platform>(()=>
        {
          return  Instantiate(platform);
        },
        obj=> { obj.gameObject.SetActive(true); },
        obj => { obj.gameObject.SetActive(false); },
        obj => { Destroy(obj.gameObject); },
        false,initialPoolSize,initialPoolSize*2);


        spawnPlatform();
        spawnPlatform();
        spawnPlatform();
        spawnPlatform();
        spawnPlatform();
        spawnPlatform();
    }


    public Platform GetPlatformFromPool()
    {
        return platformPool.Get();
    }

    public void ReturnPlatformToPool(Platform obj)
    {
        platformPool.Release(obj);
    }

    

    public void spawnPlatform()
    {
        Platform pl = GetPlatformFromPool();
        pl.transform.position = new Vector3(0,-11,spawnZ);

        spawnZ += platformLength;

        if(spawnZ > 1200)
        {
            Time.timeScale = 0;
            SlinkyManager.Instance.LevelComplete();
        }
    }


}

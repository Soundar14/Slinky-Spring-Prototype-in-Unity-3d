using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
   

   

    [Header("Settings")]
    [SerializeField] private float speed = 50f;

    private MeshRenderer _renderer;

    [SerializeField] private float hue = 50f;

    [Space]
    [Header("Defaults")]
    [SerializeField] private float saturation = 50f;
    [SerializeField] private float value = 100f;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

        
        hue = Random.Range(1, 360);
        //_renderer.color = Color.HSVToRGB(hue / 360, saturation / 100, value / 100);
    }

    // Update is called once per frame
    void Update()
    {
        CycleLoopHue();

    }

    void CycleLoopHue()
    {

        hue += Time.deltaTime * speed;

        if (hue >= 360)
        {
            hue = 0;
        }
        SetColor(_renderer.material);
    }

    void SetColor(Material renderer)
    {
        renderer.color = Color.HSVToRGB(hue / 360, saturation / 100, value / 100);
    }
}

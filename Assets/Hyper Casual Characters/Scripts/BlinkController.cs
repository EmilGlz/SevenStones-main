using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlinkController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private float frequency = 2;
    [SerializeField]
    private bool multiBlinking = false;
    [SerializeField]
    private bool randomValues = false;
    private SkinnedMeshRenderer mesh;
    private float blinkProgress;
    private bool blink;

    void Start()
    {
        mesh = GetComponent<SkinnedMeshRenderer>();
        StartCoroutine(Blink());
        if (randomValues)
        {
            frequency = UnityEngine.Random.Range(1.5f, 2f);
            speed = UnityEngine.Random.Range(10f, 13f);
        }
    }

    void Update()
    {
        if (blink || blinkProgress > 1)
        {
            blinkProgress = Mathf.Clamp(100 * Mathf.Sin(Time.time * speed) + 100, -1, 100);
            mesh.SetBlendShapeWeight(0, blinkProgress);
            if (!multiBlinking)
                blink = false;
        }
    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(frequency);
        blink = true;
        blinkProgress = 100;
        if (multiBlinking)
        {
            yield return new WaitForSeconds(2);
            blink = false;
        }
        StartCoroutine(Blink());
    }
}

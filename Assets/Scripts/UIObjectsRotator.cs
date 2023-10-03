using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjectsRotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    Rigidbody rb;
    [SerializeField]bool dragging = false;

    [SerializeField] float lerpTime;
    [SerializeField] float timeAfterGoDefault;
    [SerializeField] Quaternion defaultRot;
    [SerializeField] bool mustRotateToDefault = false;

    float xInput;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultRot = transform.rotation;
    }

    private void OnMouseDrag()
    {
        mustRotateToDefault = false;
        dragging = true;
    }


    IEnumerator CheckTime(float afterTimeToGoDefault)
    {
        yield return new WaitForSeconds(afterTimeToGoDefault);
        if (!Input.GetMouseButton(0))
        {
            MakeDefault();
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        if (dragging)
        {
            xInput = Input.GetAxis("Mouse X");

            xInput *= rotationSpeed * Time.fixedDeltaTime;
            if (LocalDatas.Instance.canRotateObject)
            {
                transform.Rotate(Vector3.down * xInput, Space.Self); // 0   -1 * x   0

            }
        }
        else
        {
            //mustRotateToDefault = true;

            StartCoroutine( CheckTime(timeAfterGoDefault) );
        }

        if (mustRotateToDefault)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, defaultRot, Time.deltaTime * lerpTime);

            //if (transform.rotation == defaultRot)
            if ( Mathf.Abs(transform.rotation.x - defaultRot.x) <= 10f || Input.GetKeyDown(0))
            {
                mustRotateToDefault = false;
            }
        }
    }

    public void MakeDefault()
    {
        mustRotateToDefault = true;
    }

}

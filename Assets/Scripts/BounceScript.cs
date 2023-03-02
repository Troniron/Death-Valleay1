using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    [SerializeField]
    private float  roll=90,bounce=8f,Amblite=0.05f;
    private float timelap, starthight;

    private void Start()
    {
        starthight = transform.localPosition.y;
        timelap = Random.value * Mathf.PI * 2;
    }
    private void Update()
    {//Bounce
        float Height = starthight + Mathf.Sin(Time.time * bounce + timelap) * Amblite;
        var position = transform.localPosition;
        position.y = Height;
        transform.localPosition = position;
        //roll
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.y += roll * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
      //  transform.Rotate ( new Vector3(0, 45f, 0) *roll* Time.deltaTime);
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private Transform PlayerTransform;
    [SerializeField]
    private float _Mousespeed;
    private float _RotationX = 0f;
    [SerializeField]
    private Slider sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        _Mousespeed = PlayerPrefs.GetFloat("CurrentSensitivity",100f);
        Cursor.lockState = CursorLockMode.Locked;
        sensitivity.value = _Mousespeed / 10;
        //Sensitivity.Maxvalue(_Mousespeed);
       // _Mousespeed.ToString(Bgm.Instance.Mousensitivity.ToString());
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        PlayerPrefs.SetFloat("CurrentSensitivity", _Mousespeed);
        float _MouseX = Input.GetAxis("Mouse X") * _Mousespeed * Time.deltaTime;
        float _MouseY = Input.GetAxis("Mouse Y") * _Mousespeed * Time.deltaTime;
        
        _RotationX -= _MouseY;
        _RotationX = Mathf.Clamp(_RotationX, -90, 90);
        transform.localRotation = Quaternion.Euler(_RotationX, 0f, 0f);
        PlayerTransform.Rotate(Vector3.up * _MouseX);
       
        // _Mouseinputs = _Rotationspeed;
    }
    public void adjustspeed(float speed)
    {
        _Mousespeed = speed * 10;
    }
}

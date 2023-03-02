using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
   
    public static PlayerControll Controll;
    [SerializeField]
    private CharacterController _Controller;
    [SerializeField]
    private float _Speed, _Runspeed, _GravityModyfier,_Jumpower;
    private Vector3 _Moveinputs;
    [SerializeField]
    private LayerMask _Ground;
    [SerializeField]
    private Transform _Checkpoint,_Firepoint;
    private bool _Canjump,_Doublejump;
    private Vector2 _Mouseinputs;
    [SerializeField]
    private GameObject _Bullet;
    private float nextimetofire = 0f;
    [SerializeField]
    private float firerate = 30f;
    [SerializeField]
    private Transform cameraalt,Come1,Come2; 
    public bool Disabled = false;
    // [SerializeField]
    //  private GameObject impacteffect;
    // Start is called before the first frame update
    void Start()
    {
        // _Controller =this. GetComponent<CharacterController>();
        Accses();
    }

    void Accses()
    {
        if (Controll == null)
        {
            Controll = this;

        }
        else
        {
            Destroy(Controll);
        }

    }
    // Update is called once per frame
    void Update()
    {
        float Yinput = _Moveinputs.y;
        Vector3 Horizontal = transform.right * Input.GetAxis("Horizontal");
        Vector3 Vertical = transform.forward * Input.GetAxis("Vertical");
       
        _Moveinputs = Horizontal + Vertical;
        _Moveinputs.Normalize();
        _Moveinputs.y = Yinput;
        // playerlimit();
        //  playerlimit();
        if (!Disabled)
        {


            if (Input.GetMouseButtonDown(0) && Time.time >= nextimetofire)
            {
                Shoot();
                nextimetofire = Time.time + 1 / firerate;

            }
            else if (Input.GetMouseButton(0) && Time.time >= nextimetofire)
            {
                Shoot();
                nextimetofire = Time.time + 1 / 2f;
            }
           
            _Moveinputs.y += Physics.gravity.y * _GravityModyfier * Time.deltaTime;
            if (_Controller.isGrounded)
            {
                _Moveinputs.y = Physics.gravity.y * _GravityModyfier * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _Moveinputs = _Moveinputs * _Runspeed * Time.deltaTime;
            }
            else
            {
                _Moveinputs = _Moveinputs * _Speed * Time.deltaTime;
            }

            _Canjump = Physics.OverlapSphere(_Checkpoint.position, 0.25f, _Ground).Length > 0;
            Jump();
            _Controller.Move(_Moveinputs);

        }
       

      //  _Mouseinputs = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y") * _Mousespeed);

      //  transform.rotation = Quaternion.Euler(transform.rotation. eulerAngles.x, transform.rotation. eulerAngles.y+_Mouseinputs.x, transform.rotation. eulerAngles.z);
      //  _Camerapoint.rotation = Quaternion.Euler(_Camerapoint.rotation.eulerAngles + new Vector3(-_Mouseinputs.y, 0f, 0f));
        
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&_Canjump)
        {
            _Moveinputs.y = _Jumpower;
            _Doublejump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space)&& _Doublejump)
        {
            _Moveinputs.y = _Jumpower;
            _Doublejump = false;
           
        }
    }
  
 
    private void Shoot()
    {
        RaycastHit Hit;
        if(Physics.Raycast(cameraalt.transform.position,cameraalt.transform.forward,out Hit, 50f))
        {
            if (Vector3.Distance(cameraalt.position, Hit.point) > 2)
            {
                _Firepoint.LookAt(Hit.point);
            }
           
        }
        else
        {
            _Firepoint.LookAt(cameraalt.position + (cameraalt.forward * 30f));
        }
        Instantiate(_Bullet, _Firepoint.position, _Firepoint.rotation);
      // GameObject Effect= Instantiate(impacteffect, Hit.point, Quaternion.LookRotation(Hit.normal));
       // Destroy(Effect, 0.8f);
    }
    void playerlimit()
    {
        //R/x=37.54,z=21.61;
        //L/x=-3.5,z=21.61;
        if (transform.position.x== 37.54f)
        {
            transform.position =new Vector3(37.54f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x == -3.5f)
        {
            transform.position = new Vector3(-3.5f, transform.position.y, transform.position.z);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_Checkpoint.position, 0.25f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class _CharecterController : MonoBehaviour
{
    public static _CharecterController Instance;
    [SerializeField]
    private float speed,Nextfire,FireRate,_Runspeed;
    [SerializeField]
    private Transform checkpoint;
    [SerializeField]
    private LayerMask _Ground;
    bool isgrounded;
    [SerializeField]
    private float _Jumpspeed;
    [SerializeField]
    private int MaxHealth,ThroughSpeed;
  public  int CurrentHealth,Bombcount;
    [SerializeField]
    private CharacterController _PlayerCharecterController;
    [SerializeField]
    private float gravity = -9.81f, CheckRadious, Expotime;
    Vector3 AddPhysics;
    //  [SerializeField]
    //  private Transform Bombfirepoint;
    [SerializeField]
    private GameObject Finish, Loadtimer, Pause, Ammoeffect, Bomb;
  //  [SerializeField]
  //  private ParticleSystem _Muzzeleflash, _EjectCartridge;
 
   // [SerializeField]
   // private Animator _GunReload;
  //  bool isreload,hasexplode;
    [SerializeField]
    private _HealthBar Player_Health, Bullet_Reload;
    [SerializeField]
    private AudioSource Source;
    [SerializeField]
    private AudioClip _Finsh, _Collect;
    [SerializeField]
    private Animator _GunAnim;
    [SerializeField]
    GameObject Cross, Textforturret;
    bool textshow;
 //   private bool Ispaused = false;
    // Start is called before the first frame update
    void Start()
    {
        // CurrentAmmoo = Maxammo;
        
        CurrentHealth = MaxHealth;
        StartCoroutine(Timer());
     //  Player_Health.Maxvalue(MaxHealth);
      //  Bullet_Reload.Maxvalue(Maxammo);
        singleton();
      

    }
    void singleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }
    /*  private void OnEnable()
      {
          isreload = false;
          _GunReload.SetBool("Reload", false);
      }*/
    // Update is called once per frame
    void Update()
    {


        // Bountries();
        isgrounded = Physics.CheckSphere(checkpoint.position, CheckRadious, _Ground);

        if (isgrounded && AddPhysics.y <= 0)
        {
            AddPhysics.y = -2f;

        }
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        Vector3 Moveinput = transform.right * X + transform.forward * Z;

        Moveinput.Normalize();
        if (isgrounded && Input.GetKeyDown(KeyCode.Space))
        {
            AddPhysics.y = Mathf.Sqrt(gravity * -2f * _Jumpspeed);
        }
        if (X > 0 || X < 0 || Z > 0 || Z < 0)
        {
           
            _GunAnim.SetBool("Walk", true);

        }
        else if (X == 0 || Z == 0)
        {
           
            _GunAnim.SetBool("Walk", false);
            // _GunAnim.SetBool("Run", false);
        }


        /* if (isreload)
         {
             return;
         }
         if (CurrentAmmoo <= 1)
         {
             //  Reload();
             StartCoroutine(Reload());
            return;
         }*/
        /* if (Input.GetKeyDown(KeyCode.B)&&Time.time>=Nextfire)
         {
             bombexplode();
             Nextfire = Time.time + 2/ FireRate;

             //hasexplode = true;

         }*/
        //bool cursorlock;

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale==1)
            {
                paused();
                //Ispaused = false;
            }
            else
            {
                //  Ispaused = true;
                unpaused();

            }
            

        }
        /*
         void cursorlock()
        {
         cursorlock=true;
        Cursor.lockState = CursorLockMode.Locked;
        
        }

         */

        /*  if (Input.GetButton("Fire1")&&Time.time>=Nextfire)
          {
              Source.clip = _Fire;
              Source.Play();
              _Muzzeleflash.Play();
              _EjectCartridge.Play();
            //  Shoot();

              Nextfire = Time.time + 1 / FireRate;
          }*/
        /* if (Input.GetKey(KeyCode.LeftShift))
         {
            // _GunAnim.SetBool("Run",true);
            // _GunAnim.SetBool("Walk", true);
             Moveinput = Moveinput * _Runspeed * Time.deltaTime;
         }
         else
         {
           //  _GunAnim.SetBool("Run", false);
            // _GunAnim.SetBool("Walk", true);
             Moveinput = Moveinput * speed * Time.deltaTime;
         }*/
        _PlayerCharecterController.Move(Moveinput*speed*Time.deltaTime);

        AddPhysics.y += gravity * Time.deltaTime;

       _PlayerCharecterController.Move(AddPhysics * Time.deltaTime);
     


    }
    void paused()
    {

        // Ispaused = false;
       Time.timeScale = 0f;
        Cross.SetActive(false);
        this.GetComponent<Cutscene>().enabled = false;
      //  GameObject.Find("Cross_Hair").SetActive(false);
            Pause.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            

       
        
    }
    void unpaused()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cross.SetActive(true);
        this.GetComponent<Cutscene>().enabled = true;
        //  GameObject.Find("Cross_Hair").SetActive(true);
        Pause.SetActive(false);
       
    }
   /* IEnumerator Reload()
    {
        isreload =true;
        Debug.Log("Is reloading");
       _GunReload.SetBool("Reload", true);
        RealodingTxtMore.SetActive(true);
        yield return new WaitForSeconds(1f);
        CurrentAmmoo = Maxammo;
        Bullet_Reload.Maxvalue(Maxammo);
        _GunReload.SetBool("Reload", false);
        RealodingTxtMore.SetActive(false);
        isreload = false;
    }*/
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(4.7f);
        Loadtimer.SetActive(false);

    }
   
  /*  void Shoot()
    {
        RaycastHit Hit;
        CurrentAmmoo--;
       
        if(Physics.Raycast(_camera.position, _camera.forward,out Hit, 100f))
        {
            if (Vector3.Distance(_camera.position, Hit.point) > 1)
            {
                FirePoint.LookAt(Hit.point);
            }
        }
        else
        {
            FirePoint.LookAt(_camera.position + (_camera.forward * 30f));
        }
        Bullet_Reload.Value(CurrentAmmoo);
        Instantiate(_Bullet, FirePoint.position, FirePoint.rotation);

    }
   */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon"&&Three_D_Enemy.increase==5)
        {
           
            GameObject.Find("Cross_Hair").SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Source.clip = _Finsh;
            Source.Play();
           // Pause.SetActive(false);
            Finish.SetActive(true);
            this.GetComponent<Cutscene>().enabled = false;
            this.GetComponentInChildren<Guns>().enabled = false;
            Time.timeScale = 0f;
        }
        if (Three_D_Enemy.increase <5 && other.gameObject.tag == "Weapon")
        {
            StartCoroutine(texttime());
            Debug.Log("Destroy all the enemies");

        }
        if (other.gameObject.tag == "Ammo")
        {
            Source.clip = _Collect;
            Source.Play();
           Guns.Maxammo += 10;
            GameObject bulletef = Instantiate(Ammoeffect,other.transform.position, other.transform.rotation);
            Destroy(bulletef, 0.5f);
            Destroy(other.gameObject);
            
        }
        if (other.gameObject.tag == "Grenade")
        {
            Source.clip = _Collect;
            Source.Play();
            Bombcount++;
            Destroy(other.gameObject);

        }
    }
   IEnumerator texttime()
    {
       // textshow = true;
        Textforturret.SetActive(true);
        yield return new WaitForSeconds(2f);
        Textforturret.SetActive(false);
    }
    void bombexplode()
    {
      //  Bombscount--;

      //  GameObject _Bombalpha=Instantiate(Bomb, Bombfirepoint.position, Bombfirepoint.rotation);
     //   _Bombalpha.GetComponent<Rigidbody>().AddForce(Bombfirepoint.forward * ThroughSpeed);

       // Destroy(_Bombalpha, 3f);



    }
   
}

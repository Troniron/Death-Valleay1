using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three_D_Enemy : MonoBehaviour
{
    [SerializeField]
    private float _Distance, ClosingRange;
    [SerializeField]
    private GameObject _GunIdle,_GunFire,Heart;
    [SerializeField]
    Eguns Egun_;
    private Animator _EAnim;
    private int Maxhealth=100;
    [SerializeField]
    private int CurrentHealth;
    AudioSource _sourse;
    [SerializeField]
    private AudioClip _Hitbody;
  //  [SerializeField]
  //  private ParticleSystem _Muzzle;
    //  GameObject Healthbar;
    public static int increase;
    // Start is called before the first frame update
    void Start()
    {
        _sourse = GetComponent<AudioSource>();
        CurrentHealth = Maxhealth;
        
        //   this. GetComponentInChildren<_HealthBar>().Maxvalue(Maxhealth);

        // GameObject Health = GameObject.Find("SliderEnemy");
        //   Health.GetComponent<_HealthBar>().Maxvalue(Maxhealth);

        _EAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
      


        _Distance = Vector3.Distance(_CharecterController.Instance.transform.position, transform.position);

        if (_Distance <= ClosingRange)
        {
             _GunIdle.SetActive(false);
             _GunFire.SetActive(true);
         //   Egun_.enabled = true;
            // _EAnim.SetBool("Fire", true);
            lookrotation();
        }
        else
        {
           // Egun_.enabled = false;
            _GunIdle.SetActive(true);
            _GunFire.SetActive(false);

        }
           /* if(Time.time>= DefaultTimer)
            {
               shoot();
                DefaultTimer = Time.time + 1 / FirePerSec;
            }
            _HeavyGun.LookAt(_CharecterController.Instance.transform.position);
        }
        else
        {
            _GunIdle.SetActive(true);
            _GunFire.SetActive(false);
            _EAnim.SetBool("Fire", false);
        }*/
        if (PlayerHealth.CurrentHealth <= 0)
        {
            // _pause.SetActive(false);
            _EAnim.SetBool("Fire", false);
            this.enabled = false;
           
            Cursor.lockState = CursorLockMode.None;
        }
        if (CurrentHealth <= 0)
        {
            increase++;
            Heart.SetActive(true);
            _EAnim.SetBool("Die", true);
            _GunIdle.SetActive(false);
            _GunFire.SetActive(false);
            GetComponent<CapsuleCollider>().direction = 0;

          
            // this.GetComponentInChildren<Canvas>().enabled = false;
            GetComponent<CapsuleCollider>().center = (new Vector3(0, 0.22f, 0));
            GetComponent<Three_D_Enemy>().enabled = false;
            Debug.Log("Destroy");
        }


    }
   
  
   public   void Tackdamage(int Damage)
    {
        CurrentHealth -= Damage;
       // GameObject Health = GameObject.Find("SliderEnemy");
       // Health.GetComponent<_HealthBar>().Value(CurrentHealth);
    //  this.GetComponentInChildren<_HealthBar>().Value(CurrentHealth);
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _sourse.clip = _Hitbody;
            _sourse.Play();
            Tackdamage(20);
            ClosingRange = 20;
            Egun_.ClosingRange = 20;

        }
    }
    void lookrotation()
    {
        Vector3 direction = (_CharecterController.Instance.transform.position - transform.position).normalized;
        Quaternion lookrotate = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotate, Time.deltaTime * 5f);
    }
}

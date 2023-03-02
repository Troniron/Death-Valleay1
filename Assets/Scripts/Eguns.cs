using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eguns : MonoBehaviour
{

    [SerializeField]
    GameObject _ESwatbullet;
    [SerializeField]
    AudioSource _sourse;
    [SerializeField]
    AudioClip _Efire;
    [SerializeField]
    ParticleSystem _Muzzle;
    [SerializeField]
    Transform _Firepoint, _HeavyGun;
    [SerializeField]
    int _BulletSpeed, CurrentHealth;
    [SerializeField]
    float DefaultTimer, _Distance, FirePerSec;
    public  int ClosingRange;
    [SerializeField]
    Animator _EAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {



        _Distance = Vector3.Distance(_CharecterController.Instance.transform.position, transform.position);

        if (_Distance <= ClosingRange)
        {
            
            _EAnim.SetBool("Fire", true);
           
            if (Time.time >= DefaultTimer)
            {
                shoot();
                DefaultTimer = Time.time + 1 / FirePerSec;
            }
            _HeavyGun.LookAt(_CharecterController.Instance.transform.position);
        }
        else
        {
           
            _EAnim.SetBool("Fire", false);
        }
        if (PlayerHealth.CurrentHealth <= 0)
        {
            // _pause.SetActive(false);
            this.enabled = false;
           // _EAnim.SetBool("Fire", false);
           // Cursor.lockState = CursorLockMode.None;
        }
      /*  if (CurrentHealth <= 0)
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
        }*/


    }
   
    void shoot()
    {
        _sourse.clip = _Efire;
        _sourse.Play();
        _Muzzle.Play();
        GameObject Clones = Instantiate(_ESwatbullet, _Firepoint.position, _Firepoint.rotation);
        Clones.GetComponent<Rigidbody>().AddForce(_Firepoint.forward * _BulletSpeed);
        Destroy(Clones, 5f);

    }
   /* public void Tackdamage(int Damage)
    {
        CurrentHealth -= Damage;
        // GameObject Health = GameObject.Find("SliderEnemy");
        // Health.GetComponent<_HealthBar>().Value(CurrentHealth);
        //  this.GetComponentInChildren<_HealthBar>().Value(CurrentHealth);

    }*/
}

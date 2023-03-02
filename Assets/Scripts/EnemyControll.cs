using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyControll : MonoBehaviour
{
    //[SerializeField]
    // float _ChasingSpeed=10f, _StopingSpeed=15f;
   // private Rigidbody RB;
    [SerializeField]
    private GameObject _Ebullet, Healthbox;
    [SerializeField]
    private Transform _FirePoint;
  //  private bool _Chasing,_Fire;
   // private NavMeshAgent _Navmeshagent;
    [SerializeField]
    private Animator _Anim;
    [SerializeField]
    private Transform TurretHead;
    [SerializeField]
    private float Nextfire, FireRate,Distance,ClosingRange;
    [SerializeField]
    private int _CurrentHealth;
    int Maxhealth=100;
    [SerializeField]
    private GameObject _Expo;
 //  [SerializeField]
 //   private _HealthBar HealthForenemy;
    [SerializeField]
    private ParticleSystem _Flash;
    [SerializeField]
    private GameObject Boxes;
    [SerializeField]
    private AudioClip _Mishineb,_Hitbodyim,Expo;
    [SerializeField]
    private AudioSource _Sourse,_Sourse2;

    
    
    // Start is called before the first frame update
    void Start()
    {
        _CurrentHealth = Maxhealth;
     
       // this.GetComponentInChildren<_HealthBar>().Maxvalue(Maxhealth);
      //  HealthForenemy.Maxvalue(Maxhealth);
       // RB = GetComponent<Rigidbody>();
       // _Navmeshagent = GetComponent<NavMeshAgent>();
      //  _Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(_CharecterController.Instance.transform.position, transform.position);
        if(Distance<= ClosingRange)
        {
            if (Time.time >= Nextfire)
            {
                _Flash.Play();
                   Nextfire = Time.time + 1 / FireRate;
                
                StartCoroutine("Shoot");

            }
            TurretHead.LookAt(_CharecterController.Instance.transform.position);
        }

        if (_CurrentHealth <= 0)
        {
              _Sourse2.clip = Expo;
            _Sourse2.Play();
           //  _Sourse.Play();
            // GetComponent<EnemyControll>().enabled = false;
            this.enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Healthbox.SetActive(true);
            _Flash.Stop();
            //_Flash.startSize = 0.5f;
            _Expo.SetActive(true);
            Destroy(_Expo, 1.5f);
            StopAllCoroutines();
            _Anim.SetBool("Die", true);
            //  Boxes.GetComponent<Animator>().SetTrigger("Move");
            Boxes.GetComponent<BoxCollider>().enabled = false;
            // _Container.SetTrigger("Move");


        }

        /*  if (!_Chasing)
          {

              if (Vector3.Distance(transform.position, _CharecterController.Instance.transform.position) < _ChasingSpeed)
              {

                  _Chasing = true;
                  if (Time.time >= Nextfire)
                  {
                      Nextfire = Time.time + 1 / FireRate;
                      Shoot();

                  }
                //  StartCoroutine(Spawn());
               //   Instantiate(_Ebullet, transform.position, Quaternion.identity);
              }
          }
          else
          {


              TurretHead.LookAt(_CharecterController.Instance.transform.position);

              if (Vector3.Distance(transform.position, _CharecterController.Instance.transform.position) > _StopingSpeed)
              {

                  //   _Fire = true;
                  //  _Anim.SetBool("Stop", false);
                  _Chasing = false;
              }

          }*/
        //  navmeshagent();

    }
  IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);
        _Sourse.clip = _Mishineb;
        _Sourse.Play();
        GameObject Clone = Instantiate(_Ebullet, _FirePoint.position, _FirePoint.rotation);
        Clone.GetComponent<Rigidbody>().AddForce(_FirePoint.forward * 1000);

        Destroy(Clone, 5f);
    }
    private void Enaple()
    {
        this.enabled = true;
    }

  /*  private void Shoot()
    {
        
        GameObject Clone=   Instantiate(_Ebullet, _FirePoint.position, _FirePoint.rotation);
        Clone.GetComponent<Rigidbody>().AddForce(_FirePoint.forward * 1500);
        Destroy(Clone, 5f);
    }*/
 public void TackDamage(int damage)
    {
        _CurrentHealth -= damage;

       
        // this.GetComponentInChildren<_HealthBar>().Value(_CurrentHealth);
        //  HealthForenemy.Value(_CurrentHealth);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Bullet")
        {
            _Sourse.clip = _Hitbodyim;
            _Sourse.Play();
            TackDamage(20);
            ClosingRange = 15;
            Destroy(collision.gameObject);
        }
       
    }
  
  /*  private void navmeshagent()
    {
        if (_Navmeshagent.remainingDistance <= _Navmeshagent.stoppingDistance)
        {
            //Ai path not set
            if (!_Navmeshagent.hasPath || _Navmeshagent.velocity.sqrMagnitude == 0f)
            {
              //  Pistol1.SetActive(false);
               // Pistol2.SetActive(true);
                // transform.LookAt(NormalController.PlayerInstance.transform.position);
                //   transform.LookAt(Moveobgect.position);
                // GameObject Scratch1 = Instantiate(_Scratch, _Scratchposition.transform.position, _Scratchposition.transform.rotation);
                //   Destroy(Scratch1);
                //  StartCoroutine(Spawn());
                _Anim.SetBool("Stop", false);
                _Anim.SetBool("Attack", true);
            }
            else
            {
                //   spawn = true;
                _Anim.SetBool("Stop", false);
            }
        }
        //Zombie when he not reach the stop area it will attack false
        else
        {
            // spawn = true;
           // Pistol1.SetActive(true);
          //  Pistol2.SetActive(false);
            _Anim.SetBool("Attack", false);
            _Anim.SetBool("Stop", true);
        }
    }*/

}

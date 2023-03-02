using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Bullet : MonoBehaviour
{[SerializeField]
    private Rigidbody Rb;
    [SerializeField]
    private float _Bulletspeed,_Lifetime;
    [SerializeField]
    private GameObject _Sand, _Blood, Metal, _Woods,_Stone;
   // [SerializeField]
   // private AudioSource Source;
  //  [SerializeField]
 //   private AudioClip _Hitbody,_Hitsand,_HitMetel;
   // [SerializeField]
  //  private GameObject _Blood;
  //  [SerializeField]
 //   private GameObject _ImpactEffectFire,_WaterImpact,_GreenImpact;
     
    // Start is called before the first frame update
    void Start()
    {
        //Rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _Lifetime -= Time.deltaTime;

        if (_Lifetime <=0)
        {
            Destroy(gameObject);
        }
        Rb.velocity = transform.forward * _Bulletspeed;


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Metal")
        {
          
            GameObject MetalG;
            MetalG=Instantiate(Metal, transform.position, transform.rotation);
            Destroy(MetalG, 1f);
         
            Destroy(this.gameObject,0.05f);
        //    GameObject Blood= Instantiate(_Blood, transform.position, Quaternion.identity);
          // Destroy(Blood, 2f);
        }
        if (collision.gameObject.tag=="Sand")
        {
        //   Source.clip = _Hitsand;
        //    Source.Play();
            GameObject Sands;
            Sands = Instantiate(_Sand, transform.position, transform.rotation);
            Destroy(Sands, 1f);
            Destroy(this.gameObject,5f);
        }
        if (collision.gameObject.tag == "Wood")
        {
            GameObject Woods;
            Woods = Instantiate(_Woods, transform.position, transform.rotation);
            Destroy(Woods, 1f);
            Destroy(this.gameObject, 0.05f);

        }
        if(collision.gameObject.tag== "Stone")
        {
            GameObject Stone;
            Stone = Instantiate(_Stone, transform.position, transform.rotation);
            Destroy(Stone, 1f);
            Destroy(this.gameObject, 0.05f);
        }
        if (collision.gameObject.tag == "Enemy")
        {
           /// Source.clip = _Hitbody;
         //   Source.Play();
            GameObject Blood;
            Blood = Instantiate(_Blood, transform.position, transform.rotation);
            Destroy(Blood, 1f);
            Destroy(this.gameObject, 0.05f);

        }
        if (collision.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}

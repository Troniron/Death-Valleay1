using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{

    [SerializeField]
    private int max;
    [SerializeField]
    private float Distance, closingrang;
    int current;
    [SerializeField]
    GameObject Expo,Destroyer,fullbarrel;
    PlayerHealth healthfromplayer;
   [SerializeField] Three_D_Enemy enemy;
    [SerializeField]
    private AudioSource _Source;
    [SerializeField]
    private AudioClip _Expo,_Hitbarrel;
    // Start is called before the first frame update
    void Start()
    {
        current = max;
        healthfromplayer = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
       Distance = Vector3.Distance(_CharecterController.Instance.transform.position,transform.position);
        if (current <= 0)
        {
            enemy.Tackdamage(60);
            _Source.clip = _Expo;
            _Source.Play();
            Destroyer.SetActive(true);
            this.enabled = false;
            fullbarrel.SetActive(false);
            Expo.SetActive(true);
            Destroy(Expo, 0.5f);
        }
         if(current<=0 && Distance <= closingrang)
        {
            healthfromplayer.PlayerDamage(10);
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _Source.clip = _Hitbarrel;
            _Source.Play();
            current--;
        }
    }
    private void damage()
    {

    }
}

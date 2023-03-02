using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int CurrentHealth;
    [SerializeField]
    private _HealthBar Playerh;
    [SerializeField]
    private int Maxhealth;
    [SerializeField]
   
    private AudioSource _Source;
    [SerializeField]
    private AudioClip _Gameover,_Collect;
    [SerializeField]
    private Transform _BloodArea;
    [SerializeField]
    private GameObject Gameover, Health, Blood, cursor, heart, Pause;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = Maxhealth;
        Playerh.Maxvalue(Maxhealth);
    }
  public  void PlayerDamage(int Damage)
    {
        CurrentHealth -= Damage;
        Playerh.Value(CurrentHealth);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ebullet")
        {
            PlayerDamage(5);
            Destroy(other.gameObject,0.5f);
        GameObject EBlood = Instantiate(Blood, _BloodArea.position, _BloodArea.rotation);
         Destroy(EBlood, 1f);
           // Destroy(this.gameObject, 0.05f);

        }
        
        if (other.gameObject.tag == "Destroyer")
        {
            PlayerDamage(100);
            
        }
        if (other.gameObject.tag == "Health")
        {
            _Source.clip = _Collect;
            _Source.Play();
            CurrentHealth += 10;
            Playerh.Value(CurrentHealth);
          GameObject hearts=  Instantiate(heart, other.transform.position, other.transform.rotation);
            Destroy(hearts, 0.8f);
            Destroy(other.gameObject);
        }

      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ebullet")
        {
            PlayerDamage(5);
            Destroy(collision.gameObject, 0.5f);
            GameObject EBlood = Instantiate(Blood, _BloodArea.position, _BloodArea.rotation);
            Destroy(EBlood, 1f);
            // Destroy(this.gameObject, 0.05f);

        }
        if (collision.gameObject.tag =="Tag")
        {
          ///  Textforturret.SetActive(true);

        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            _Source.clip = _Gameover;
            _Source.Play();
            Gameover.SetActive(true);
            this.GetComponent<Cutscene>().enabled = false;
            GameObject.Find("Falseall").SetActive(false);
            Pause.SetActive(false);
            cursor.SetActive(false);
            this.enabled = false;
           // Bdag.SetActive(true);
            Health.SetActive(false);
          //  Reload.SetActive(false);
            GetComponent<_CharecterController>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponentInChildren<Guns>().enabled = false;
            GameObject.Find("UiGaManager").GetComponent<UiManager>().enabled = false;
           GameObject.Find("Turret").GetComponent<EnemyControll>().enabled = false;
           GameObject.Find("Turret 2").GetComponent<EnemyControll>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
          //  FindObjectOfType<EnemyControll>().enabled = false;
           // FindObjectOfType<EnemyControll>().enabled = false;
           
        }
    }
}

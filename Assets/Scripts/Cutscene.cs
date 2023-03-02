using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField]
    private GameObject MainCam,Cutscenecam,PlayerBody,Buttonforclose,Cursor;
    private bool turret;
    [SerializeField]
    private Animator _Cutcam,Gate;
    [SerializeField]
    private AudioClip _Irongate;
    [SerializeField]
    private AudioSource _Sourse;
    [SerializeField]
    private GameObject[] enemys=new GameObject[4];
   
   // [SerializeField]
   // EnemyControll _Turret1, _Turret2;
   
    
    // Start is called before the first frame update
    void Start()
    {
       
        Invoke("Spawnturret",0.5f);
        Invoke("cursorpoint", 7f);
       // Invoke("enable", 7f);
       // StartCoroutine(scene());
    }
  void enable()
    {
        //_Turret1.enabled = true;
    //   _Turret2.enabled = true;
    }
    void Spawnturret()
    {
        StartCoroutine("Turret");
        

    }
    void cursorpoint()
    {
        Cursor.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

       
       
         if (Input.GetKeyDown(KeyCode.Tab))
        {
          //  enable();
            MainCam.SetActive(true);
            Cursor.SetActive(true);
            Cutscenecam.SetActive(false);
            PlayerBody.SetActive(true);
            GetComponent<_CharecterController>().enabled = true;
            GetComponent<CharacterController>().enabled = true;
            Buttonforclose.SetActive(false);
            enemytrue();
            StopAllCoroutines();
        }
    }
    
    IEnumerator scene()
    {
        yield return new WaitForSeconds(60f);
        MainCam.SetActive(true);
        Cutscenecam.SetActive(false);
    }
   IEnumerator Turret()
    {
        // turret = true;
        Buttonforclose.SetActive(true);
        Cursor.SetActive(false);
        MainCam.SetActive(false);
        Cutscenecam.SetActive(true);
        PlayerBody.SetActive(false);
        GetComponent<_CharecterController>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        enemyfalse();
    
        _Cutcam.SetBool("Turret", true);
       
        yield return new WaitForSeconds(7f);
       enemytrue();

        MainCam.SetActive(true);
        Cutscenecam.SetActive(false);
        Cursor.SetActive(true);
        PlayerBody.SetActive(true);
        Buttonforclose.SetActive(false);
        GetComponent<_CharecterController>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
        _Cutcam.SetBool("Turret", false);
        //   turret = false;
    }
    IEnumerator Outpost()
    {
        // turret = true;
        MainCam.SetActive(false);
        Cutscenecam.SetActive(true);
        Cursor.SetActive(false);
        PlayerBody.SetActive(false);
        Buttonforclose.SetActive(true);
        GetComponent<_CharecterController>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        enemyfalse();
        _Cutcam.SetBool("Outpost", true);
        yield return new WaitForSeconds(12f);
        enemytrue();
        MainCam.SetActive(true);
        Cutscenecam.SetActive(false);
        Cursor.SetActive(true);
        PlayerBody.SetActive(true);
        Buttonforclose.SetActive(false);
        GetComponent<_CharecterController>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
        _Cutcam.SetBool("Outpost", false);
        //   turret = false;
    }
    IEnumerator Soldier()
    {
        // turret = true;
        MainCam.SetActive(false);
        Cutscenecam.SetActive(true);
        PlayerBody.SetActive(false);
        Cursor.SetActive(false);
        Buttonforclose.SetActive(true);
        GetComponent<_CharecterController>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        _Cutcam.SetBool("Soldier", true);
        enemyfalse();
        yield return new WaitForSeconds(10f);
        enemytrue();
        MainCam.SetActive(true);
        Cursor.SetActive(true);
        Cutscenecam.SetActive(false);
        PlayerBody.SetActive(true);
        Buttonforclose.SetActive(false);
        GetComponent<_CharecterController>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
        _Cutcam.SetBool("Soldier", false);
        //   turret = false;
    }
    IEnumerator Launcher()
    {
        // turret = true;
        MainCam.SetActive(false);
        Cutscenecam.SetActive(true);
        Cursor.SetActive(false);
        PlayerBody.SetActive(false);
        Buttonforclose.SetActive(true);
        GetComponent<_CharecterController>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        _Cutcam.SetBool("Launcher", true);
       enemyfalse();
        yield return new WaitForSeconds(4f);
        enemytrue();
        MainCam.SetActive(true);
        Cutscenecam.SetActive(false);
        Cursor.SetActive(true);
        PlayerBody.SetActive(true);
        Buttonforclose.SetActive(false);
        GetComponent<_CharecterController>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
        _Cutcam.SetBool("Launcher", false);
        //   turret = false;
    }
    private void OnTriggerEnter(Collider other)
    {
      /*  if (other.gameObject.tag == "Turret")
        {
            Destroy(other.gameObject);
            StartCoroutine(Turret());
          //  return;
           
        }*/
        if (other.gameObject.tag == "OutPost")
        {
            Destroy(other.gameObject);
            StartCoroutine("Outpost");
           
        }
        if (other.gameObject.tag == "open")
        {
           Gate.SetTrigger("Open");
            _Sourse.clip = _Irongate;
            _Sourse.Play();
        }
      
        if (other.gameObject.tag == "Soldier")
        {
            Destroy(other.gameObject);
            StartCoroutine("Soldier");

        }
        if (other.gameObject.tag == "Launcher")
        {
            Destroy(other.gameObject);
            StartCoroutine("Launcher");

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Turret")
        {
            Destroy(collision.gameObject);
           // StartCoroutine(Turret());
            //  return;

        }
    }
    private void enemyfalse()
    {
        enemys[0].GetComponent<Eguns>().enabled = 
        enemys[1].GetComponent<Eguns>().enabled = 
        enemys[2].GetComponent<Eguns>().enabled = 
        enemys[3].GetComponent<Eguns>().enabled = 
        enemys[4].GetComponent<Eguns>().enabled = false;
      
    }
    private void enemytrue()
    {
        enemys[0].GetComponent<Eguns>().enabled = 
        enemys[1].GetComponent<Eguns>().enabled = 
        enemys[2].GetComponent<Eguns>().enabled = 
        enemys[3].GetComponent<Eguns>().enabled = 
        enemys[4].GetComponent<Eguns>().enabled = true;
    }
}

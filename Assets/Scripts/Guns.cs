using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns: MonoBehaviour
{
    [SerializeField]
    private Transform _camera, FirePoint;
    public static int CurrentAmmoo,Maxammo=10;
        [SerializeField]
    private GameObject _Bullet, RealodingTxtMore;
    [SerializeField]
    private float Nextfire, FireRate;
    [SerializeField]
    private AudioClip _Fire,_Reload;
    [SerializeField]
    private AudioSource Source;
    [SerializeField]
    private ParticleSystem _Muzzeleflash, _EjectCartridge;
    [SerializeField]
    private Animator _GunAnim;
    private bool isreload;
    // Start is called before the first frame update
    void Start()
    {
        CurrentAmmoo = Maxammo;
    }
    private void OnEnable()
    {
        isreload = false;
        _GunAnim.SetBool("Reload", false);
    }
    // Update is called once per frame
    void Update()
    {
     if(PlayerHealth.CurrentHealth == 0)
        {
            this.enabled = false;
        }
        if (isreload)
        {
            return;
        }
        if (CurrentAmmoo <= 1)
        {
           //   Reload();
           StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= Nextfire)
        {
            Source.clip = _Fire;
            Source.Play();
            _Muzzeleflash.Play();
            _EjectCartridge.Play();
              Shoot();
           
            Nextfire = Time.time + 1 / FireRate;
        }
       
    }
    void Shoot()
    {
        RaycastHit Hit;
        CurrentAmmoo--;

        if (Physics.Raycast(_camera.position, _camera.forward, out Hit, 100f))
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
        _GunAnim.SetTrigger("Fire");
        // Bullet_Reload.Value(CurrentAmmoo);
        Instantiate(_Bullet, FirePoint.position, FirePoint.rotation);

    }
    IEnumerator Reload()
    {
        isreload = true;
        Debug.Log("Is reloading");
        _GunAnim.SetBool("Reload", true);
       
        this.enabled = false;
        Invoke("delayaudio", 0.5f);
        /// RealodingTxtMore.SetActive(true);
        yield return new WaitForSeconds(3f);
        CurrentAmmoo = Maxammo;
        this.enabled = true;
      
        //  Bullet_Reload.Maxvalue(Maxammo);
        _GunAnim.SetBool("Reload", false);
      ///  RealodingTxtMore.SetActive(false);
        isreload = false;
    }
    void delayaudio()
    {
        Source.clip = _Reload;
        Source.Play();
    }
}

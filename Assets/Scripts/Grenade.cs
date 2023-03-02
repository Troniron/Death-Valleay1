using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private float Expotime;
    [SerializeField]
    private GameObject ExplodeEfect;
    [SerializeField]
    float ratious, force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Expotime -= Time.deltaTime;

     

        if (Expotime <= 0)
        {
            explode();
        }
        
    }
    void explode()
    {
    GameObject efect= Instantiate(ExplodeEfect, transform.position, transform.rotation);

        Collider[] collaider = Physics.OverlapSphere(transform.position, ratious);

        foreach (Collider cloaseobg in collaider)
        {
            Rigidbody rb = cloaseobg.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position,ratious);
            }
        /*    EnemyControll health =cloaseobg.GetComponent<EnemyControll>();
            if (health != null)
            {
                health.TackDamage(50);
            }*/
        }
        Debug.Log("explaode done");
        Destroy(efect, 0.5f);
        Destroy(this.gameObject);
        

    }
}

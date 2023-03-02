
using UnityEngine;

public class Granadethrough : MonoBehaviour
{
    [SerializeField]
    private float Nextfire, FireRate, ThroughSpeed;
    [SerializeField]
    private GameObject Bomb;
    public static int Bombscount=99;
    [SerializeField]
    private Transform Bombfirepoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= Nextfire)
        {
            bombexplode();
            Nextfire = Time.time + 2 / FireRate;

            //hasexplode = true;

        }
       

    }
    void bombexplode()
    {
        Bombscount--;

        GameObject _Bombalpha = Instantiate(Bomb, Bombfirepoint.position, Bombfirepoint.rotation);
        _Bombalpha.GetComponent<Rigidbody>().AddForce(Bombfirepoint.forward * ThroughSpeed);

        // Destroy(_Bombalpha, 3f);



    }
}

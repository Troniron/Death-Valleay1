using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ebullet : MonoBehaviour
{
   
    [SerializeField]
    private GameObject _Blood;
 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider collision)
    {

        /* if (collision.gameObject.tag == "Player")
         {
             Instantiate(_Blood, transform.position, transform.rotation);
             Destroy(_Blood, 1f);

         }*/
        if (collision.gameObject.tag == "Sand" || collision.gameObject.tag == "Metal"|| collision.gameObject.tag == "Stone")
       {
            Destroy(this.gameObject);
        }
          
       
      

    }
   

}

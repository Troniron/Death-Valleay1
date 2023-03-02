using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorchanger : MonoBehaviour
{
    [SerializeField]
    private Color[] Change;
        [SerializeField]
    private Renderer c;
    bool changed,ox,Act;
    [SerializeField]
    private Transform i;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (i != this.transform)
        //{
        //    transform.Translate(5 * Time.deltaTime * new Vector3(i.position.x, i.transform.position.y, i.transform.position.z));
        //}
        //else
        //{
        //    transform.Translate(new Vector3(i.position.x, i.transform.position.y, i.transform.position.z));
        //}


        if (Input.GetMouseButtonDown(0))
         {
           
             if (ox)
             {
                 if (changed)
                 {
                   
                     c.material.color = Change[0];
                changed = false;
            }
                 else 
            {
                c.material.color = Change[1];
                    ox = false;
                changed = true;
            }
                 
                

             }
             else if(ox==false)
             {
                if (Act)
                {
                    c.material.color = Change[2];
                    Act = false;
                }
                else
                {
                    c.material.color = Change[3];
                    ox = true;
                    Act = true;
                }
                
              
             }





         }
         



    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DesignPattern : MonoBehaviour
{
    [SerializeField]
    private Text desighn;
    // Start is called before the first frame update
    void Start()
    {
        

        for(int i = 1; i <= 5; i++)
        {
            for(int j = 1; j <= i; j++)
            {
                
                
               // Debug.Log(j);
            }

            desighn.text ="space j";
        }

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}

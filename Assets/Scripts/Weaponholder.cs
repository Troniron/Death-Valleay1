using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponholder : MonoBehaviour
{
    [SerializeField]
    private int Weapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        selectweapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousweapon = Weapon;
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (1 >= transform.childCount - 1)
            
                Weapon = 0;
            
            else
            
                Weapon++;
            

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Weapon <=0)
            
                Weapon = transform.childCount-1;
            
            else
            
                Weapon--;
            

        }
        if (previousweapon != Weapon)
        {
            selectweapon();
        }

    }
    void selectweapon()
    {
        int i = 0;
        foreach (Transform Weaponholders  in transform)
        {
            if(i== Weapon)
            
                Weaponholders.gameObject.SetActive(true);
            
            else
            
                Weaponholders.gameObject.SetActive(false);
            
            i++;


        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _HealthBar : MonoBehaviour
{

    [SerializeField]
    private Slider _Sliding;
    public void Maxvalue(int Maxhealth)
    {
        _Sliding.maxValue = Maxhealth;
        _Sliding.value = Maxhealth;
    }
    public void Value(int health)
    {
        _Sliding.value = health;

    }
}

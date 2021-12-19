using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private float _spead;

    public float Spead { get => _spead; }

    public void ChangeSpeed(Slider slider)
    {
        _spead = slider.value;
    }
}

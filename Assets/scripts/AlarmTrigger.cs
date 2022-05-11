using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _speed = 0.2f; 
    private readonly float _maxVolume = 1;
    private readonly float _startVolume = 0;
    private bool _isActive = false;

    private void Start()
    {
        _alarmSound.Play();
        _alarmSound.volume = _startVolume;
        StartCoroutine(AlarmGrow());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (_isActive == false)
        {
            _isActive = true;           
        }
        else 
        {
            _isActive = false;     
        }
    }   
    private IEnumerator AlarmGrow()
    {
        while (true)
        {   
            if(_isActive == true)
            {
                _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, _maxVolume, _speed * Time.deltaTime);
            }
            else
            {
                _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, _startVolume, _speed * Time.deltaTime);
            }
            yield return null;
        }
    }
}


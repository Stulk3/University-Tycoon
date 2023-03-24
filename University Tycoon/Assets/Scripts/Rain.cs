using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public Light dirLight;
    private ParticleSystem _particleSystem;
    private bool _isRaining = false;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        
        StartCoroutine(Weather());
    }

    private void Update()
    {
        if (_isRaining && dirLight.intensity > 0.25f)
            LightIntensity(- 1) ;
        else if (!_isRaining && dirLight.intensity < 0.8f)
            LightIntensity(1);
    }

    private void LightIntensity(int mult)
    {
       dirLight.intensity +=  0.1f * Time.deltaTime * mult;
    }

    IEnumerator Weather()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(10f, 80f));
            if (_isRaining)
            {
                _particleSystem.Stop();
            }
            else
            {
                _particleSystem.Play();
            }
            _isRaining = !_isRaining;
        }
    }
}

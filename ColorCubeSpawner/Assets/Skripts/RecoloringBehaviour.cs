using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecoloringBehaviour : MonoBehaviour
{
    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;
    private float _recoloringTime;
    
    [SerializeField]
    private float _recoloringDuration = 5f;
    [SerializeField]
    private float _pauseTime = 2f;
    private float _lastRecoloringTime;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV(0f, 1f, 0.7f, 1f, 1f, 1f);
        GeneratorNextColor();
        _lastRecoloringTime = Time.time;
    }

    private void Update()
    {
        if (_pauseTime < Time.time - _lastRecoloringTime)
        {
            _recoloringTime += Time.deltaTime;
            var progress = _recoloringTime / _recoloringDuration;
            var currentColor = Color.Lerp(_startColor, _nextColor, progress);
            _renderer.material.color = currentColor;
            if (_recoloringTime >= _recoloringDuration)
            {
                _recoloringTime = 0f;
                GeneratorNextColor();
                _lastRecoloringTime = Time.time;
            }
        }
    }

    private void GeneratorNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f, 0.7f, 1f, 1f, 1f);
    }
}

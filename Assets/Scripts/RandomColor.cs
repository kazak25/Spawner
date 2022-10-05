using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomColor : MonoBehaviour
{
    [SerializeField] private float _recoloringDuration = 2f;

    [SerializeField] private float _waitingTime = 1f;
    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;
    private float _currentTime;
    private float _waitingTimer;


    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        ChangeColor();
    }

    private void ChangeColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
    }


    private void Update()
    {
        _waitingTimer += Time.deltaTime;
        if (_waitingTimer <= _waitingTime)
        {
            return;
        }
        _currentTime += Time.deltaTime;
        var progress = _currentTime / _recoloringDuration;
        _renderer.material.color = Color.Lerp(_startColor, _nextColor, progress);
        if (_currentTime > _recoloringDuration)
        {
            _waitingTimer = 0;
            _currentTime = 0;
            ChangeColor();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Juicer
{
    MonoBehaviour monoBehaviour;
    public Juicer(MonoBehaviour _monoBehaviour)
    {
        monoBehaviour = _monoBehaviour;
    }
    public void CameraShake(Camera camera, float duration, float magnitude, Action callbackAction = null)
    {
        monoBehaviour.StartCoroutine(CameraShakeCouroutine(camera, duration, magnitude, callbackAction));
    }
    IEnumerator CameraShakeCouroutine(Camera camera, float duration, float magnitude, Action callbackAction = null)
    {
        Vector3 originalPos = camera.transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1, 1f) * magnitude;
            float y = Random.Range(-1, 1f) * magnitude;
            camera.transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        camera.transform.localPosition = originalPos;
        callbackAction?.Invoke();
    }
    
    public void TweenPosition(GameObject movingObj, Vector3 endPos, AnimationCurve animationCurve, float duration, Action callbackAction = null)
    {
        Debug.Log(callbackAction);
        monoBehaviour.StartCoroutine(TweenPositionCouroutine(movingObj, endPos, animationCurve, duration, callbackAction));
    }
    IEnumerator TweenPositionCouroutine(GameObject movingObj, Vector3 endPos, AnimationCurve animationCurve, float duration, Action callbackAction = null)
    {
        float elapsed = 0.0f;
        float delta = 0.0f;
        Vector3 startPosition = movingObj.transform.position;
        while(elapsed < duration)
        {
            delta = animationCurve.Evaluate(elapsed / duration);
            movingObj.transform.position = Vector3.Lerp(startPosition, endPos, delta);
            elapsed += Time.deltaTime;
            yield return null;
        }
        callbackAction?.Invoke();
    }
}


public class Feeder
{
    AnimationCurve animationCurve;
    float duration = 0.0f;
    float delta = 0.0f;
    MonoBehaviour monoBehaviour;
    public Feeder(MonoBehaviour _monoBehaviour, AnimationCurve _animationCurve, float _duration)
    {
        monoBehaviour = _monoBehaviour;
        animationCurve = _animationCurve;
        duration = _duration;
    }
    public void StartFeeder(Action callbackAction = null)
    {
        monoBehaviour.StartCoroutine(StartFeederCouroutine(animationCurve, duration, callbackAction));
    }
    IEnumerator StartFeederCouroutine(AnimationCurve animationCurve, float duration, Action callbackAction = null)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            delta = animationCurve.Evaluate(elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        callbackAction?.Invoke();
    }
    public float GetDelta()
    {
        return delta;
    }
}
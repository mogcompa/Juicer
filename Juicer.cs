using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juicer : MonoBehaviour
{
    public void CameraShake(Camera camera, float duration, float magnitude)
    {
        StartCoroutine(CameraShakeCouroutine(camera, duration, magnitude));
    }
    IEnumerator CameraShakeCouroutine(Camera camera, float duration, float magnitude)
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

    }
    
    public void TweenPosition(Transform movingObj, Vector3 endPos, AnimationCurve animationCurve, float duration)
    {
        StartCoroutine(TweenPositionCouroutine(movingObj, endPos, animationCurve, duration));
    }
    IEnumerator TweenPositionCouroutine(Transform movingObj, Vector3 endPos, AnimationCurve animationCurve, float duration)
    {
        float elapsed = 0.0f;
        float delta = 0.0f;
        Vector3 startPosition = movingObj.position;
        while(elapsed > duration)
        {
            delta = animationCurve.Evaluate(elapsed / duration);
            movingObj.position = Vector3.Lerp(startPosition, endPos, delta);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}


public class Feeder : MonoBehaviour
{
    AnimationCurve animationCurve;
    float duration = 0.0f;
    float delta = 0.0f;
    public Feeder(AnimationCurve _animationCurve, float _duration)
    {
        animationCurve = _animationCurve;
        duration = _duration;
    }
    public void StartFeeder()
    {
        StartCoroutine(StartFeederCouroutine(animationCurve, duration));
    }
    IEnumerator StartFeederCouroutine(AnimationCurve animationCurve, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            delta = animationCurve.Evaluate(elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
    public float GetDelta()
    {
        return delta;
    }
}
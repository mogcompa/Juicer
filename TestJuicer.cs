using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJuicer : MonoBehaviour
{
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] Vector3 endPos;
    [SerializeField] float duration;
    Juicer juicer;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        juicer = new Juicer(this);
        startPos = this.transform.position;
        
        juicer.TweenPosition(this.gameObject, endPos, animationCurve, duration, tweenComplete);
    }
    public void tweenComplete()
    {
        Debug.Log("hELLO WORLD");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            transform.position = startPos;
            juicer.TweenPosition(this.gameObject, endPos, animationCurve, duration, tweenComplete);
        }
    }
    
}

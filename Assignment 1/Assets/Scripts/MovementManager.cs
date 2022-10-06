using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public GameObject _squashObject;
    public GameObject _lerpObject;

    public AnimationCurve _easingCurve;
    public AnimationCurve _squashCurve;
    float t;
    float squashT;

    bool _goingUp = true;

    private void Start()
    {
        Time.timeScale = 2;
    }

    void Update()
    {
        EasingFunc();

        LerpFunc();
    }

    void EasingFunc()
    {
        _squashObject.transform.position = new Vector3(0, _easingCurve.Evaluate(t), -3);

        _squashObject.transform.Rotate(0, 1, 0);

        if (t < 0.35f)
        {
            Squash();
            squashT += Time.smoothDeltaTime;
        }
        else
        {
            squashT = 0;
        }

        t += _goingUp ? Time.smoothDeltaTime : -Time.smoothDeltaTime;

        if (t > 1.0f)
        {
            _goingUp = false;
        }

        else if (t < 0.0f)
        {
            _goingUp = true;
        }
    }

    void LerpFunc()
    {
        _lerpObject.transform.position = new Vector3(Mathf.Sin(Time.realtimeSinceStartup) * 5, Mathf.Cos(t) + 1f, 0);
    }

    void Squash()
    {
        _squashObject.transform.localScale = new Vector3(1, _squashCurve.Evaluate(squashT * 1.5f), 1);
    }

}

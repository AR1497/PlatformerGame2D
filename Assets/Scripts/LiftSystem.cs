using UnityEngine;

public class LiftSystem : MonoBehaviour
{
    SliderJoint2D _sliderJoint2D;
    JointMotor2D _motorJoint2D;

    void Start()
    {
        TryGetComponent<SliderJoint2D>(out _sliderJoint2D);
        _sliderJoint2D.useMotor = true;
        _motorJoint2D = _sliderJoint2D.motor;
    }

    void FixedUpdate()
    {
        if (_sliderJoint2D.limitState == JointLimitState2D.LowerLimit)
        {
            SetSpeedMotor(0.5f);
        }
        else if (_sliderJoint2D.limitState == JointLimitState2D.UpperLimit)
        {
            SetSpeedMotor(-0.5f);
        }
    }

    void SetSpeedMotor(float speed)
    {
        _motorJoint2D.motorSpeed = speed;
        _sliderJoint2D.motor = _motorJoint2D;
    }
}

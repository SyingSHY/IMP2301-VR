using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JointListener : MonoBehaviour
{
    [SerializeField]
    private float angleThreshold = 5;    // for joint
    
    [SerializeField]
    private HingeJointState hingeJointState = HingeJointState.None;
    
    [SerializeField]
    private UnityEvent OnMaxLimitReached;  

    [SerializeField]
    private UnityEvent OnMinLimitReached;

    

    private enum HingeJointState { Min,Max,None}

    [SerializeField]
    private HingeJoint joint;

    private void FixedUpdate()
    {
        float distanceToMin = Mathf.Abs(joint.angle - joint.limits.min);
        float distanceToMax = Mathf.Abs(joint.angle - joint.limits.max);
        
        if (distanceToMin < angleThreshold)
        {
            if (hingeJointState != HingeJointState.Min)
            {
                OnMinLimitReached.Invoke(); // create event
            }
            hingeJointState = HingeJointState.Min;
        }
        else if (distanceToMax < angleThreshold)
        {
            if (hingeJointState != HingeJointState.Max)
            {
                OnMaxLimitReached.Invoke(); // create event
            }
            hingeJointState = HingeJointState.Max;
        }
        else
        {
            if (hingeJointState != HingeJointState.None)
            {
                
                hingeJointState = HingeJointState.None;
            }
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

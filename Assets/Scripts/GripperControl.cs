using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotiqGripperControl : MonoBehaviour
{
    // Main knuckles
    public Transform leftInnerKnuckle;
    public Transform rightInnerKnuckle;
    public Transform leftOuterKnuckle;
    public Transform rightOuterKnuckle;

    // Finger pads
    public Transform leftFingerPad;
    public Transform rightFingerPad;

    // Fingers
    public Transform leftOuterFinger;
    public Transform rightOuterFinger;
    public Transform leftInnerFinger;
    public Transform rightInnerFinger;

    public float closeAngle = 30f; // Angle to close the knuckles, finger pads, and fingers
    public float closeSpeed = 30f;  // Speed at which the gripper will close

    private Quaternion initialLeftInnerRotation;
    private Quaternion initialRightInnerRotation;
    private Quaternion initialLeftOuterRotation;
    private Quaternion initialRightOuterRotation;
    private Quaternion initialLeftFingerPadRotation;
    private Quaternion initialRightFingerPadRotation;
    private Quaternion initialLeftOuterFingerRotation;
    private Quaternion initialRightOuterFingerRotation;
    private Quaternion initialLeftInnerFingerRotation;
    private Quaternion initialRightInnerFingerRotation;
    private Quaternion targetLeftInnerRotation;
    private Quaternion targetRightInnerRotation;
    private Quaternion targetLeftOuterRotation;
    private Quaternion targetRightOuterRotation;
    private Quaternion targetLeftFingerPadRotation;
    private Quaternion targetRightFingerPadRotation;
    private Quaternion targetLeftOuterFingerRotation;
    private Quaternion targetRightOuterFingerRotation;
    private Quaternion targetLeftInnerFingerRotation;
    private Quaternion targetRightInnerFingerRotation;

    private bool isClosing = false;

    void Start()
    {
        // Store the initial rotations
        initialLeftInnerRotation = leftInnerKnuckle.localRotation;
        initialRightInnerRotation = rightInnerKnuckle.localRotation;
        initialLeftOuterRotation = leftOuterKnuckle.localRotation;
        initialRightOuterRotation = rightOuterKnuckle.localRotation;
        initialLeftFingerPadRotation = leftFingerPad.localRotation;
        initialRightFingerPadRotation = rightFingerPad.localRotation;
        initialLeftOuterFingerRotation = leftOuterFinger.localRotation;
        initialRightOuterFingerRotation = rightOuterFinger.localRotation;
        initialLeftInnerFingerRotation = leftInnerFinger.localRotation;
        initialRightInnerFingerRotation = rightInnerFinger.localRotation;

        // Calculate the target rotations for closing the gripper
        targetLeftInnerRotation = Quaternion.Euler(-closeAngle, 0, 0) * initialLeftInnerRotation;
        targetRightInnerRotation = Quaternion.Euler(closeAngle, 0, 0) * initialRightInnerRotation;
        targetLeftOuterRotation = Quaternion.Euler(-closeAngle, 0, 0) * initialLeftOuterRotation;
        targetRightOuterRotation = Quaternion.Euler(closeAngle, 0, 0) * initialRightOuterRotation;
        targetLeftFingerPadRotation = Quaternion.Euler(-closeAngle, 0, 0) * initialLeftFingerPadRotation;
        targetRightFingerPadRotation = Quaternion.Euler(closeAngle, 0, 0) * initialRightFingerPadRotation;
        targetLeftOuterFingerRotation = Quaternion.Euler(-closeAngle, 0, 0) * initialLeftOuterFingerRotation;
        targetRightOuterFingerRotation = Quaternion.Euler(closeAngle, 0, 0) * initialRightOuterFingerRotation;
        targetLeftInnerFingerRotation = Quaternion.Euler(-closeAngle, 0, 0) * initialLeftInnerFingerRotation;
        targetRightInnerFingerRotation = Quaternion.Euler(closeAngle, 0, 0) * initialRightInnerFingerRotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isClosing = !isClosing; // Toggle closing state
        }

        // Smoothly rotate the knuckles, finger pads, and fingers
        RotateTransform(leftInnerKnuckle, isClosing ? targetLeftInnerRotation : initialLeftInnerRotation);
        RotateTransform(rightInnerKnuckle, isClosing ? targetRightInnerRotation : initialRightInnerRotation);
        RotateTransform(leftOuterKnuckle, isClosing ? targetLeftOuterRotation : initialLeftOuterRotation);
        RotateTransform(rightOuterKnuckle, isClosing ? targetRightOuterRotation : initialRightOuterRotation);
        RotateTransform(leftFingerPad, isClosing ? targetLeftFingerPadRotation : initialLeftFingerPadRotation);
        RotateTransform(rightFingerPad, isClosing ? targetRightFingerPadRotation : initialRightFingerPadRotation);
        RotateTransform(leftOuterFinger, isClosing ? targetLeftOuterFingerRotation : initialLeftOuterFingerRotation);
        RotateTransform(rightOuterFinger, isClosing ? targetRightOuterFingerRotation : initialRightOuterFingerRotation);
        RotateTransform(leftInnerFinger, isClosing ? targetLeftInnerFingerRotation : initialLeftInnerFingerRotation);
        RotateTransform(rightInnerFinger, isClosing ? targetRightInnerFingerRotation : initialRightInnerFingerRotation);
    }

    // Method to rotate the transform
    private void RotateTransform(Transform transform, Quaternion targetRotation)
    {
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, Time.deltaTime * closeSpeed);
    }
}

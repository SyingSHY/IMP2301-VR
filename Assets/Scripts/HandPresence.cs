using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{

    private InputDevice targetDevice;

 

    private GameObject spawnedController;


    [SerializeField]
    private Animator handAnimator;

    private InputDeviceCharacteristics deviceCharacteristics;

   

    [SerializeField]
    private GameObject handPrefab;
    private GameObject spawnedHand;
    // Start is called before the first frame update
    void Start()
    {
        InitializedInput();
    }

    private void InitializedInput()
    {
        //list all connected XR devices
        List<InputDevice> devices = new List<InputDevice>();

        InputDeviceCharacteristics devChars = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right;
        InputDevices.GetDevicesWithCharacteristics(devChars, devices);

        //foreach(InputDevice dev in devices) {
        //    Debug.Log(dev.name + ", " +dev.characteristics);
        //}

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }

        if (spawnedHand == null)
        {
            spawnedHand = Instantiate(handPrefab, transform);
            handAnimator = spawnedHand.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid)
        {
            InitializedInput();
            return;
        }
        //if (Input.GetKeyDown("space")) {
        //    InitializedInput();
        //}
        // has targetDevice been set yet?
        if (targetDevice.isValid)
        {
            testInput();
        }
    }

    private void UpdateAnimator()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggervalue))
        {
            handAnimator.SetFloat("Trigger", triggervalue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripvalue))
        {
            handAnimator.SetFloat("Grip", gripvalue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    private void testInput()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            Debug.Log("PrimaryButton [A] is pressed");
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.2f)
        {
            Debug.Log("Trigger was pressed more than 20%");
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool trigger) && trigger)
        {
            Debug.Log("Trigger was pressed");
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 movement) && movement != Vector2.zero)
        {
            Debug.Log("Joystick moved " + movement);
        }
    }
}

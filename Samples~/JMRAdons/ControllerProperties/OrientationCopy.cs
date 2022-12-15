using System.Collections;
using JMRSDK.InputModule;
using UnityEngine;

public class OrientationCopy : MonoBehaviour
{
    public Transform objectToCopy;
    JMRInteractionManager.InteractionDeviceType deviceType;

    private void Start()
    {
        if (objectToCopy == null)
        {
            objectToCopy = gameObject.transform;
        }
        
        StartCoroutine(WaitandInitialize());
    }

    void Update()
    {
        /*
        IInputSource source = JMRInteractionManager.Instance.GetCurrentSource();
        Quaternion controllerOrientation;
        source.TryGetPointerRotation(out controllerOrientation);
        objectToCopy.transform.rotation = controllerOrientation;
        
        
        deviceType = JMRInteractionManager.Instance.GetSupportedInteractionDeviceType();
        if (deviceType == JMRInteractionManager.InteractionDeviceType.JIOGLASS_CONTROLLER)
        {
            //Jio Glass Pro
        }
        else if (deviceType == JMRInteractionManager.InteractionDeviceType.VIRTUAL_CONTROLLER)
        {
            //Jio Glass Lite
            objectToCopy.transform.eulerAngles += new Vector3(0, 90, 0);
        }
        */

        if(controller)
            objectToCopy.rotation = controller.rotation;

    }
    
    
    
    
    //by using the exact rotation of the controller
    private GameObject proController;
    private GameObject virtualController;
    private Transform controller;
    IEnumerator WaitandInitialize()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            proController=GameObject.Find("JioGlassController(Clone)");
            virtualController=GameObject.Find("JioGlassVirtualController(Clone)");
            if (proController != null || virtualController != null)
            {
                //got controller
                if(proController)
                    controller = proController.transform;
                else if(virtualController)
                    controller = virtualController.transform;
                break;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour {

    [Tooltip("Only fill this field if you want light charges to be regened")]
    public LightTransmitter lightTransmitter;
    public int powerToSend;

    [Space]
    public List<PoweredObject> poweredObjects;

    public void SendPower()
    {
        if (lightTransmitter)
            lightTransmitter.ReceivePower(powerToSend);

        foreach(PoweredObject po in poweredObjects)
        {
            po.SetActive(true);
        }
    }
}
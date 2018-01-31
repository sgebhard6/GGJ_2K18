using UnityEngine;

public class PoweredObject : MonoBehaviour {

    public bool activeAtStart;
    public float speed = 5;

    protected bool activated;

    //toggle active state of object
    public virtual void ToggleActive() { }

    //set active state of an object
    public virtual void SetActive(bool isActive) { }

    //function to contain any behaviors when object is in its active state
    protected virtual void ActiveState() { }
}
using UnityEngine;

public class RotatingObject : PoweredObject {

    public enum RotationDir
    {
        Clockwise,
        Counter
    }

    public RotationDir rotationDir = RotationDir.Clockwise;

	void Start () {
        if (activeAtStart)
            SetActive(true);
	}
	
	void Update () {
        if (activated)
            ActiveState();
	}

    public override void ToggleActive()
    {
        activated = !activated;
    }

    public override void SetActive(bool isActive)
    {
        activated = isActive;
    }

    protected override void ActiveState()
    {
        switch(rotationDir)
        {
            case RotationDir.Clockwise:
                transform.Rotate(Vector3.forward * -speed * Time.deltaTime);
                break;
            case RotationDir.Counter:
                transform.Rotate(Vector3.forward * speed * Time.deltaTime);
                break;
        }
    }
}
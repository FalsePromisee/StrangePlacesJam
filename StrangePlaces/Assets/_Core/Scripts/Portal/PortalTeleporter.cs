using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public PortalTeleporter otherPortal;

    private void OnTriggerStay(Collider other)
    {
        float zPosition = transform.worldToLocalMatrix.MultiplyPoint3x4 (other.transform.position).z;

        if (zPosition > 0)
        {
            Teleport(other.transform);
        }
    }

    private void Teleport(Transform objectToTeleport)
    {
        objectToTeleport.GetComponent<Movement>()?.PauseController();

        Vector3 localPosition = transform.worldToLocalMatrix.MultiplyPoint3x4(objectToTeleport.position);
        localPosition = new Vector3(-localPosition.x, localPosition.y, -localPosition.z);
        objectToTeleport.position = otherPortal.transform.localToWorldMatrix.MultiplyPoint3x4(localPosition);

        Quaternion diffrence = otherPortal.transform.rotation * Quaternion.Inverse(transform.rotation * Quaternion.Euler(0, 180, 0));
        objectToTeleport.rotation = diffrence * objectToTeleport.rotation;
    }

}

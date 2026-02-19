using UnityEngine;

public class PortalView : MonoBehaviour
{
    public PortalView otherPortal;
    public Camera portalView;
    public Shader portalShader;

    [SerializeField] private MeshRenderer portalMash;

    private Material portalMaterial;

    private void Start()
    {
        otherPortal.portalView.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        portalMaterial = new Material(portalShader);
        portalMaterial.mainTexture = otherPortal.portalView.targetTexture;
        portalMash.material = portalMaterial;
    }

    private void Update()
    {
        Vector3 lookerPosition = otherPortal.transform.InverseTransformPoint(Camera.main.transform.position);
        lookerPosition = new Vector3(-lookerPosition.x, lookerPosition.y, -lookerPosition.z);
        portalView.transform.localPosition = lookerPosition;


        Quaternion diffrence = transform.rotation * Quaternion.Inverse(otherPortal.transform.rotation * Quaternion.Euler(0, 180, 0));
        portalView.transform.rotation = diffrence * Camera.main.transform.rotation;

        portalView.nearClipPlane = lookerPosition.magnitude;
        
    }
}
    





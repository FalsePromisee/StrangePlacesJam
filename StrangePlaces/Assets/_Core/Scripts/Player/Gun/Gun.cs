using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private GameObject projectilePrefab;
    private ForceMode _projectileForceMode = ForceMode.Impulse;
    [SerializeField] private float projectileSpeed;

    public void Shoot()
    {
        var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        
        projectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileSpeed, _projectileForceMode);
    }
    
    
}

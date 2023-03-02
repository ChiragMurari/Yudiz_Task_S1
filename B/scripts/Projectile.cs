using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform ShootPoint;
    public Rigidbody bulletPrefabs;
    public GameObject cursor;
    public LayerMask layer;

    private Camera Cam;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchProjectile();
    }
                                
    void LaunchProjectile()
    {
        Ray camRay = Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay,out hit, 100f, layer))
        {
            cursor.SetActive(true);

            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 V0 = CalculateVelocity(hit.point, ShootPoint.position, 1f);

            transform.rotation = Quaternion.LookRotation(V0);

            if (Input.GetMouseButtonDown(0))
            {
                Rigidbody obj = Instantiate(bulletPrefabs, ShootPoint.position, Quaternion.identity);

                obj.velocity = V0;
            }

            else
            {
                cursor.SetActive(false);
            }
        }

    }

    Vector3 CalculateVelocity (Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y);

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result; 
    }
}
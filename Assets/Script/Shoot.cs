using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject target;
    public Rigidbody2D bulletPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // แปลงตำแหน่งเมาส์ในจอ เป็นตำแหน่งในโลก 2D
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.magenta, 5f);
 
 
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
 
            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
 
                Vector2 projectileVelocity = CalculateProjectileVelocity( shootPoint.position, hit.point, 1f);
 
                // สร้างกระสุนใหม่
                Rigidbody2D firedBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
 
                // ใส่ความเร็วให้กระสุน
                firedBullet.linearVelocity = projectileVelocity;
 
            }//hit.collider 
 
        }//GetMouseButtonDown
 
    }// Update

    Vector2 CalculateProjectileVelocity (Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;
 
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;
 
        return new Vector2(velocityX, velocityY);
 
    }// CalculateProjectileVelocity
}

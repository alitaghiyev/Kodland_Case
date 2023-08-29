using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 3;
    private void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        speed += 1f;
    }

    void FixedUpdate()
    {
        BulletCollision();
    }
    private void BulletCollision()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, 1);
        foreach (var item in targets)
        {
            if (item.tag == "Enemy")
            {
                GameManager.i.SetEnemyCount();
                Destroy(item.gameObject);
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(gameObject, 10f);
            }
        }
    }
}

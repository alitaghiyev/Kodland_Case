using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform rifleStart;


    [SerializeField] private float health = 0;
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float gravity = 10;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
         controller = GetComponent<CharacterController>();
        ChangeHealth(0);
    }


    void Update()
    {
        Shoot();
        PlayerCollision();
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (controller.isGrounded)
        {       
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))* movementSpeed;
            moveDirection = transform.TransformDirection(moveDirection);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, rifleStart.position, rifleStart.rotation);
        }
    }
    private void PlayerCollision()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, 3);
        foreach (var item in targets)
        {
            if (item.tag == "Heal")
            {
                ChangeHealth(50);
                Destroy(item.gameObject);
            }
            if (item.tag == "Finish")
            {
                GameManager.i.Win();
            }
            if (item.tag == "Enemy")
            {
                GameManager.i.Lost();
            }
        }
    }
    public void ChangeHealth(int hp)
    {
        health += hp;
        if (health > 100)
        {
            health = 100;
        }
        else if (health <= 0)
        {
            GameManager.i.Lost();
        }
        GameManager.i.SetHealthText(health);
    }
}

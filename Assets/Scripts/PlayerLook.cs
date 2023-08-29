using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float mouseSense;
    [SerializeField] private Transform player, playerArms;

    float xAxisClamp = 0;

    void Start()
    {
        CursorControl();
    }
    private void CursorControl()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        RotationControl();
    } 

    private void RotationControl()
    {
        float rotateX = Input.GetAxis("Mouse X") * mouseSense;
        float rotateY = Input.GetAxis("Mouse Y") * mouseSense;
       
        xAxisClamp -= rotateY; // farenin y ekseninde hareketi kameranın x ekseni etrafinda donusunu saglar. 

        Vector3 rotPlayerArms = playerArms.rotation.eulerAngles;
        Vector3 rotPlayer = player.rotation.eulerAngles;

        rotPlayerArms.x -= rotateY;
        rotPlayerArms.z = 0;

        rotPlayer.y += rotateX;

        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            rotPlayerArms.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            rotPlayerArms.x = 270;
        }

        playerArms.rotation = Quaternion.Euler(rotPlayerArms);
        player.rotation = Quaternion.Euler(rotPlayer);
    }
}

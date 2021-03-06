using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform Player;
    public float speed;
    public GameObject RestartPanel;

    private void Start()
    {
        RestartPanel.SetActive(false);
    }
    void Update()
    {
        if (Player)
        {
            // Когда позиция камеры соединиться с позицией игрока
            if (Player.position.y > transform.position.y)
            {
                // Двигаем строго по Y
                Vector3 newPosition = Player.position;
                newPosition.x = 0;
                newPosition.z = transform.position.z;

                transform.position = newPosition;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DoodPlayer>()) RestartPanel.SetActive(true);
        
        Destroy(collision.gameObject);
    }
}

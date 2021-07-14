using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMoveController : MonoBehaviour
{

    [SerializeField]
    Transform spaceshipTransform;
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    GameObject bullet;

    private Vector2 startPosition;
    private int leftTouch = 99;
    private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadTouching();
    }

    void ReadTouching()
    {
        int i = 0;

        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            Vector2 touchPosition = getTouchPosition(t.position) * -1;
            //Debug.Log($"Touch {t.position}");
            if (t.phase == TouchPhase.Began)
            {
                if (t.position.x > Screen.width / 2)
                {
                    Shoot();
                } 
                else
                {
                    leftTouch = t.fingerId;
                    startPosition = touchPosition;
                }
            }
            else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId) 
            {
                Vector2 offset = touchPosition - startPosition;
                Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

                Move(direction);
            }
            else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
            {
                leftTouch = 99;
            }

            ++i;
        } 
    }

    Vector2 getTouchPosition(Vector2 position)
    {
        //Debug.Log(position);
        return mainCamera.ScreenToWorldPoint(new Vector3(position.x, 0, mainCamera.transform.position.z));
    }
    void Shoot()
    {
        GameObject createdBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
        createdBullet.GetComponent<Rigidbody>().velocity = Vector3.up * speed;   
    }

    void Move(Vector2 position)
    {
        //Debug.Log($"new pos {position}");
        spaceshipTransform.Translate(position * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        
    }
}

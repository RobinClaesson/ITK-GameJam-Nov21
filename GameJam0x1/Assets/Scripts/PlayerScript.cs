using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 2f;

    public float cieling = 20, floor = -3;

    public float maxAngle = 30;
    public float minAngle = 0.1f;

    public GameObject bullet;
    public TextMeshProUGUI bulletText;
    public int maxBullets = 10;
    int bulletCount;
    public int bulletReloadTime = 60;
    int bulletReloadTick;

    public int lives = 5;
    public TextMeshProUGUI hpText;

    
    

    // Start is called before the first frame update
    void Start()
    {
        bulletCount = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {
        ///Movement
        float xRotation = transform.rotation.eulerAngles.x;
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y < cieling)
                transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);

            if (xRotation > 360 - maxAngle || xRotation < 2 * maxAngle)
                transform.Rotate(new Vector3(1, 0, 0), -2 * rotateSpeed * Time.deltaTime);

            //Debug.Log(transform.rotation.eulerAngles);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > floor)
                transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);

            if (xRotation > 360 - 2 * maxAngle || xRotation < maxAngle)
                transform.Rotate(new Vector3(1, 0, 0), 2 * rotateSpeed * Time.deltaTime);
        }

        else if (Mathf.Abs(xRotation) > minAngle)
        {
            //Debug.Log(xRotation);
            if (xRotation > 180)
                transform.Rotate(new Vector3(1, 0, 0), rotateSpeed * Time.deltaTime);
            else
                transform.Rotate(new Vector3(1, 0, 0), -rotateSpeed * Time.deltaTime);

        }

        //Shoot
        if (Input.GetKeyDown(KeyCode.Space) && bulletCount > 0)
        {
            GameObject obj = GameObject.Instantiate(bullet);
            obj.transform.position = transform.position;

            bulletCount--;
            if (bulletCount == 0)
                bulletReloadTick = bulletReloadTime;
        }

        //Reload
        if (bulletReloadTick > 0)
        {
            bulletReloadTick--;
            if (bulletReloadTick == 0)
                bulletCount = maxBullets;
        }


        //UI
        if (bulletCount > 0)
            bulletText.text = $":{bulletCount}";
        else
            bulletText.text = $":Reloading";
        
    }

    public void Hurt()
    {
        lives--;
        hpText.text = $":{lives}";

        if (lives == 0)
            SceneManager.LoadScene("GameOverScene");
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Hurt();
    }

}

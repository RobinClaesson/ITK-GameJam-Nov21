using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float cieling = 20, floor = -3;

    public int health = 100;

    public GameObject healthBar;

    public GameObject charging;

    

    public int attackMax = 500, attackMin = 200;
    int attackTick;

    // Start is called before the first frame update
    void Start()
    {
        attackTick = Random.Range(attackMin, attackMax);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Move
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);

        if (transform.position.y < floor)
        {
            moveSpeed *= -1;
            transform.position = new Vector3(transform.position.x, floor);
        }

        else if (transform.position.y > cieling)
        {
            moveSpeed *= -1;
            transform.position = new Vector3(transform.position.x, cieling);
        }

        //Attack
        attackTick--;
        if(attackTick == 0)
        {
            GameObject.Instantiate(charging, transform);
            attackTick = Random.Range(attackMin, attackMax);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT!");
        
        if (collision.gameObject.tag == "Attack")
        {
            health--;
            Destroy(collision.gameObject);

            


            var theBarRectTransform = healthBar.transform as RectTransform;
            theBarRectTransform.sizeDelta = new Vector2(10 * health, theBarRectTransform.sizeDelta.y);

            if (health <= 0)
                SceneManager.LoadScene("WinScene");
        }
    }
}

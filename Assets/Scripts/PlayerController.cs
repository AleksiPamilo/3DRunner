using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 7;
    private float speedUpTime = 10;
    private float turnSpeed = 7;
    private int scoreCount;
    private float leftSide = -4.5f;
    private float rightSide = 6.5f;
    public static bool gameIsRunning = true;

    // private float jumpCooldown = 1.5f;
    // private float timeSinceAction = 0.0f;

    public AudioSource coinFX;
    public GameObject coinCount;
    public GameObject gameLost;
    public GameObject endScoreTxt;

    [SerializeField] private Animator anim;

    void Update()
    {
        // P‰ivitet‰‰n score teksti‰
        coinCount.GetComponent<Text>().text = "Score: " + scoreCount;

        // timeSinceAction += Time.deltaTime;

        // Liikutetaan pelaajaa eteenp‰in
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);

        // Jos painetaan A tai vasenta nuoli n‰pp‰int‰
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Estet‰‰n pelaajan liikkuminen jos peli ei ole k‰ynniss‰
            if (!gameIsRunning) return;
            // Estet‰‰n pelaajan liikkuminen pois alueelta
            if (this.gameObject.transform.position.x > leftSide)
            {
                // Jos pelaaja on sallitulla alueella, liikutetaan pelaajaa vasemmalle
                transform.Translate(Vector3.left * Time.deltaTime * turnSpeed);
            }
        }
        // Jos painetaan D tai oikeaa nuoli n‰pp‰int‰
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Estet‰‰n pelaajan liikkuminen jos peli ei ole k‰ynniss‰
            if (!gameIsRunning) return;
            // Estet‰‰n pelaajan liikkuminen pois alueelta
            if (this.gameObject.transform.position.x < rightSide)
            {
                // Jos pelaaja on sallitulla alueella, liikutetaan pelaajaa oikealle
                transform.Translate(Vector3.right * Time.deltaTime * turnSpeed);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            /*if(timeSinceAction > jumpCooldown)
            {
                // Toistetaan hyppy animaatio
                anim.Play("Jump", 0, 0.0f);
                this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 100, ForceMode.Impulse);
            }*/
        }

        if (gameIsRunning)
        {
            if(speedUpTime > 0) { speedUpTime -= Time.deltaTime; }
            else
            {
                ++speed;
                speedUpTime = 10;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            ++scoreCount;
            coinFX.Play();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Tree") || other.gameObject.CompareTag("Rock"))
        {
            // Asetetaan pelaajan nopeus nollaksi, jotta pelaaja pys‰htyy
            speed = 0;
            // Toistetaan kaatumis animaatio
            anim.Play("Stumble Backwards", 0, 0.0f);
            // Aseteteaan gameIsRunning muuttuja false:ksi
            gameIsRunning = false;

            gameLost.SetActive(true);
            endScoreTxt.GetComponent<Text>().text = "You got " + scoreCount + " score";

            // Asetetaan kursori n‰kyviin
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

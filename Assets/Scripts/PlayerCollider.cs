using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private Text locationText;
    [SerializeField] private Text locationText2;
    public int diemso = 0;
    public AudioSource collectSound; // xu ly am thanh khi va cham
    public AudioSource chamda; 
    private bool isHitStone = true; // trang thai va cham
    private bool stoneCollisionProcessed = false;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Coin")
        {
            diemso += 1;
            collectSound.Play();
            hit.gameObject.GetComponent<Coin>().Dead(); // goi ham dead tu Coin

        }
        else if (hit.gameObject.tag == "StoneLocation")
        {
            //tru diem
            diemso -= 1;
            chamda.Play();
            StartCoroutine(EnableCollider(hit, 1));
        }

        //update len Text canvas
        if (hit.gameObject.tag == "MushroomLocation")
        {
            locationText.text = "Mushroom: Location";
        }
        if (hit.gameObject.tag == "Coin")
        {
            locationText.text = "Coin: Location";
        }
        else if (hit.gameObject.tag == "StoneLocation")
        {
            locationText.text = "Stone: Location";
        }
        else if (hit.gameObject.tag == "HouseLocation")
        {
            locationText.text = "House: Location";
        }
        else if (hit.gameObject.tag == "FireLocation")
        {
            locationText.text = "Fire: Location";
        }
    }

    private IEnumerator EnableCollider (ControllerColliderHit hit, float second)
    {
        isHitStone = false;
        yield return new WaitForSeconds(second); // sleep 1s
        isHitStone = true;
        yield return new WaitForSeconds(second);

        // Reset the flag to allow deduction for the next collision
        stoneCollisionProcessed = false;
    }

    void Start()
    {
        locationText2.text = "Điểm: " + diemso;
    }

    // Update is called once per frame
    void Update()
    {
        locationText2.text = "Điểm: " + diemso;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamamanage : MonoBehaviour
{

    public GameObject danger; //variables for Instantiate prefabs. sound trigger boxes
    public GameObject choir;
    public GameObject breeze;

    public AudioSource ahh; //sound for door disappearing
    public AudioSource putbulb; // sound for putting the bulb

    public GameObject bulb; // light bulb prefab
    public GameObject shotgun; // shotgun prefab
    public GameObject shotgundoor; //access to shotgundoor to destroy
    public GameObject escapedoor; //access to escapedoor to destroy

    private bool isbulb = false; //bool variables for instantiating. script should only instantiate one time at each time.

    private int bulbcount = 0; //when player get the bulb and put it. the bulbcount will go up.
    // Start is called before the first frame update
    void Start()
    {
        zerocount(); //at start. there is no bulb. but make sound trigger boxes.
    }

    // Update is called once per frame
    void Update()
    {

        //?????? ????????
        if (Input.GetKeyDown("t")) //?????????? ?????????? ??????????. t?? ?????? ?????? ???? ???????? ????????????! XR???????? ?????? ???????? ?????? input?? ???? ??????! ???? ?????????????? ???????? ????????????.
        {
            socketeventcalling();  // ???????? ???? ?????????? ?????????? ???????? ??????????!
        }
        // ?????? ???? ????



        if (bulbcount == 1 && isbulb) onecount();
        else if(bulbcount == 2 && isbulb) twocount();
        else if(bulbcount == 3 && isbulb) threecount();
        else if (bulbcount == 4 && isbulb) fourcount();
        else if (bulbcount == 5 && isbulb) fivecount();
        else if (bulbcount == 6 && isbulb) sixcount();
        
    }

    public void socketeventcalling() //event call by socket interaction. when this method happens. the bulbcount go up.
    {
           bulbcount++; //???? ?????????? ???????? ?????? ?????? ?? ??????, socketeventcalling?? ?????? ??????. ???????? ?????? bulbcount?? ???????? Update()???? ?? ?????? ???? ?????????? ?????? ??????!
            isbulb= true;
    }
    public void zerocount() //when the game start. make sound trigger boxes.
    {
        Debug.Log("im 0");
        Instantiate(danger, new Vector3(0.5f, 0, 9.5f), Quaternion.identity);
        Instantiate(choir, new Vector3(-5.5f, 0, -5.5f), Quaternion.identity);
        Instantiate(breeze, new Vector3(0.5f, 0, -6f), Quaternion.identity);

        Instantiate(bulb, new Vector3(-0.5f, 1f, 9.5f), Quaternion.identity); //instantiate first burb. and keep instantiate new bulbs whenever player puts it. 1 bulb, in front of the door

    }
    public void onecount() //re-instantiate trigger boxes with different positions. keep going on whenever the player puts the bulb.
    {
        Debug.Log("im 1");
        Instantiate(danger, new Vector3(-8.5f, 0, 1.5f), Quaternion.identity);

        Instantiate(bulb, new Vector3(-5.5f, 1f, -5f), Quaternion.identity); //2bulb, third maze

        putbulb.Play();

        isbulb= false;

    }

    private void twocount()
    {
        Debug.Log("im 2");
        
        Instantiate(choir, new Vector3(6.5f, 0, 4.5f), Quaternion.identity);

        Instantiate(bulb, new Vector3(8.5f, 1f, -2.5f), Quaternion.identity); // 3bulb, fourth maze

        putbulb.Play();

        isbulb = false;

    }

    public void threecount()
    {
        Debug.Log("im 3");
       
        Instantiate(breeze, new Vector3(5.5f, 0, -7.5f), Quaternion.identity);

        Instantiate(bulb, new Vector3(-6.5f, 1f, 7.5f), Quaternion.identity); // 4bulb, seond maze

        Destroy(shotgundoor); //door to the shotgun is open. player put the half of the bulb.

        ahh.Play();
        
        isbulb = false;


    }

    public void fourcount()
    {
        Debug.Log("im 4");
        Instantiate(danger, new Vector3(-0.5f, 0, -0.5f), Quaternion.identity);
        Instantiate(choir, new Vector3(6.5f, 0, -10.5f), Quaternion.identity);
        Instantiate(breeze, new Vector3(-10.5f, 0, 4.5f), Quaternion.identity);

        Instantiate(bulb, new Vector3(4.5f, 1f, 7.5f), Quaternion.identity); // 5bulb, first maze

        putbulb.Play();

        Instantiate(shotgun, new Vector3(0,1f,0), Quaternion.identity); //instantiate shotgun in the middle of the map. because player can only use shotgun once.

        isbulb = false;


    }

    public void fivecount()
    {
        Debug.Log("im 5");
        Instantiate(danger, new Vector3(7f, 0, 9.5f), Quaternion.identity);

        Instantiate(bulb, new Vector3(0f, 3.3f, 21.8f), Quaternion.identity); // 6, last bulb, on shotgun place

        putbulb.Play();

        Instantiate(shotgun, new Vector3(0, 1f, 0), Quaternion.identity); //instantiate shotgun in the middle of the map. because player can only use shotgun once.

        isbulb = false;



    }


    public void sixcount()
    {
        Debug.Log("im 6"); //put every bulb in the spot.
        
        Instantiate(breeze, new Vector3(-0.5f, 0, 6f), Quaternion.identity);

        Destroy(escapedoor); //exit is open

        ahh.Play();

        isbulb = false;

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { up, left, right, down };

public class ShipSection : MonoBehaviour
{
    public List<GameObject> _wallList; // This will contain all of the walls for this ship section ( 4 max ).
    public GameObject wallPrefab; // the prefab to use for the walls of this module.
    //private GameObject _attachedTo = null; // This is the ship section that this initially attaches to.
    //private GameObject _leftNeighbor = null;
    //private GameObject _rightNeighbor = null;
    //private GameObject _upNeighbor = null;
    //private GameObject _downNeighbor = null;
    //public int _xposition; // This will contain this section's x position on the ship's array.
    //public int _yposition; // This will contain the section's y position on the ship's array.
    //public float health = 100;



    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //GetNeighbors(); // This will update the neighbors stored in this section.
        //InitializeWalls(); // This will create the wall objects around the ship section, but not draw them.
        //UpdateWalls(); // This will draw the walls appropriately, given the neighbor information.


    }

    // Update is called once per frame
    void Update()
    {


        /*
        if (health < 0)
        {
            //gameObject.GetComponentInParent<Ship>()._shipSections[_xposition, _yposition] = null; // remove this object from the master list of ship sections
            Destroy(gameObject);
            // maybe add effects later
        }

        //GetNeighbors(); // there's probably a more efficient way to keep track of neighbors, but this will do for now.
        //UpdateWalls(); // This will draw the walls appropriately, given the neighbor information.
        */
    }


    // This value will update the 4 neighbor values in the class.
    // This is a little copy-pastey and can probably be improved later.
    /*
    private void GetNeighbors()
    {
        GameObject[,] shipSections = gameObject.GetComponentInParent<Ship>()._shipSections; // get the master list containing all ship sections (maybe can improve later)

        int _leftOfX = _xposition - 1; // To be a left neighbor, its X must be 1 less.
        int _rightOfX = _xposition + 1; // To be a right neighbor, its X must be 1 higher.
        int _aboveY = _yposition + 1; // To be an upward neighbor, its Y must be 1 higher.
        int _belowY = _yposition - 1; // To be a downward neighbor, its Y must be 1 less.

        // Is it a leftward neighbor?
        if ((_leftOfX >= 0) && (shipSections[_leftOfX, _yposition] is GameObject))
            _leftNeighbor = (shipSections[_leftOfX, _yposition]);
        else
            _leftNeighbor = null; // don't leave old values in here if the neighbors don't exist anymore!
        // Is it a rightward neighbor?
        if ((_rightOfX <= shipSections.GetUpperBound(0)) && shipSections[_rightOfX, _yposition] is GameObject)
            _rightNeighbor = (shipSections[_rightOfX, _yposition]);
        else
            _rightNeighbor = null; // don't leave old values in here if the neighbors don't exist anymore!
        // Is it an upward neighbor?
        if ((_aboveY <= shipSections.GetUpperBound(1)) && shipSections[_xposition, _aboveY] is GameObject)
            _upNeighbor = (shipSections[_xposition, _aboveY]);
        else _upNeighbor = null;  // don't leave old values in here if the neighbors don't exist anymore!
        // Is it a downward neighbor?
        if ((_belowY >= 0) && (shipSections[_xposition, _belowY] is GameObject))
            _downNeighbor = (shipSections[_xposition, _belowY]);
        else _downNeighbor = null; // don't leave old values in here if the neighbors don't exist anymore!
    }
    */

    //https://answers.unity.com/questions/995267/how-get-coords-of-objects-bounds.html
    private List<Vector3> centersOfEdges(GameObject go)
    {
        float width = go.GetComponent<Renderer>().bounds.size.x;
        float height = go.GetComponent<Renderer>().bounds.size.y;

        Vector3 top = go.transform.position, bottom = go.transform.position, right = go.transform.position, left = go.transform.position;

        top.y += height / 2;

        bottom.y -= height / 2;

        left.x -= width / 2;

        right.x += width / 2;

        List<Vector3> ed_temp = new List<Vector3>();
        ed_temp.Add(top);
        ed_temp.Add(left);
        ed_temp.Add(right);
        ed_temp.Add(bottom);

        return ed_temp;
    }

    /*
    // This will create the wall objects around the ship section, but not draw them.
    private void InitializeWalls()
    {
        List<Vector3> edges = centersOfEdges(this.gameObject);
        if (!(_upNeighbor is GameObject)) // if there's no neighbor to the left of this module
        {
            _wallList[(int)Direction.up].SetActive(true);
        }
        if (!(_leftNeighbor is GameObject)) // if there's no neighbor to the left of this module
        {
            _wallList[(int)Direction.left].SetActive(true);
        }
        if (!(_rightNeighbor is GameObject)) // if there's no neighbor to the left of this module
        {
            _wallList[(int)Direction.right].SetActive(true);
        }
        if (!(_downNeighbor is GameObject)) // if there's no neighbor to the left of this module
        {
            _wallList[(int)Direction.down].SetActive(true);
        }
    }
    */

    // This function will draw all the walls, ensuring that walls only appear on the outside edges of the ship (so where there is not a neighbor)
    // This will also update and colors/effects the walls should be changing each frame.
    private void UpdateWalls()
    {


    }




}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSection : MonoBehaviour
{
    private List<Wall> _wallList; // This will contain all of the walls for this ship section ( 4 max ).
    private GameObject _attachedTo = null; // This is the ship section that this initially attaches to.
    private GameObject _leftNeighbor = null;
    private GameObject _rightNeighbor = null;
    private GameObject _upNeighbor = null;
    private GameObject _downNeighbor = null;
    public int _xposition; // This will contain this section's x position on the ship's array.
    public int _yposition; // This will contain the section's y position on the ship's array.
    public float health = 100;
    


    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        CreateSection(); // This will create the object/sprite in game.
        GetNeighbors(); // This will update the neighbors stored in this section.
        InitializeWalls(); // This will create the wall objects around the ship section, but not draw them.
        UpdateWalls(); // This will draw the walls appropriately, given the neighbor information.


    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            gameObject.GetComponentInParent<Ship>()._shipSections[_xposition, _yposition] = null; // remove this object from the master list of ship sections
            Destroy(gameObject);
            // maybe add effects later
        }

        GetNeighbors(); // there's probably a more efficient way to keep track of neighbors, but this will do for now.
        UpdateWalls(); // This will draw the walls appropriately, given the neighbor information.
    }



    // This will handle creating the initial game object, its prefab, and lining it up appropriately with the section to attach to.
    private void CreateSection()
    {
        // NOTHING
    }

    // This value will update the 4 neighbor values in the class.
    // This is a little copy-pastey and can probably be improved later.
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


    // This will create the wall objects around the ship section, but not draw them.
    private void InitializeWalls()
    {
        throw new NotImplementedException();
    }

    // This function will draw all the walls, ensuring that walls only appear on the outside edges of the ship (so where there is not a neighbor)
    // This will also update and colors/effects the walls should be changing each frame.
    private void UpdateWalls()
    {


    }


}

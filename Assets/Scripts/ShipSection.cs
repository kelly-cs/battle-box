using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSection : MonoBehaviour
{
    private List<Wall> _wallList; // This will contain all of the walls for this ship section ( 4 max ).
    private List<ShipSection> _neighbors; // This will contain a list of all neighbors to this ship section.
    private ShipSection left_neighbor;
    private ShipSection right_neighbor;
    private ShipSection up_neighbor;
    private ShipSection down_neighbor;
    public int _xposition; // This will contain this section's x position on the ship's array.
    public int _yposition; // This will contain the section's y position on the ship's array.
    


    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        // Check for neighboring pieces. If there is a piece to the left of this ship section, do not display the wall on that side.
        List<ShipSection> neighbors = GetNeighbors();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // This value will update the 4 neighbor values in the class.
    // This is a little copy-pastey and can probably be improved later.
    public void GetNeighbors()
    {
        // we want to keep this list up to date with no old stuff in it, so let's empty it first.
        left_neighbor = null;
        right_neighbor = null;
        up_neighbor = null;
        down_neighbor = null;

        ShipSection[,] shipSections = gameObject.GetComponentInParent<Ship>()._shipSections; // get the master list containing all ship sections (maybe can improve later)

        int _leftOfX = _xposition - 1; // To be a left neighbor, its X must be 1 less.
        int _rightOfX = _xposition + 1; // To be a right neighbor, its X must be 1 higher.
        int _aboveY = _yposition + 1; // To be an upward neighbor, its Y must be 1 higher.
        int _belowY = _yposition - 1; // To be a downward neighbor, its Y must be 1 less.

        // Is it a leftward neighbor?
        if (shipSections[_leftOfX, _yposition] is ShipSection)
            left_neighbor = (shipSections[_leftOfX, _yposition]);
        // Is it a rightward neighbor?
        if (shipSections[_rightOfX, _yposition] is ShipSection)
            right_neighbor = (shipSections[_rightOfX, _yposition]);
        // Is it an upward neighbor?
        if (shipSections[_xposition, _aboveY] is ShipSection)
            up_neighbor = (shipSections[_xposition, _aboveY]);
        // Is it a downward neighbor?
        if (shipSections[_xposition, _belowY] is ShipSection)
            down_neighbor = (shipSections[_xposition, _belowY]);
    }

    // This function will draw all the walls, ensuring that walls only appear on the outside edges of the ship (so where there is not a neighbor)
    // This will also update and colors/effects the walls should be changing each frame.
    public void UpdateWalls()
    {

    }

    // Creates a new Ship Section with a given position on the ship.
    public ShipSection(int x, int y)
    {
        _xposition = x;
        _yposition = y;
        CreateSection(); // This will create the object/sprite in game.
        GetNeighbors(); // This will update the neighbors stored in this section.
        UpdateWalls(); // This will draw the walls appropriately, given the neighbor information.

        // we will make it draw a new ship section on the ship
        // we will add it to the parent
    }
}

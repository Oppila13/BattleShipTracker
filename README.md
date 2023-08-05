# BattleShipTracker
Simple implementation of BattleShip Game

The code has two APIs
 * api/add
     * Description: Adds one or more battleship(s) to the board.
     * Input Values:
          * Row - Ship's starting row value
          * Column - Ship's starting column value
          * Length - Number of cells the ship is going to occupy
          * Orientation - The orientation of the ship can be either horizontal or vertical
      * Sample input:
          *  [{"row":"2","column":"0","length":"5","orientation":"vertical"},{"row":"5","column":"5","length":"3","orientation":"horizontal"}]
      * Output: Output can either be 200 or 400 with corresponding messages
      * Output messages:
           * 200:
             * Ship Placed
           * 400:
             * Ship placement is out of bounds
             * Ship placement overlaps with another ship
             * Invalid orientation
             * Invalid ship placement data. 
                 
 * api/attack
     * Description: Attacks the given cell in the board
     * Input Values:
          * Row - Row value to attack
          * Column - Column value to attack
      * Sample input:
           * {"row":"2","column":"2"}
      * Output can either be 'hit' or 'miss' or 'Invalid attack data'.


Project Folder Structure:

    * BattleShipTracker.API
      * Controllers
      * Constants
      * Implementation
      * Interface
      * Models
      * Program and startup file
    * BattleShipTracker.Test
      * Test file
     





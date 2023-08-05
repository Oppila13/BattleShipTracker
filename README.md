# BattleShipTracker
Simple implementation of BattleShip Game (10X10). As mentioned in the question only add and attack are implemented. In attack, 'hit' or 'miss' logic are present. The code is dynamic and 'sunk' logic can be added easily to /attack api and the code for /add is implemented having three possiblities in mind 'hit', 'miss' and 'sunk'. 

The endpoints are publicly avaialble to test the code. Different unit test cases are added in BattleShipTracker.Test folder. 

Public Endpoint URL: http://battleshiptrackerapi-dev.ap-southeast-2.elasticbeanstalk.com

#### The code has two APIs
 * ### api/add
     * Method: POST
     * Public api endpoint: http://battleshiptrackerapi-dev.ap-southeast-2.elasticbeanstalk.com/api/add
     * Description:
         * Adds one or more battleship(s) to the board.
     * Input Values:
          * Row - Ship's starting row value.(Accepted values 0 - 9)
          * Column - Ship's starting column value.(Accepted values 0 - 9)
          * Length - Number of cells the ship is going to occupy.(Accepted values 0 - 9 and Row+Length or Column+Length is not greater than 10)
          * Orientation - The orientation of the ship can be either horizontal or vertical.(Accepted values 'horizontal' or 'vertical')
      *  Sample input:
           * Add Content-Type: application/json in the header
           * Add the following in body
           ```sh
           [{"row":"2","column":"0","length":"1","orientation":"vertical"},{"row":"5","column":"5","length":"3","orientation":"horizontal"}]
           ```
      *  Output messages:
           * 200:
             * Ship Placed
           * 400:
             * Ship placement is out of bounds
             * Ship placement overlaps with another ship
             * Invalid orientation
             * Invalid ship placement data. 
                 
 * ### api/attack
     * Method: POST
     * Public api endpoint: http://battleshiptrackerapi-dev.ap-southeast-2.elasticbeanstalk.com/api/attack
     *  Description:
          * Attacks the given cell in the board
     *  Input Values:
          * Row - Row value to attack.(Accepted values 0 - 9)
          * Column - Column value to attack.(Accepted values 0 - 9)
      *  Sample input:
          * Add Content-Type: application/json in the header
          * Add the following in body
         ```sh
         {"row":"2","column":"2"}
         ```
      *  Output can either be 'hit' or 'miss' or 'Invalid attack data'.








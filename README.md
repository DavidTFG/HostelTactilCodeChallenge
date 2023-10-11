# HostelTactilCodeChallenge Connect Four

This web service is desigend to handle Connect Four game boards and determine the winner. It consists on the following key components:

## ConnectFourController

That class handle HTTP POST request and interacts with the **ConnectFourRepository** to validate the game board and determine the winner.

In the **Post([FromBody] string board)** method:
-Convert the string received to uppercase.
-Check preconditions.
-If there are no preconditions failed, check for the winner.
-If preconditions fail, return a 400 Bad Request with an error message depends on the precondition failed.

## ConnectFourRepository

That class contains the game logic and validations methods.

In the **CheckPreconditions(string board)** method:
-Launches the checks of all preconditions, returning a message depending on the precondition that has failed.

In the **CheckWinner(string board)** method:
-Checks the board for a winning chain in horizontal, vertical, or diagonal directions, returning the winning char.

The rest of private methods checks varios aspects of the game board.

## Board Model

The Board model class defines **constants** for the number of rows and columns in a game board.

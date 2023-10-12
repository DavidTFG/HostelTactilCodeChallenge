# HostelTactilCodeChallenge Connect Four

This web service is designed to handle Connect Four game boards and determine the winner. It consists of the following key components:

### ConnectFourController

That class handle HTTP POST request and interacts with the **ConnectFourService** to validate the game board and determine the winner.

In the **Post([FromBody] string board)** method:

- Convert the string received to uppercase.
- Check preconditions calling service the service method:
  - If there are no preconditions failed, check for the winner calling the service method.
  - If preconditions fail, return a 400 Bad Request with an error message depends on the precondition failed.

### ConnectFourService

That class makes the calls to the repository **ConnectFourRepository**.

### ConnectFourRepository

That class contains the game logic and validations methods.

In the **CheckPreconditions(string board)** method:

- Launches the checks of all preconditions, returning a message depending on the precondition that has failed.

In the **CheckWinner(string board)** method:

- Checks the board for a winning chain in horizontal, vertical, or diagonal directions, returning the winning char.

The rest of private methods checks various aspects of the game board.

### Board Model

The Board model class defines **constants** for the number of rows and columns in a game board.

### ConnectFourServiceTests

This is a test class for the **ConnectFourService** from Connect Four project.
The class test:

- CheckWinner
  - This method test **CheckWinner** method, which checks for a winner.
    -The test cases include scenarios for vertical wins, horizontal wins, and diagonal wins, as well as a scenario where neither Player A nor player B wins.
- CheckPreconditions
  - This method test **CheckPreconditions** method, which checks various preconditions.
    -The test cases include scenarios for different numbers of pieces on the board, unbalanced boards, boards that don't start with Player A, and boards with pieces not placed correctly.

## How to Start the Project

- Open a terminal or command promt.
- Navigate to the project folder "ConnectFour"
- Run the project using the following command:
  `dotnet run`
- This will start the project, and you can access it in your web browser by navigating to the specified address.
- Once the project is running, you can test the project using **Swagger**. Open your web browser and go to the following URL, also change to correct port:
  localhost:<PORT>/swagger

  Make sure you have the .NET SDK installed before running the project.

## How to Test the Project

- Open a terminal or command prompt.
- Navigate to the project folder "ConnectFourTests"
- Run the tests using the following command:
  `dotnet test`
- This will run the tests. You can modify the tests from the **ConnectFourServiceTests.cs**.

  Make sure you have the .NET SDK installed before testing the project.

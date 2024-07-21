Welcome to my Bingo game program! This program uses principles of Object-Oriented Programming (OOP) to create a flexible and modular Bingo game. Here's a brief overview of how the program works and how it demonstrates each OOP concept that has been taught in this course.

** Abstraction **

Abstraction means hiding complex implementation details and showing only the necessary parts of an object.
In my program, the BingoGame class is an abstract base class that provides a general framework for a Bingo game. It defines what a Bingo game should do (like 'StartGame' and  'CallNextBall') without specifying exactly how these actions are implemented. This allows different types of Bingo games (like 'Bingo75Game') to be created using the same basic structure but with specific behaviors. 

** Encapsulation **

Encapsulation is the practice of bundling the data (attributes) and methods (functions) that operate on the data into a single unit, and restricting access to some of the object’s components.
In my program, the BingoBall class represents a Bingo ball. It has private attributes (_letter, _number, and _isCalled) that are protected from direct external access. Methods and properties are used to manage these attributes, ensuring that the internal state of a BingoBall is modified in a controlled manner.

** Inheritance **

Inheritance allows a new class to inherit attributes and methods from an existing class, enabling code reuse and extending functionality.

In this program, Bingo75Game inherits from the BingoGame abstract class. It provides specific implementations for the abstract methods defined in BingoGame, such as how to initialize Bingo balls (InitializeBalls), start the game (StartGame), and handle Bingo checking (CheckForBingo). This means Bingo75Game can use the general structure of BingoGame while adding its own details.

** Polymorphism **

Polymorphism allows objects of different classes to be treated as objects of a common base class. It also allows methods to be overridden to provide specific behaviors in derived classes.

In my program, polymorphism is used to override different methods. In the Bingo75Game class, methods like StartGame and CallNextBall override abstract methods from the BingoGame class. This means you can use a BingoGame reference to call these methods, and the correct version of the method will be executed based on the actual type of the object.

** How the program works **

Starting a Game:

When you start the program, it initializes a new Bingo game by calling GameLauncher.StartNewGame().
This creates an instance of Bingo75Game and invokes its StartGame method to set up the game.

Calling Bingo Balls:

The game starts calling Bingo balls one by one using the CallNextBall method.
Each ball is displayed with a rolling animation and added to the list of called balls.

Checking for Bingo:

After calling each ball, the program checks if someone has achieved Bingo by calling 
CheckForBingo.
If Bingo is detected, the game results are processed, including displaying all called balls and calculating winnings.

Ending the Game:

After a Bingo win or when all balls are called, the program may save the game results to a file and ask if the user wants to start a new game.
This design demonstrates OOP principles by structuring the game into well-defined classes with specific responsibilities, allowing for easy extension and maintenance.

** Exceeding requirements **

I spent a lot of time working on creating an animation for the Bingo balls. While it took much trial and error, I believe I came up with something that resembles a Bingo ball. 

I also worked on creating sounds for my program. However, due to differences in computer operating systems, certain sounds may or may not work correctly. I did include some code that could be utilized, if the proper extensions are installed and enabled in VS code.

The program also creates a CSV file of data from each Bingo game that is completed. It will keep track of all of the balls that were called, game financial information, and the number of winners in each game. This will assist someone using this program, in case there are discrepancies raised after the games have been finalized.
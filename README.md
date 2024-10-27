# Slot Machine

This is a simple roulette wheel game built in Unity 2020.3.33f1.


**Systems Used**
The following systems are used in this game:

# **C# Unity Scripts**


**Manager.cs**: manages the game state and user's bets.

**RouletteWheel.cs**: spins the roulette wheel and calculates the payout.

**RouletteWheel.cs**: Handles the data for each reels. You can access the data and modify it in the inspector since it is serialized.

**Usage**
The user can place bets of 1, 10, 50, or 100 units. When the user hits the spacebar, the roulette wheel spins and lands on a random value. If the user wins, their payout is added to their total money. If the user loses, their bet is subtracted from their total money.


# **Objects**

Reels

Numbers


# **Game Mechanics**

The roulette wheel contains 10 values, each with a corresponding payout:

A: (0, 0, 1, 5, 10)
B: (0, 0, 2, 8, 25)
C: (0, 0, 3, 10, 50)
D: (0, 0, 4, 15, 75)
E: (0, 0, 5, 20, 100)
F: (0, 0, 10, 50, 250)
G: (0, 0, 20, 100, 500)
H: (0, 0, 50, 200, 1000)
I: (0, 0, 100, 500, 5000)
J: (0, 0, 250, 1000, 10000)

# **Scalability of system**

With enough time. We can implement targeted results instead of just random spins for each reels.
We can add a back end database using firewall to monitor each user's account and high scores

# Flexibility of the system

Each data in each reels are modifyable and also the textures are modular for easy switch of textures. 

# MVC

In the context of this slot machine game, the MVC framework could be used in the following way:

The Model would represent the game's underlying data, such as the player's balance, the current bet amount, and the payout table. It would provide an interface for other components to read and modify this data as needed.

The View would represent the game's user interface, including the slot machine display, the controls for adjusting the bet amount and starting the game, and any relevant messages or alerts. It would read from the Model to determine what to display and would notify the Controller when user actions occur.

The Controller would represent the game's control logic, receiving input from the View and updating the Model accordingly. It would also use the Model to calculate payouts and determine when the game should end. Finally, it would notify the View of any changes in the Model so that the user interface can be updated as needed.

By separating the game's data, user interface, and control logic into distinct components, the MVC framework can make the code more modular and easier to understand and maintain. It also makes it easier to update the user interface without affecting the underlying game logic or data, and vice versa.

# Future Improvements

I can say that there's a lot of room for improvement in this game I created such as better data handling, better payout system, better UI and much more. I hope I can learn more on this now that I am entering the industry.

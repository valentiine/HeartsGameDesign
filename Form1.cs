// Name : Valentine Sah
// Date : April 16th, 2024
// Program : HeartsGameDesign
// Description : This is the game of Hearts as spoken about in class.

using HeartsGameDesign;

namespace HeartsGameDesign
{
    public partial class Form1 : Form
    {

        private Deck deck; // Deck of cards for the game
        private Card currentCard; // Field to hold the last card played on the table
        private List<Card> playerHand;  // Human player's hand
        private List<Card>[] cpuHands; // Array to hold hands for each CPU player
        private bool heartsBroken = false; // Flag to indicate if a Heart card has been played which changes the rules
        private Dictionary<int, List<PictureBox>> cpuPictureBoxMappings; // Map each CPU player to a list of Picture Boxes that represents their cards
        private int currentPlayerTurn; // Keep track of who's turn it is to play 0 = Human Player / 1-3 = CPU Player

        private int playerPoints = 0; // Score counter for the Human Player
        private Dictionary<int, int> cpuPoints = new Dictionary<int, int> { { 1, 0 }, { 2, 0 }, { 3, 0 } }; // A map of each CPU player's score, with the player number as the key

        private bool gameEnded = false; // Indicate whether the game has ended or not

        private GameStatistics gameStats = new GameStatistics(); // Object that keeps track of Game Statistics

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            InitializeCpuPictureBoxMappings(); // Mappings done before game starts
            InitializeCpuPictureBoxMappings(); // Initialize mappings (cpu)
            InitializeGame(); // This will setup the game when the form loads

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Size = new Size(170, 260); // width x height

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Size = new Size(170, 260); // width x height

            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Size = new Size(170, 260); // width x height

            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.Size = new Size(170, 260); // width x height

            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.Size = new Size(170, 260); // width x height

            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.Size = new Size(170, 260); // width x height

            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.Size = new Size(170, 260); // width x height

            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.Size = new Size(170, 260); // width x height


            // Real Player's last played card
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.Size = new Size(170, 260); // width x height

            // real player card
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.Size = new Size(153, 234); // width x height

            // real player card
            pictureBox11.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox11.Size = new Size(153, 234); // width x height

            // real player card
            pictureBox12.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox12.Size = new Size(153, 234); // width x height

            // real player card
            pictureBox13.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox13.Size = new Size(153, 234); // width x height

            pictureBox17.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox17.Size = new Size(170, 260); // width x height

            pictureBox16.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox16.Size = new Size(170, 260); // width x height

            pictureBox15.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox15.Size = new Size(170, 260); // width x height

            pictureBox14.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox14.Size = new Size(170, 260); // width x height

            // Set Harry's selected card picture box to invisible by default
            pictureBox9.Visible = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HideCpuCards()
        {
            // Reset CPU card PictureBoxes to show the back image and to be prepared for new cards
            var cpuPictureBoxes = cpuPictureBoxMappings.SelectMany(pair => pair.Value).ToList();
            var backImage = Image.FromFile("PNG-cards-1.3/card_down.png");

            foreach (var pictureBox in cpuPictureBoxes)
            {
                pictureBox.Image = backImage;
                pictureBox.Tag = null; // Clear any references to previous cards
            }
        }



        private void InitializeGame()
        {
            InitializeCpuPictureBoxMappings(); // Initialize mappings first

            // Reset game state
            heartsBroken = false;
            currentPlayerTurn = 0;

            // Create a new deck, shuffle it, and deal new hands
            deck = new Deck();
            deck.Shuffle();

            // Deal a new starting card and display it
            currentCard = deck.DealOne();
            pictureBox18.Image = currentCard.Image;
            pictureBox18.Visible = true;

            // Deal new hands to the player and CPU players
            playerHand = deck.DealHand(4);
            cpuHands = new List<Card>[3];
            for (int i = 0; i < cpuHands.Length; i++)
            {
                cpuHands[i] = deck.DealHand(5);
            }

            // Update the UI for the player's hand
            DisplayPlayerHand();
            HideCpuCards(); // Reset the CPU cards to the back image
        }



        private void DisplayPlayerHand()
        {
            var playerPictureBoxes = new List<PictureBox> { pictureBox10, pictureBox11, pictureBox12, pictureBox13 };

            // Check if the player hand is correctly populated
            if (playerHand.Count != playerPictureBoxes.Count)
                throw new InvalidOperationException("The number of cards in player hand does not match PictureBoxes count.");

            for (int i = 0; i < playerHand.Count; i++)
            {
                playerPictureBoxes[i].Image = playerHand[i].Image; // Assign new card images
                playerPictureBoxes[i].Tag = playerHand[i]; // Update tags to new card objects
                playerPictureBoxes[i].Visible = true; // Make sure they're visible
            }
        }


        private async void PlayerCard_Click(object sender, EventArgs e)
        {

            // If the game has ended, no more actions are allowed
            if (gameEnded) return;

            // Ensure that it's Harry's turn (human player)
            if (currentPlayerTurn != 0)
            {
                MessageBox.Show("Wait for your turn.");
                return;
            }

            PictureBox clickedCard = sender as PictureBox;
            Card selectedCard = (Card)clickedCard.Tag;

            // Validate selected card
            if (!IsCardEligible(selectedCard))
            {
                MessageBox.Show("This card can't be played. Please follow the suit!");
                return; // Card is not eligible, return early
            }

            // Update game state
            if (selectedCard.Suit == Suit.Hearts)
            {
                heartsBroken = true; // Hearts are now broken
            }

            // Show the selected card under Harry's name
            pictureBox9.Image = selectedCard.Image;
            pictureBox9.Visible = true;

            // Remove the selected card from Harry's hand
            playerHand.Remove(selectedCard);

            // Hide the clicked card from Harry's hand
            clickedCard.Visible = false;

            // Update the current card played in PictureBox 18
            pictureBox18.Image = selectedCard.Image;

            // After Harry plays a card, increment the turn
            currentPlayerTurn = (currentPlayerTurn + 1) % 4;

            // After playing a card, update points and check for game end
            UpdatePoints(selectedCard, 0); // 0 for player
            CheckForGameEnd();

            // Call NextTurn to proceed with the game
            NextTurn();
        }

        // Check if the player is trying to play hearts for the first time
        private bool IsCardEligible(Card card)
        {
            // Check that the hand and current card are initialized
            if (playerHand == null) throw new InvalidOperationException("Player hand has not been initialized.");
            if (currentCard == null) throw new InvalidOperationException("No current card is set.");

            // If the current card is not null and the player has a card of the same suit, they must play that suit.
            if (currentCard != null && playerHand.Any(c => c.Suit == currentCard.Suit))
            {
                // The card played must match the leading suit (the suit of the current card)
                if (card.Suit != currentCard.Suit)
                {
                    return false; // The player did not follow the leading suit
                }
            }

            // If the leading suit is not hearts and hearts have not been broken, a heart cannot be played
            if (!heartsBroken && currentCard.Suit != Suit.Hearts && card.Suit == Suit.Hearts)
            {
                return playerHand.All(c => c.Suit == Suit.Hearts); // Return true only if the player has no other suit to play
            }

            // If none of the above conditions apply, the card is eligible
            return true;
        }


        private async Task PlayCpuTurnAsync()
        {
            // If the game has ended, stop the CPU from playing
            if (gameEnded) return;

            // We only proceed if it's a CPU's turn
            while (currentPlayerTurn >= 1 && currentPlayerTurn <= 3)
            {
                // Delay to simulate CPU thinking as humans do
                await Task.Delay(1000);

                // Check again if the game has ended before proceeding
                if (gameEnded) return;

                var cpuHand = cpuHands[currentPlayerTurn - 1];
                Card cpuCard = ChooseCpuCardToPlay(cpuHand);

                // The PictureBox corresponding to the CPU player needs to be update
                PictureBox cpuPictureBox = ChooseCpuPictureBox(currentPlayerTurn - 1, cpuCard);
                if (cpuPictureBox != null)
                {
                    // This updates the UI with the CPU's played card
                    UpdateCpuPlayedCardUI(cpuCard, cpuPictureBox);
                }

                // Update current card and PictureBox before potentially ending the game
                currentCard = cpuCard;

                // Display the CPU's played card
                pictureBox18.Image = cpuCard.Image; 

                // Update points which could potentially end the game
                UpdatePoints(cpuCard, currentPlayerTurn);

                // Check if the game has ended after the points update
                CheckForGameEnd(); 

                // If game ends within CheckForGameEnd, we should have already displayed the card
                if (gameEnded) break;

                // Remove the played card from the CPU's hand
                cpuHand.Remove(cpuCard); 

                // Move to the next player's turn
                currentPlayerTurn = (currentPlayerTurn + 1) % 4;

                // If it's back to the human player's turn, allow interaction
                if (currentPlayerTurn == 0)
                {
                    // Exit the method to give control back to the human player
                    EnablePlayerHand(true);
                    return; 
                }
            }
        }



        private void UpdatePoints(Card card, int player)
        {
            int points = 0;

            if (card.Suit == Suit.Hearts)
                points = 5; // Each Heart is worth 5 points

            if (card.Value == Value.Queen && card.Suit == Suit.Spades)
                points = 10; // Queen of Spades is worth 10 points

            // Add points to the appropriate player's score
            if (player == 0) // Player is the user
                playerPoints += points;

            else // Player is a CPU
                cpuPoints[player] += points;
        }


        private void CheckForGameEnd()
        {
            // Check if any player has reached or exceeded the score limit to end the game
            if (playerPoints >= 15 || cpuPoints.Any(kvp => kvp.Value >= 15))
            {
                // Determine the winner as the player with the lowest score
                // If there's a tie, there can be multiple winners
                var lowestScore = Math.Min(playerPoints, cpuPoints.Values.Min());
                var winners = new List<string>();

                if (playerPoints == lowestScore)
                    winners.Add($"Player (Score: {playerPoints})");
                foreach (var kvp in cpuPoints)
                {
                    if (kvp.Value == lowestScore)
                        winners.Add($"CPU {kvp.Key} (Score: {kvp.Value})");
                }

                // Record the win for each winner and set the last game winners in game statistics
                foreach (var winner in winners)
                {
                    gameStats.RecordWin(winner);
                }
                gameStats.SetLastGameWinners(winners);

                // Construct the message with the names and scores of the winners or tied players
                string message = winners.Count == 1 ?
                                 $"{winners.First()} has won with the lowest score!" :
                                 $"There's a tie for the lowest score between: {string.Join(", ", winners)}.";

                MessageBox.Show(message, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Set the flag to indicate the game has ended
                gameEnded = true; 

                // Disable gameplay-related controls
                DisableGameplay(); 
            }
        }




        private void DisableGameplay()
        {
            // Disable player hand
            foreach (var pictureBox in new PictureBox[] { pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13 })
            {
                pictureBox.Enabled = false;
            }
        }


        private Card ChooseCpuCardToPlay(List<Card> cpuHand)
        {
            // Check if there is a leading card to follow
            if (currentCard != null)
            {
                // Try to find a card in the CPU's hand that matches the suit of the current card
                Card cardToPlay = cpuHand.FirstOrDefault(card => card.Suit == currentCard.Suit);
                if (cardToPlay != null)
                {
                    // Found a matching suit card, play this card
                    return cardToPlay;
                }
                else
                {
                    // No matching suit card found, play any card if hearts are broken or if there is no other choice
                    if (heartsBroken || !cpuHand.Any(card => card.Suit != Suit.Hearts))
                    {
                        return cpuHand.First();
                    }
                    else
                    {
                        // Play the first non-heart card if hearts are not broken
                        return cpuHand.First(card => card.Suit != Suit.Hearts);
                    }
                }
            }

            return cpuHand.First();
        }


        private void ResetAfterRound()
        {
            // TBD
        }

        private void UpdateCpuPlayedCardUI(Card cpuCard, PictureBox cpuPictureBox)
        {
            cpuPictureBox.Image = cpuCard.Image; // Set the image of the PictureBox to the card image
            cpuPictureBox.Tag = cpuCard; // store the card object in the Tag property
        }

        private void InitializeCpuPictureBoxMappings()
        {
            // Initialize the mapping of CPU player index to their corresponding PictureBoxes
            cpuPictureBoxMappings = new Dictionary<int, List<PictureBox>>
            {
                // cpuHands[0] = pictureBox1 to pictureBox4
                { 0, new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4 } },

                // cpuHands[1] = pictureBox5 to pictureBox8
                { 1, new List<PictureBox> { pictureBox5, pictureBox6, pictureBox7, pictureBox8 } },

                // cpuHands[2] = pictureBox14 to pictureBox17
                { 2, new List<PictureBox> { pictureBox17, pictureBox16, pictureBox15, pictureBox14 } }
            };
        }

        private PictureBox ChooseCpuPictureBox(int cpuIndex, Card card)
        {
            // Find the correct PictureBox list based on the CPU index
            List<PictureBox> pictureBoxes = cpuPictureBoxMappings[cpuIndex];

            // Find the first PictureBox in the list that doesn't have a card displayed (Tag is null)
            PictureBox selectedPictureBox = pictureBoxes.FirstOrDefault(pb => pb.Tag == null);
            if (selectedPictureBox != null)
            {
                // Set the Tag to the card to mark this PictureBox as occupied
                selectedPictureBox.Tag = card;
                return selectedPictureBox;
            }
            else
            {
                // If no PictureBox is available, return null or handle this scenario appropriately
                return null;
            }
        }

        private void EnablePlayerHand(bool enable)
        {
            foreach (var pictureBox in new PictureBox[] { pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13 })
            {
                pictureBox.Enabled = enable;
            }
        }

        private void NextTurn()
        {
            if (currentPlayerTurn == 0)
            {
                // Human player's turn
                EnablePlayerHand(true);
            }
            else
            {
                // CPU's turn
                EnablePlayerHand(false);
                _ = PlayCpuTurnAsync();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            InitializeGame(); // Reinitialize the game setup
            ResetUI(); // Reset all UI components to their initial state
            ResetGameState(); // Additional method to ensure the complete reset of the game state
        }

        private void ResetUI()
        {
            // Reset all PictureBoxes to show the back of the card or be hidden, except for user's hand and current card played
            var playerPictureBoxes = new HashSet<PictureBox> { pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox18 };

            foreach (var pictureBox in Controls.OfType<PictureBox>())
            {
                if (!playerPictureBoxes.Contains(pictureBox))
                {
                    pictureBox.Image = Image.FromFile("PNG-cards-1.3/card_down.png"); // Reset to card back image
                    pictureBox.Visible = true; // Make all PictureBoxes visible
                    pictureBox.Tag = null; // Clear the Tag to reset any card association
                }

                // Reset player and starting card PictureBoxes
                else
                {
                    pictureBox.Image = null; // Set to null to clear old images
                }
            }

            pictureBox9.Visible = false; // Current card played by player should be hidden on new game
        }


        private void ResetGameState()
        {
            // Reset all game logic variables to their initial state
            heartsBroken = false;
            currentPlayerTurn = 0;

            // Clear any remaining data from previous game
            foreach (var hand in cpuHands)
            {
                hand.Clear();
            }
            playerHand.Clear();

            // Re-deal cards and update UI accordingly
            InitializeGame();

            // Reset scores
            playerPoints = 0;
            foreach (var key in cpuPoints.Keys.ToList())
            {
                cpuPoints[key] = 0;
            }

            // Reset the game ended flag
            gameEnded = false;

            // Re-enable player hand if it was disabled
            EnablePlayerHand(true);
        }

        // Used in Beta testing phase, no longer needed
        private void ResetPictureBoxTags()
        {
            foreach (PictureBox pb in Controls.OfType<PictureBox>())
            {
                pb.Tag = null;
            }
        }

        // This is the GameRules button, I forgot to change the name before double clicking it
        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the GameRulesForm
            GameRulesForm rulesForm = new GameRulesForm(); 

            // Focus solely on the Games Rules form
            rulesForm.ShowDialog();
        }

        public void ChangePlayerAndCpuNames(string cpu1, string cpu2, string player, string cpu3)
        {
            // Gather all the names as variable as we could be changing them
            txtCPU1.Text = cpu1;
            txtCPU2.Text = cpu2;
            txtPlayer.Text = player;
            txtCPU3.Text = cpu3;
        }

        public void ChangeTableColorToRed()
        {
            // Image is in the same folder as the card images
            string pathToRedTable = "PNG-cards-1.3/red_poker_table.jpg";
            try
            {
                this.BackgroundImage = Image.FromFile(pathToRedTable);
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show($"Table image not found: {pathToRedTable}", "Image Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ChangeTableColorToGreen()
        {
            // Image is in the same folder as the card images
            string pathToGreenTable = "PNG-cards-1.3/green_poker_table.png";
            try
            {
                this.BackgroundImage = Image.FromFile(pathToGreenTable);
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show($"Table image not found: {pathToGreenTable}", "Image Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Settings form
            Settings settingsForm = new Settings(gameStats);

            // Focus solely on the Settings page
            settingsForm.ShowDialog();
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            // Check if the game has ended and only shuffle if it's still ongoing
            if (!gameEnded)
            {
                ShuffleAndDealNewHands();
            }
            else
            {
                MessageBox.Show("The game has ended. Please start a new game to continue playing.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShuffleAndDealNewHands()
        {
            // Shuffle the deck
            deck.Shuffle(); 

            // Deal new hands to the player and CPUs
            playerHand = deck.DealHand(4);
            for (int i = 0; i < cpuHands.Length; i++)
            {
                cpuHands[i] = deck.DealHand(5);
            }

            // Update the UI with the player's new hand
            DisplayPlayerHand();

            // Hide the CPUs' old cards
            HideCpuCards(); 

            // Ensure that play continues with the human player
            currentPlayerTurn = 0;

            // Enable the player's hand for interaction
            EnablePlayerHand(true); 
        }
    }
}
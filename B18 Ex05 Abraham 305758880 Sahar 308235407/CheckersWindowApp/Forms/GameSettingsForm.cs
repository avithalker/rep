using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic.Configuration;
using BusinessLogic.Enums;

namespace CheckersWindowApp.Forms
{
    public class GameSettingsForm : Form
    {
        private Button buttonDone = new Button();
        private Label labelBoardSizeTitle = new Label();
        private RadioButton radioButtonOpOne = new RadioButton();
        private RadioButton radioButtonOpTwo = new RadioButton();
        private RadioButton radioButtonOpThree = new RadioButton();
        private Label labelPlayersTitle = new Label();
        private Label labelPlayerOneTitle = new Label();
        private TextBox textBoxPlayerOne = new TextBox();
        private CheckBox checkBoxPlayerTwo = new CheckBox();
        private TextBox textBoxPlayerTwo = new TextBox();
        private GameConfiguration m_GameConfiguration;
        private bool m_InvalidIName = false;
   
        public GameSettingsForm()
        {
            initializeComponents();
        }

        public GameConfiguration GameConfiguration
        {
            get { return m_GameConfiguration; }
            set { m_GameConfiguration = value; }
        }

        private void initializeComponents()
        {
            buttonDone.Location = new Point(316, 275);
            buttonDone.Size = new Size(120, 49);
            buttonDone.Text = "Done";
            buttonDone.Click += buttonDone_Clicked;

            labelBoardSizeTitle.Location = new Point(20, 13);
            labelBoardSizeTitle.Size = new Size(123, 25);
            labelBoardSizeTitle.Text = "Board Size:";

            radioButtonOpOne.Location = new Point(32, 50);
            radioButtonOpOne.Size = new Size(90, 29);
            radioButtonOpOne.Text = "6 x 6";
            radioButtonOpOne.Checked = true;

            radioButtonOpTwo.Location = new Point(128, 50);
            radioButtonOpTwo.Size = new Size(90, 29);
            radioButtonOpTwo.Text = "8 x 8";

            radioButtonOpThree.Location = new Point(219, 50);
            radioButtonOpThree.Size = new Size(90, 29);
            radioButtonOpThree.Text = "10 x 10";
         
            labelPlayersTitle.Location = new Point(20, 100);
            labelPlayersTitle.Size = new Size(90, 25);
            labelPlayersTitle.Text = "Players:";

            labelPlayerOneTitle.Location = new Point(58, 145);
            labelPlayerOneTitle.Size = new Size(97, 25);
            labelPlayerOneTitle.Text = "Player 1:";

            textBoxPlayerOne.Location = new Point(198, 145);
            textBoxPlayerOne.Size = new Size(157, 31);

            checkBoxPlayerTwo.Location = new Point(63, 210);
            checkBoxPlayerTwo.Size = new Size(129, 29);
            checkBoxPlayerTwo.Text = "Player 2:";
            checkBoxPlayerTwo.CheckedChanged += checkBoxPlayerTwo_Checked;

            textBoxPlayerTwo.Location = new Point(198, 208);
            textBoxPlayerTwo.Size = new Size(157, 31);
            textBoxPlayerTwo.Text = "[Computer]";
            textBoxPlayerTwo.Enabled = false;

            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 400);
            Size = new Size(470, 400);
            Text = "Game Settings";

            FormClosed += GameSettingsForm_Closed;

            Controls.AddRange(new Control[]
            {
              buttonDone, checkBoxPlayerTwo, labelBoardSizeTitle,
              labelPlayerOneTitle, labelPlayersTitle, radioButtonOpOne,
              radioButtonOpTwo, radioButtonOpThree, textBoxPlayerOne, textBoxPlayerTwo, labelPlayerOneTitle
            });
        }

        private void GameSettingsForm_Closed(object sender, EventArgs e)
        {
            if (m_GameConfiguration == null)
            {
                setDefaultGameConfiguration();
            }
        }

        private void setDefaultGameConfiguration()
        {
            PlayerConfiguration playerOneConfiguration = new PlayerConfiguration();

            m_GameConfiguration = new GameConfiguration();
            playerOneConfiguration.PlayerType = ePlayerTypes.Human;
            playerOneConfiguration.PlayerName = "Player 1";
            m_GameConfiguration.AddPlayerConfiguration(playerOneConfiguration);
            m_GameConfiguration.GameMode = eGameModes.OnePlayerGame;
            m_GameConfiguration.BoardSize = 6;
        }

        private void checkBoxPlayerTwo_Checked(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                textBoxPlayerTwo.Enabled = true;
            }
            else
            {
                textBoxPlayerTwo.Enabled = false;
            }
        }

        private void buttonDone_Clicked(object sender, EventArgs e)
        {
            m_GameConfiguration = createGameConfiguration();

            if (m_GameConfiguration != null && m_InvalidIName == false)
            {
                Close();
            }
            else
            {
                m_InvalidIName = false;
            }
        }

        private GameConfiguration createGameConfiguration()
        {
            GameConfiguration gameConfiguration = new GameConfiguration();
            PlayerConfiguration playerOneConfiguration = getPlayerOneConfiguration();
            PlayerConfiguration playerTwoConfiguration;

            gameConfiguration.AddPlayerConfiguration(playerOneConfiguration);
            gameConfiguration.BoardSize = getBoardSize();
            
            if(checkBoxPlayerTwo.Checked == true)
            {
                playerTwoConfiguration = getPlayerTwoConfiguration();
                gameConfiguration.AddPlayerConfiguration(playerTwoConfiguration);
                gameConfiguration.GameMode = eGameModes.TwoPlayersGame;
            }
            else
            {
                gameConfiguration.GameMode = eGameModes.OnePlayerGame; ////add a second player as a computer. 
            }

            return gameConfiguration;
        }

        private PlayerConfiguration getPlayerTwoConfiguration()
        {
            PlayerConfiguration playerConfiguration = new PlayerConfiguration();

            if(textBoxPlayerTwo.Text == string.Empty)
            {
                MessageBox.Show("Invalid name for Player 2. Please type his name");
                m_InvalidIName = true;
            }
            else
            {
                playerConfiguration.PlayerName = textBoxPlayerTwo.Text;
                playerConfiguration.PlayerType = ePlayerTypes.Human;        
            }

            return playerConfiguration;
        }

        private PlayerConfiguration getPlayerOneConfiguration()
        {
            PlayerConfiguration playerConfiguration = new PlayerConfiguration();

            if(textBoxPlayerOne.Text == string.Empty)
            {
                MessageBox.Show("Invalid name for player No. 1. please type his name");
                m_InvalidIName = true;
            }
            else
            {
                playerConfiguration.PlayerName = textBoxPlayerOne.Text;
                playerConfiguration.PlayerType = ePlayerTypes.Human;
            }

            return playerConfiguration;
        }

        private int getBoardSize()
        {
            int boardSize;

            if(radioButtonOpOne.Checked == true)
            {
                boardSize = 6;
            }
            else if (radioButtonOpTwo.Checked == true)
            {
                boardSize = 8;
            }
            else
            {
                boardSize = 10;
            }

            return boardSize;
        }
    }
}

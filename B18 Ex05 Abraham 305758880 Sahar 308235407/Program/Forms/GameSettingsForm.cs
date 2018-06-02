using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Configuration;
using BusinessLogic.Enums;

namespace CheckersWindowApp.Forms
{
    public class GameSettingsForm : Form
    {
        private Button m_ButtonDone = new Button();
        private Label m_LabelBoardSizeTitle = new Label();
        private RadioButton m_RadioButtonOpOne = new RadioButton();
        private RadioButton m_RadioButtonOpTwo = new RadioButton();
        private RadioButton m_RadioButtonOpThree = new RadioButton();
        private Label m_LabelPlayersTitle = new Label();
        private Label m_LabelPlayerOneTitle = new Label();
        private TextBox m_TextBoxPlayerOne = new TextBox();
        private CheckBox m_CheckBoxPlayerTwo = new CheckBox();
        private TextBox m_TextBoxPlayerTwo = new TextBox();
        private GameConfiguration m_GameConfiguration;
   
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
            m_ButtonDone.Location = new Point(316, 275);
            m_ButtonDone.Size = new Size(120, 49);
            m_ButtonDone.Text = "Done";
            m_ButtonDone.Click += buttonDone_Clicked;

            m_LabelBoardSizeTitle.Location = new Point(20, 13);
            m_LabelBoardSizeTitle.Size = new Size(123, 25);
            m_LabelBoardSizeTitle.Text = "Board Size:";

            m_RadioButtonOpOne.Location = new Point(32, 50);
            m_RadioButtonOpOne.Size = new Size(90, 29);
            m_RadioButtonOpOne.Text = "6 x 6";
            m_RadioButtonOpOne.Checked = true;

            m_RadioButtonOpTwo.Location = new Point(128, 50);
            m_RadioButtonOpTwo.Size = new Size(90, 29);
            m_RadioButtonOpTwo.Text = "8 x 8";

            m_RadioButtonOpThree.Location = new Point(219, 50);
            m_RadioButtonOpThree.Size = new Size(90, 29);
            m_RadioButtonOpThree.Text = "10 x 10";
         
            m_LabelPlayersTitle.Location = new Point(20, 100);
            m_LabelPlayersTitle.Size = new Size(90, 25);
            m_LabelPlayersTitle.Text = "Players:";

            m_LabelPlayerOneTitle.Location = new Point(58, 145);
            m_LabelPlayerOneTitle.Size = new Size(97, 25);
            m_LabelPlayerOneTitle.Text = "Player 1:";

            m_TextBoxPlayerOne.Location = new Point(198, 145);
            m_TextBoxPlayerOne.Size = new Size(157, 31);

            m_CheckBoxPlayerTwo.Location = new Point(63, 210);
            m_CheckBoxPlayerTwo.Size = new Size(129, 29);
            m_CheckBoxPlayerTwo.Text = "Player 2:";
            m_CheckBoxPlayerTwo.CheckedChanged += checkBoxPlayerTwo_Checked;

            m_TextBoxPlayerTwo.Location = new Point(198, 208);
            m_TextBoxPlayerTwo.Size = new Size(157, 31);
            m_TextBoxPlayerTwo.Text = "[Computer]";
            m_TextBoxPlayerTwo.Enabled = false;

            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 400);
            Size = new Size(470, 400);
            Text = "Game Settings";

            FormClosed += GameSettingsForm_Closed;

            Controls.AddRange(new Control[]
            {
              m_ButtonDone, m_CheckBoxPlayerTwo, m_LabelBoardSizeTitle,
              m_LabelPlayerOneTitle, m_LabelPlayersTitle, m_RadioButtonOpOne,
              m_RadioButtonOpTwo, m_RadioButtonOpThree, m_TextBoxPlayerOne, m_TextBoxPlayerTwo, m_LabelPlayerOneTitle
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
                m_TextBoxPlayerTwo.Enabled = true;
            }
            else
            {
                m_TextBoxPlayerTwo.Enabled = false;
            }
        }

        private void buttonDone_Clicked(object sender, EventArgs e)
        {
            m_GameConfiguration = createGameConfiguration();

            if (m_GameConfiguration != null)
            {
                Close();
            }
        }

        private GameConfiguration createGameConfiguration()
        {
            GameConfiguration gameConfiguration = new GameConfiguration();
            PlayerConfiguration playerOneConfiguration = getPlayerOneConfiguration();
            PlayerConfiguration playerTwoConfiguration;

            gameConfiguration.AddPlayerConfiguration(playerOneConfiguration);
            gameConfiguration.BoardSize = getBoardSize();
            
            if(m_CheckBoxPlayerTwo.Checked == true)
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

            if(m_TextBoxPlayerTwo.Text == string.Empty)
            {
                MessageBox.Show("Invalid name for Player 2. Please type his name");
            }
            else
            {
                playerConfiguration.PlayerName = m_TextBoxPlayerTwo.Text;
                playerConfiguration.PlayerType = ePlayerTypes.Human;
            }

            return playerConfiguration;
        }

        private PlayerConfiguration getPlayerOneConfiguration()
        {
            PlayerConfiguration playerConfiguration = new PlayerConfiguration();

            if(m_TextBoxPlayerOne.Text == string.Empty)
            {
                MessageBox.Show("Invalid name for player No. 1. please type his name");
            }
            else
            {
                playerConfiguration.PlayerName = m_TextBoxPlayerOne.Text;
                playerConfiguration.PlayerType = ePlayerTypes.Human;
            }

            return playerConfiguration;
        }

        private int getBoardSize()
        {
            int boardSize;

            if(m_RadioButtonOpOne.Checked == true)
            {
                boardSize = 6;
            }
            else if (m_RadioButtonOpTwo.Checked == true)
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

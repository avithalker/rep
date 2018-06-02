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
        private PlayerConfiguration m_PlayerOneConfiguration;
        private PlayerConfiguration m_PlayerTwoConfiguration;
        private int m_BoardSize = 6;
      

        public GameSettingsForm()
        {
            initializeComponents();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);  
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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
            m_ButtonDone.Click += m_ButtonDone_Clicked;

            m_LabelBoardSizeTitle.Location = new Point(20, 13);
            m_LabelBoardSizeTitle.Size = new Size(123, 25);
            m_LabelBoardSizeTitle.Text = "Board Size:";

            m_RadioButtonOpOne.Location = new Point(32, 50);
            m_RadioButtonOpOne.Size = new Size(90, 29);
            m_RadioButtonOpOne.Text = "6 x 6";
            m_RadioButtonOpOne.Click += m_RadioButtonOpOne_Checked;
            m_RadioButtonOpOne.Checked = true;

            m_RadioButtonOpTwo.Location = new Point(128, 50);
            m_RadioButtonOpTwo.Size = new Size(90, 29);
            m_RadioButtonOpTwo.Text = "8 x 8";
            m_RadioButtonOpTwo.Click += m_RadioButtonOpTwo_Checked;

            m_RadioButtonOpThree.Location = new Point(219, 50);
            m_RadioButtonOpThree.Size = new Size(90, 29);
            m_RadioButtonOpThree.Text = "10 x 10";
            m_RadioButtonOpThree.Click += m_RadioButtonOpThree_Checked;


            m_LabelPlayersTitle.Location = new Point(20, 100);
            m_LabelPlayersTitle.Size = new Size(90, 25);
            m_LabelPlayersTitle.Text = "Players:";

            m_LabelPlayerOneTitle.Location = new Point(58, 145);
            m_LabelPlayerOneTitle.Size = new Size(97, 25);
            m_LabelPlayerOneTitle.Text = "Player 1:";

            m_TextBoxPlayerOne.Location = new Point(198, 145);
            m_TextBoxPlayerOne.Size = new Size(157, 31);
            m_TextBoxPlayerOne.TextChanged += m_TextBoxPlayerOne_TextChanged;

            m_CheckBoxPlayerTwo.Location = new Point(63, 210);
            m_CheckBoxPlayerTwo.Size = new Size(129, 29);
            m_CheckBoxPlayerTwo.Text = "Player 2:";
            m_CheckBoxPlayerTwo.CheckedChanged += m_CheckBoxPlayerTwo_Checked;

            m_TextBoxPlayerTwo.Location = new Point(198, 208);
            m_TextBoxPlayerTwo.Size = new Size(157, 31);
            m_TextBoxPlayerTwo.Text = "[Computer]";
            m_TextBoxPlayerTwo.Enabled = false;
            m_TextBoxPlayerTwo.TextChanged += m_TextBoxPlayerTwo_TextChanged;


            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 400);
            Size = new Size(470, 400);
            Text = "Game Settings";

            FormClosed += GameSettingsForm_Closed;

            Controls.AddRange(new Control[] {m_ButtonDone, m_CheckBoxPlayerTwo, m_LabelBoardSizeTitle,
                                    m_LabelPlayerOneTitle, m_LabelPlayersTitle, m_RadioButtonOpOne,
            m_RadioButtonOpTwo, m_RadioButtonOpThree, m_TextBoxPlayerOne, m_TextBoxPlayerTwo, m_LabelPlayerOneTitle});
        }

        private void GameSettingsForm_Closed(Object sender, EventArgs e)
        {
            if(m_GameConfiguration == null)
            {
               setDefaultGameConfiguration();
            }
        }

        private void setDefaultGameConfiguration()
        {
            m_GameConfiguration = new GameConfiguration();

            m_PlayerOneConfiguration = new PlayerConfiguration();
            m_PlayerOneConfiguration.PlayerType = ePlayerTypes.Human;
            m_PlayerOneConfiguration.PlayerName = "Player 1";
            m_GameConfiguration.AddPlayerConfiguration(m_PlayerOneConfiguration);
            m_GameConfiguration.GameMode = eGameModes.OnePlayerGame;
            m_GameConfiguration.BoardSize = 6;

        }

        private void m_RadioButtonOpOne_Checked(Object sender,EventArgs e)
        {
            m_BoardSize = BusinessLogic.GlobalDefines.Rs_AllowedBoardSizes[0];
        }

        private void m_RadioButtonOpTwo_Checked(Object sender, EventArgs e)
        {
            m_BoardSize = m_GameConfiguration.BoardSize = BusinessLogic.GlobalDefines.Rs_AllowedBoardSizes[1];
        }

        private void m_RadioButtonOpThree_Checked(Object sender, EventArgs e)
        {
            m_BoardSize = m_GameConfiguration.BoardSize = BusinessLogic.GlobalDefines.Rs_AllowedBoardSizes[2];
        }

        private void m_TextBoxPlayerOne_TextChanged(Object sender, EventArgs e)
        {
            if(m_PlayerOneConfiguration == null)
            {
                m_PlayerOneConfiguration = new PlayerConfiguration();
                m_PlayerOneConfiguration.PlayerType = ePlayerTypes.Human;
                
            }

            m_PlayerOneConfiguration.PlayerName = (sender as TextBox).Text;
        }

        private void m_CheckBoxPlayerTwo_Checked(Object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            { 
                m_TextBoxPlayerTwo.Enabled = true;
            }
            else
            {
                m_TextBoxPlayerTwo.Enabled = false;
                m_PlayerTwoConfiguration = null;
            }
        }

        private void m_TextBoxPlayerTwo_TextChanged(Object sender, EventArgs e)
        {
            if(m_PlayerTwoConfiguration == null)
            {
                m_PlayerTwoConfiguration = new PlayerConfiguration();
            }

            m_PlayerTwoConfiguration.PlayerName = (sender as TextBox).Text;
            m_PlayerTwoConfiguration.PlayerType = ePlayerTypes.Human;

        }

        private void m_ButtonDone_Clicked(Object sender, EventArgs e)
        {
            m_GameConfiguration = createGameConfiguration();

            if(m_GameConfiguration != null)
            {
                Close();
            }
        }

        private GameConfiguration createGameConfiguration()
        {
            GameConfiguration gameConfiguration = new GameConfiguration();

            if(m_PlayerOneConfiguration == null)
            {
                m_PlayerOneConfiguration = new PlayerConfiguration();
                m_PlayerOneConfiguration.PlayerName = "Player 1";
                m_PlayerOneConfiguration.PlayerType = ePlayerTypes.Human;
            }

            else if(m_PlayerOneConfiguration.PlayerName == "")
            {
                MessageBox.Show("Invalid Player's name for Player No. 1: please insert name for this player...");
                gameConfiguration = null;
            }

            if(m_PlayerTwoConfiguration != null && m_PlayerTwoConfiguration.PlayerName == "")
            {
                MessageBox.Show("Invalid Player's name for Player No. 2: please insert name for this player...");
                gameConfiguration = null;
            }
            else
            {
                gameConfiguration = new GameConfiguration();
                gameConfiguration.AddPlayerConfiguration(m_PlayerOneConfiguration);
                gameConfiguration.GameMode = setGameMode(); //add computer player if the game mode is OnePlayerMode
                if (gameConfiguration.GameMode == eGameModes.TwoPlayersGame)
                {
                    gameConfiguration.AddPlayerConfiguration(m_PlayerTwoConfiguration);
                }
                gameConfiguration.BoardSize = m_BoardSize;
            }

            return gameConfiguration;
        }

        private eGameModes setGameMode()
        {
            eGameModes gameMode;
            
            if(m_PlayerTwoConfiguration == null)
            {
                gameMode = eGameModes.OnePlayerGame;
            }
            else
            {
                gameMode = eGameModes.TwoPlayersGame;
            }

            return gameMode;
        }

    }
}

﻿using System;
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
    class GameSettingsForm : Form
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
        private GameConfiguration m_GameConfiguration = new GameConfiguration();
      

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

        private void initializeComponents()
        {
            m_ButtonDone.Location = new Point(316, 275);
            m_ButtonDone.Size = new Size(120, 49);
            m_ButtonDone.Text = "Done";

            m_LabelBoardSizeTitle.Location = new Point(20, 13);
            m_LabelBoardSizeTitle.Size = new Size(123, 25);
            m_LabelBoardSizeTitle.Text = "Board Size:";

            m_RadioButtonOpOne.Location = new Point(32, 50);
            m_RadioButtonOpOne.Size = new Size(90, 29);
            m_RadioButtonOpOne.Text = "6 x 6";
            m_RadioButtonOpOne.Click += m_RadioButtonOpOne_Checked;

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

            m_CheckBoxPlayerTwo.Location = new Point(63, 210);
            m_CheckBoxPlayerTwo.Size = new Size(129, 29);
            m_CheckBoxPlayerTwo.Text = "Player 2:";

            m_TextBoxPlayerTwo.Location = new Point(198, 208);
            m_TextBoxPlayerTwo.Size = new Size(157, 31);
            m_TextBoxPlayerTwo.Text = "[Computer]";
            m_TextBoxPlayerTwo.Enabled = false;

            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(470, 400);
            Size = new Size(470, 400);
            Text = "Game Settings";

            Controls.AddRange(new Control[] {m_ButtonDone, m_CheckBoxPlayerTwo, m_LabelBoardSizeTitle,
                                    m_LabelPlayerOneTitle, m_LabelPlayersTitle, m_RadioButtonOpOne,
            m_RadioButtonOpTwo, m_RadioButtonOpThree, m_TextBoxPlayerOne, m_TextBoxPlayerTwo, m_LabelPlayerOneTitle});
        }

        private void m_RadioButtonOpOne_Checked(Object sender,EventArgs e)
        {
            m_GameConfiguration.BoardSize = BusinessLogic.GlobalDefines.Rs_AllowedBoardSizes[0];
        }

        private void m_RadioButtonOpTwo_Checked(Object sender, EventArgs e)
        {
            m_GameConfiguration.BoardSize = BusinessLogic.GlobalDefines.Rs_AllowedBoardSizes[1];
        }

        private void m_RadioButtonOpThree_Checked(Object sender, EventArgs e)
        {
            m_GameConfiguration.BoardSize = BusinessLogic.GlobalDefines.Rs_AllowedBoardSizes[2];
        }

        private void m_TextBoxPlayerOne_TextChanged(Object sender, EventArgs e)
        {
            PlayerConfiguration playerOneConfiguration = new PlayerConfiguration();

            playerOneConfiguration.PlayerName = (sender as TextBox).Text;
            playerOneConfiguration.PlayerType = ePlayerTypes.Human;
            m_GameConfiguration.AddPlayerConfiguration(playerOneConfiguration);
            m_GameConfiguration.GameMode = eGameModes.OnePlayerGame;
        }

        private void m_CheckBoxPlayerTwo_Checked(Object sender, EventArgs e)
        {
            m_GameConfiguration.GameMode = eGameModes.TwoPlayersGame;
        }

        private void m_TextBoxPlayerTwo_TextChanged(Object sender, EventArgs e)
        {
            PlayerConfiguration playerTwoConfiguration = new PlayerConfiguration();

            playerTwoConfiguration.PlayerName = (sender as TextBox).Text;
            playerTwoConfiguration.PlayerType = ePlayerTypes.Human;
            m_GameConfiguration.AddPlayerConfiguration(playerTwoConfiguration);
           
        }
    }
}

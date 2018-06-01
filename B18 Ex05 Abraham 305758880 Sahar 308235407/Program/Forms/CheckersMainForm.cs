using BusinessLogic;
using BusinessLogic.Configuration;
using BusinessLogic.GameBoard;
using CheckersWindowApp.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Program.Forms
{
    public class CheckersMainForm:Form
    {
        private readonly Point k_BoardStartPoint = new Point(22, 112); 
        private const int k_ButtonSize = 40;
        private readonly Color k_ButtonColor = Color.White;

        private GameManager m_GameManager;
        private Button [,] m_ButtonsBoard;

        private Label Player1Name;
        private Label Player2Name;
        private Label Player1Score;
        private Label Player2Score;

        private void InitializeComponent()
        {
            this.Player1Name = new System.Windows.Forms.Label();
            this.Player2Name = new System.Windows.Forms.Label();
            this.Player1Score = new System.Windows.Forms.Label();
            this.Player2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Player1Name
            // 
            this.Player1Name.AutoSize = true;
            this.Player1Name.Location = new System.Drawing.Point(22, 13);
            this.Player1Name.Name = "Player1Name";
            this.Player1Name.Size = new System.Drawing.Size(64, 17);
            this.Player1Name.TabIndex = 0;
            this.Player1Name.Text = "Player1: ";
            // 
            // Player2Name
            // 
            this.Player2Name.AutoSize = true;
            this.Player2Name.Location = new System.Drawing.Point(22, 51);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(64, 17);
            this.Player2Name.TabIndex = 1;
            this.Player2Name.Text = "Player2: ";
            // 
            // Player1Score
            // 
            this.Player1Score.AutoSize = true;
            this.Player1Score.Location = new System.Drawing.Point(92, 13);
            this.Player1Score.Name = "Player1Score";
            this.Player1Score.Size = new System.Drawing.Size(28, 17);
            this.Player1Score.TabIndex = 2;
            this.Player1Score.Text = "0:0";
            // 
            // Player2Score
            // 
            this.Player2Score.AutoSize = true;
            this.Player2Score.Location = new System.Drawing.Point(92, 51);
            this.Player2Score.Name = "Player2Score";
            this.Player2Score.Size = new System.Drawing.Size(28, 17);
            this.Player2Score.TabIndex = 3;
            this.Player2Score.Text = "0:0";
            // 
            // CheckersMainForm
            // 
            this.ClientSize = new System.Drawing.Size(503, 383);
            this.Controls.Add(this.Player2Score);
            this.Controls.Add(this.Player1Score);
            this.Controls.Add(this.Player2Name);
            this.Controls.Add(this.Player1Name);
            this.Name = "CheckersMainForm";
            this.Load += new System.EventHandler(this.CheckersMainForm_Load);
            this.Shown += new System.EventHandler(this.CheckersMainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CheckersMainForm_Load(object sender, EventArgs e)
        {
            GameSettingsForm gameSettingsForm = new GameSettingsForm();

            gameSettingsForm.ShowDialog();
            //todo: get the game configuration from the game settings form
            initializeGameSettings(null);
            buildBoard();
        }

        private void CheckersMainForm_Shown(object sender, EventArgs e)
        {
            m_GameManager.StartGame();
        }

        private void initializeGameSettings(GameConfiguration i_GameConfiguration)
        {
            m_GameManager = new GameManager();
            m_GameManager.InitializeGame(i_GameConfiguration);
        }

        private void buildBoard()
        {
            m_ButtonsBoard = new Button[m_GameManager.BoardSize, m_GameManager.BoardSize];
            for (int cellRow = 0; cellRow < m_GameManager.BoardSize; cellRow++)
            {
                for (int cellColumn = 0; cellColumn < m_GameManager.BoardSize; cellColumn++)
                {
                    Button boardButton = createButtonByCell(cellRow, cellColumn, m_GameManager.Board[cellRow, cellColumn]);
                    m_ButtonsBoard[cellRow, cellColumn] = boardButton;
                    Controls.Add(boardButton);
                }
            }
        }

        private Button createButtonByCell(int rowIndex,int colIndex,Cell boardCell)
        {
            Button boardButton = new Button();

            boardButton.Size = new Size(k_ButtonSize, k_ButtonSize);
            boardButton.BackColor = k_ButtonColor;
            boardButton.Location = new Point(k_BoardStartPoint.X + colIndex * k_ButtonSize, k_BoardStartPoint.Y + rowIndex * k_ButtonSize);
            boardButton.Click += BoardButton_Click;
            boardButton.Enabled = boardCell.IsEnabled;

            if(!boardCell.IsCellEmpty())
            {
                Soldier soldier = boardCell.Soldier;
                boardButton.Text = GlobalDefines.GetSoldierSign(soldier.Owner, soldier.SoldierType).ToString();
            }

            return boardButton;
        }

        private void BoardButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

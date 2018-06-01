using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Configuration;
using BusinessLogic.GameBoard;
using Program.CustomControllers;
using BusinessLogic.Dtos;

namespace CheckersWindowApp.Forms
{
    public class CheckersMainForm : Form
    {
        private const int k_ButtonSize = 40;
        private readonly Point k_BoardStartPoint = new Point(70, 112);
        private readonly Color k_EnabledButtonColor = Color.White;
        private readonly Color k_DisabledButtonColor = Color.DarkGray;
        private readonly Color k_SelectedButtonColor = Color.LightBlue;

        private GameManager m_GameManager;
        private CellButton[,] m_ButtonsBoard;
        private CellButton m_CellSelection1;
        private CellButton m_CellSelection2;

        private Label Player1Name;
        private Label Player2Name;
        private Label Player1Score;
        private Label Player2Score;

        public CheckersMainForm()
        {
            InitializeComponent();
        }

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
            this.Player1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Player1Name.Location = new System.Drawing.Point(22, 13);
            this.Player1Name.Name = "Player1Name";
            this.Player1Name.Size = new System.Drawing.Size(89, 25);
            this.Player1Name.TabIndex = 0;
            this.Player1Name.Text = "Player1: ";
            // 
            // Player2Name
            // 
            this.Player2Name.AutoSize = true;
            this.Player2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Player2Name.Location = new System.Drawing.Point(22, 51);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(89, 25);
            this.Player2Name.TabIndex = 1;
            this.Player2Name.Text = "Player2: ";
            // 
            // Player1Score
            // 
            this.Player1Score.AutoSize = true;
            this.Player1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Player1Score.Location = new System.Drawing.Point(117, 13);
            this.Player1Score.Name = "Player1Score";
            this.Player1Score.Size = new System.Drawing.Size(23, 25);
            this.Player1Score.TabIndex = 2;
            this.Player1Score.Text = "0";
            // 
            // Player2Score
            // 
            this.Player2Score.AutoSize = true;
            this.Player2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Player2Score.Location = new System.Drawing.Point(117, 51);
            this.Player2Score.Name = "Player2Score";
            this.Player2Score.Size = new System.Drawing.Size(23, 25);
            this.Player2Score.TabIndex = 3;
            this.Player2Score.Text = "0";
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

            GameConfiguration config = new GameConfiguration();
            config.BoardSize = 10;
            config.GameMode = BusinessLogic.Enums.eGameModes.TwoPlayersGame;
            config.AddPlayerConfiguration(new PlayerConfiguration { PlayerName = "avi", PlayerType = BusinessLogic.Enums.ePlayerTypes.Human });
            config.AddPlayerConfiguration(new PlayerConfiguration { PlayerName = "sahar", PlayerType = BusinessLogic.Enums.ePlayerTypes.Computer });
            initializeGameSettings(config);
            setPlayersNames(config);
        }

        private void CheckersMainForm_Shown(object sender, EventArgs e)
        {
            m_GameManager.StartGame();
            buildBoard();
            updateWindowSize();
        }

        private void updateWindowSize()
        {
            int boardSize = m_ButtonsBoard.GetLength(1);
            int windowSize = (boardSize * k_ButtonSize) + ((boardSize * k_ButtonSize) / 2);

            ClientSize = new Size(windowSize, windowSize);
        }

        private void initializeGameSettings(GameConfiguration i_GameConfiguration)
        {
            m_GameManager = new GameManager();
            m_GameManager.InitializeGame(i_GameConfiguration);
            m_GameManager.BoardChanged += GameManager_BoardChanged;
            m_GameManager.GameEnded += GameManager_GameEnded;
        }

        private void buildBoard()
        {
            m_ButtonsBoard = new CellButton[m_GameManager.BoardSize, m_GameManager.BoardSize];
            for (int cellRow = 0; cellRow < m_GameManager.BoardSize; cellRow++)
            {
                for (int cellColumn = 0; cellColumn < m_GameManager.BoardSize; cellColumn++)
                {
                    CellButton boardButton = createButtonByCell(cellRow, cellColumn, m_GameManager.Board[cellRow, cellColumn]);
                    m_ButtonsBoard[cellRow, cellColumn] = boardButton;
                    Controls.Add(boardButton);
                }
            }
        }

        private void setPlayersNames(GameConfiguration i_GameConfiguration)
        {
            Player1Name.Text = i_GameConfiguration.PlayerConfigurations[0].PlayerName + ":";
            Player2Name.Text = i_GameConfiguration.PlayerConfigurations[1].PlayerName + ":";
        }

        public void updateBoard()
        {
            for (int cellRow = 0; cellRow < m_GameManager.BoardSize; cellRow++)
            {
                for (int cellColumn = 0; cellColumn < m_GameManager.BoardSize; cellColumn++)
                {
                    Cell boardCell = m_GameManager.Board[cellRow, cellColumn];

                    if (!boardCell.IsCellEmpty())
                    {
                        Soldier soldier = boardCell.Soldier;
                        m_ButtonsBoard[cellRow, cellColumn].Text = GlobalDefines.GetSoldierSign(soldier.Owner, soldier.SoldierType).ToString();
                    }
                    else
                    {
                        m_ButtonsBoard[cellRow, cellColumn].Text = string.Empty;
                    }
                }
            }
        }

        private CellButton createButtonByCell(int rowIndex, int colIndex, Cell boardCell)
        {
            CellButton boardButton = new CellButton(rowIndex, colIndex);

            boardButton.Size = new Size(k_ButtonSize, k_ButtonSize);
            boardButton.BackColor = k_EnabledButtonColor;
            boardButton.Location = new Point(k_BoardStartPoint.X + (colIndex * k_ButtonSize), k_BoardStartPoint.Y + (rowIndex * k_ButtonSize));
            boardButton.Click += BoardButton_Click;
            boardButton.Enabled = boardCell.IsEnabled;
            if (!boardButton.Enabled)
            {
                boardButton.BackColor = k_DisabledButtonColor;
            }

            if (!boardCell.IsCellEmpty())
            {
                Soldier soldier = boardCell.Soldier;
                boardButton.Text = GlobalDefines.GetSoldierSign(soldier.Owner, soldier.SoldierType).ToString();
            }

            return boardButton;
        }

        private void BoardButton_Click(object sender, EventArgs e)
        {
            CellButton selectedCell = sender as CellButton;

            if (m_CellSelection1 == null || selectedCell == m_CellSelection1)
            {
                handleFirstCellSelection(selectedCell);
            }
            else if (m_CellSelection1 != null && m_CellSelection2 == null)
            {
                handleSecondCellSelection(selectedCell);
            }

            if (m_CellSelection1 != null && m_CellSelection2 != null)
            {
                ActionResult moveResult = m_GameManager.HandlePlayerAction(convertSelectionToAction());
                if (!moveResult.IsSucceed)
                {
                    MessageBox.Show(moveResult.Message, "Invalid move", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                clearCellSelections();
            }
        }

        private void handleFirstCellSelection(CellButton i_SelectedCell)
        {
            Cell[,] gameBoard = m_GameManager.Board;

            if (gameBoard[i_SelectedCell.RowIndex, i_SelectedCell.ColumnIndex].IsCellEmpty())
            {
                MessageBox.Show("You cant choose an empty cell!", "Invalid choice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearCellSelections();
            }
            else if (gameBoard[i_SelectedCell.RowIndex, i_SelectedCell.ColumnIndex].Soldier.Owner != m_GameManager.GetCurrentPlayerTurn().PlayerTitle)
            {
                MessageBox.Show("You cant choose the opponent soldier!", "Invalid choice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearCellSelections();
            }
            else if (i_SelectedCell == m_CellSelection1)
            {
                clearCellSelections();
            }
            else
            {
                m_CellSelection1 = i_SelectedCell;
                i_SelectedCell.BackColor = k_SelectedButtonColor;
            }
        }

        private void handleSecondCellSelection(CellButton i_SelectedCell)
        {
            Cell[,] gameBoard = m_GameManager.Board;

            if (!gameBoard[i_SelectedCell.RowIndex, i_SelectedCell.ColumnIndex].IsCellEmpty())
            {
                MessageBox.Show("You cant choose non empty cell", "Invalid choice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearCellSelections();
            }
            else
            {
                m_CellSelection2 = i_SelectedCell;
                i_SelectedCell.BackColor = k_SelectedButtonColor;
            }
        }

        private void clearCellSelections()
        {
            if (m_CellSelection1 != null)
            {
                m_CellSelection1.BackColor = k_EnabledButtonColor;
                m_CellSelection1 = null;
            }

            if (m_CellSelection2 != null)
            {
                m_CellSelection2.BackColor = k_EnabledButtonColor;
                m_CellSelection2 = null;
            }
        }

        private string convertSelectionToAction()
        {
            string action = string.Format("{0}{1}>{2}{3}", parseColumnIndexToChar(m_CellSelection1.ColumnIndex), parseRowIndexToChar(m_CellSelection1.RowIndex), parseColumnIndexToChar(m_CellSelection2.ColumnIndex), parseRowIndexToChar(m_CellSelection2.RowIndex));

            return action;
        }

        private char parseRowIndexToChar(int i_RowIndex)
        {
            return (char)('a' + i_RowIndex);
        }

        private char parseColumnIndexToChar(int i_ColumnIndex)
        {
            return (char)('A' + i_ColumnIndex);
        }

        private void updatePlayerScore(GameSummery i_GameSummery)
        {
            if (i_GameSummery.WinnerTitle == BusinessLogic.Enums.ePlayerTitles.PlayerOne)
            {
                Player1Score.Text = i_GameSummery.Score.ToString();
            }
            else if (i_GameSummery.WinnerTitle == BusinessLogic.Enums.ePlayerTitles.PlayerTwo)
            {
                Player2Score.Text = i_GameSummery.Score.ToString();
            }
        }

        private void restartGame()
        {
            clearCellSelections();
            m_GameManager.StartGame();
            updateBoard();
        }

        private void exitGame()
        {
            Close();
        }

        private void GameManager_GameEnded()
        {
            GameSummery gameSummery = m_GameManager.GetGameSummery();
            DialogResult dialogResult;
            StringBuilder msgBuilder = new StringBuilder();

            updatePlayerScore(gameSummery);
            if (gameSummery.EndGameState == BusinessLogic.Enums.eGameStatus.Tie)
            {
                msgBuilder.Append(string.Format("Tie! {0}", Environment.NewLine));
            }
            else
            {
                msgBuilder.Append(string.Format("{0} won!{1}", gameSummery.WinnerName, Environment.NewLine));
            }

            msgBuilder.Append("Another round?");
            dialogResult = MessageBox.Show(msgBuilder.ToString(), "Damka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                restartGame();
            }
            else
            {
                exitGame();
            }
        }

        private void GameManager_BoardChanged()
        {
            updateBoard();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program.Forms
{
    class GameSettingsForm : Form
    {
        Label m_LabelBoardSizeTitle = new Label();
        Label m_LabelBoardSizeOpOne = new Label();
        Label m_LabelBoardSizeOpTwo = new Label();
        Label m_LabelBoardSizeOpThree = new Label();
        Label m_LabelPlayersTitle = new Label();
        Label m_LabelPlayerOne = new Label();
        Label m_LabelPlayerTwo = new Label();
        RadioButton m_RadioButtonBoardSizeOpOne = new RadioButton();
        RadioButton m_RadioButtonBoardSizeOpTwo = new RadioButton();
        RadioButton m_RadioButtonBoardSizeOpThree = new RadioButton();
        TextBox m_TextBoxPlayerOne = new TextBox();
        CheckBox m_CheckBoxPlayerTwo = new CheckBox();

        public GameSettingsForm()
        {
            this.Size = new Size(500, 500);
            this.Text = "Game Settings";
            initComponents();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

           
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
           
        }   

        private void initComponents()
        {
            m_LabelBoardSizeTitle.Text = "Board size:";
            m_LabelBoardSizeTitle.Location = new Point(10, 20);

            m_RadioButtonBoardSizeOpOne.Location = new Point(15, 22);
            m_LabelBoardSizeOpOne.Text = "6 x 6";
            m_LabelBoardSizeOpOne.Location = new Point(15, 24);

            m_RadioButtonBoardSizeOpTwo.Location = new Point(15, 28);
            m_LabelBoardSizeOpTwo.Text = "8 x 8";
            m_LabelBoardSizeOpOne.Location = new Point(15, 30);

            m_RadioButtonBoardSizeOpOne.Location = new Point(15, 32);
            m_LabelBoardSizeOpThree.Text = "10 x 10";
            m_LabelBoardSizeOpOne.Location = new Point(15, 36);

            m_LabelPlayersTitle.Text = "Players:";
            m_LabelPlayersTitle.Location = new Point(18, 20);
            m_LabelPlayerOne.Text = "Player 1:";
            m_LabelPlayerOne.Location = new Point(20, 22);
            m_TextBoxPlayerOne.Location = new Point(20, 25);
            m_CheckBoxPlayerTwo.Location = new Point(22, 22);
            m_LabelPlayerTwo.Text = "Player 2:";
            
            


        }
    }
}

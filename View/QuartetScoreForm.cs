using System;
using System.Windows.Forms;
using System.Linq;
using OOP.Controller;

namespace OOP.View {
    public class QuartetScoreForm : Form {
        private TextBox txtQuartetName;
        private NumericUpDown numMusScore, numPerScore, numSngScore;
        private Button btnAdd, btnExit;
        private ListBox lstScores;
        private ComboBox cmbQuartets;
        private QuartetScoreController controller;

        public QuartetScoreForm() {
            controller = new QuartetScoreController();
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            PopulateScores();
        }

        // Adds UI components

        private void InitializeComponent() {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            // Makes the form
            this.Size = new System.Drawing.Size(600, 600);

            // Creates a TextBox for Quartet Name
            txtQuartetName = new TextBox { Location = new System.Drawing.Point(20, 20), Width = 200 };
            Controls.Add(txtQuartetName);

            // Creates a NumericUpDown for Musicality Score
            numMusScore = new NumericUpDown { Location = new System.Drawing.Point(20, 50), Width = 50 };
            Controls.Add(numMusScore);

            // Creates a NumericUpDown for Performance Score
            numPerScore = new NumericUpDown { Location = new System.Drawing.Point(20, 80), Width = 50 };
            Controls.Add(numPerScore);

            // Creates a NumericUpDown for Singing Score
            numSngScore = new NumericUpDown { Location = new System.Drawing.Point(20, 110), Width = 50 };
            Controls.Add(numSngScore);

            // Creates a Button for AddOrUpdateScore function
            btnAdd = new Button { Text = "Add/Update", Location = new System.Drawing.Point(20, 140), Width = 100 };
            btnAdd.Click += new EventHandler(AddOrUpdateScore);
            Controls.Add(btnAdd);

            // Creates a ListBox for displaying the scores
            lstScores = new ListBox { Location = new System.Drawing.Point(20, 170), Width = 500, Height = 200 };
            Controls.Add(lstScores);

            // Creates a ComboBox for selecting an existing quartet
            cmbQuartets = new ComboBox { Location = new System.Drawing.Point(20, 380), Width = 200 };
            cmbQuartets.SelectedIndexChanged += new EventHandler(ComboBoxSelectedIndexChanged);
            Controls.Add(cmbQuartets);

            // Creates a Button for exiting the program
            btnExit = new Button { Text = "Exit", Location = new System.Drawing.Point(20, 410), Width = 100 };
            btnExit.Click += new EventHandler(ExitButtonClick);
            Controls.Add(btnExit);

            // Creates a label for quartet name
            Label lblQuartetName = new Label();
            lblQuartetName.Text = "Quartet Name";
            lblQuartetName.Location = new System.Drawing.Point(txtQuartetName.Location.X + 220, 20);
            lblQuartetName.AutoSize = true;
            Controls.Add(lblQuartetName);

            // Creates a label for Musicality Score
            Label lblMusScore = new Label();
            lblMusScore.Text = "Musicality Score";
            lblMusScore.Location = new System.Drawing.Point(numMusScore.Location.X + 80, 50);
            lblMusScore.AutoSize = true;
            Controls.Add(lblMusScore);

            // Creates a label for Performance Score
            Label lblPerScore = new Label();
            lblPerScore.Text = "Performance Score";
            lblPerScore.Location = new System.Drawing.Point(numPerScore.Location.X + 80, 80);
            lblPerScore.AutoSize = true;
            Controls.Add(lblPerScore);

            // Creates a label for Singing Score
            Label lblSngScore = new Label();
            lblSngScore.Text = "Singing Score";
            lblSngScore.Location = new System.Drawing.Point(numSngScore.Location.X + 80, 110);
            lblSngScore.AutoSize = true;
            Controls.Add(lblSngScore);
        }

        // Event Listeners and functions for form

        private void AddOrUpdateScore(object sender, EventArgs e) {
            string name = txtQuartetName.Text;
            
            // Check if the name textbox is empty
            if (string.IsNullOrWhiteSpace(name)) {
                    MessageBox.Show("Please enter a quartet name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            int mus = (int)numMusScore.Value;
            int per = (int)numPerScore.Value;
            int sng = (int)numSngScore.Value;

            // Checks if a quartet with this name already exists
            var existingScore = controller.GetScoreByName(name);
            if (existingScore != null) {
                // Asks the user if they want to modify the quartet
                var result = MessageBox.Show("A score with this name already exists. Do you want to update it?", "Score Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes) {
                    controller.AddOrUpdateScore(name, mus, per, sng);
                    PopulateScores();
                    ClearInputs();
                } else {
                    MessageBox.Show("Operation canceled. To add a new score, please use a unique name.", "Operation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                controller.AddOrUpdateScore(name, mus, per, sng);
                PopulateScores();
                ClearInputs();
            }
        }

        private void ExitButtonClick(object sender, EventArgs e) {
            this.Close();
        }

        private void PopulateScores() {
            lstScores.Items.Clear();
            cmbQuartets.Items.Clear();

            foreach (var score in controller.GetAllScores()) {
                lstScores.Items.Add(score.ToString());
                cmbQuartets.Items.Add(score.QuartetName);
            }
        }

        private void ClearInputs() {
            txtQuartetName.Clear();
            numMusScore.Value = 0;
            numPerScore.Value = 0;
            numSngScore.Value = 0;
        }
        
        // Event handler for when an item is selected from the ComboBox
        private void ComboBoxSelectedIndexChanged(object sender, EventArgs e) {
            string selectedName = cmbQuartets.SelectedItem.ToString();
            var score = controller.GetScoreByName(selectedName);

            if (score != null) {
                txtQuartetName.Text = score.QuartetName;
                numMusScore.Value = score.MusScore;
                numPerScore.Value = score.PerScore;
                numSngScore.Value = score.SngScore;
            }
        }
    }
}
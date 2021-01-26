using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constr
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }
        #endregion
        #region Private Members
        private MarkType[] mResults;
        private bool mPlayer1Turn;
        private bool mGameEnded;

        #endregion

        private void NewGame()
        {
            //Array of Free Cells
            mResults = new MarkType[9];
            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;

            mPlayer1Turn = true;
            // Button Iteration
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Gray;

            } );

            mGameEnded = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEnded)
            {
                NewGame();
                return;
            }
            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 3);

            if (mResults[index] != MarkType.Free)
                return;
            //if mPlayer 1 is true (cross) if false O
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;
            button.Content = mPlayer1Turn ? "x" : "o";
            if (!mPlayer1Turn)
                button.Foreground = Brushes.Green;
                mPlayer1Turn ^= true; // Flipping Values from true to false and vice versa
            Console.WriteLine("Check Winner");
            CheckWinner();
            
        }

        private void CheckWinner()
        {
            // var same = mResults[0] && mResults[1] && mResults[2] == mResults[0];
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
                mGameEnded = true;
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
                mGameEnded = true;
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
                mGameEnded = true;
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
                mGameEnded = true;
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
                mGameEnded = true;
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
                mGameEnded = true;
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
                mGameEnded = true;
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[4] & mResults[2]) == mResults[6])
                mGameEnded = true;

        }
    }
}

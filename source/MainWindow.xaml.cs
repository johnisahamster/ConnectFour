using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Connect4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<List<int>> Board = new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0},
            new List<int>() { 0, 0, 0, 0, 0, 0, 0},
            new List<int>() { 0, 0, 0, 0, 0, 0, 0},
            new List<int>() { 0, 0, 0, 0, 0, 0, 0},
            new List<int>() { 0, 0, 0, 0, 0, 0, 0},
            new List<int>() { 0, 0, 0, 0, 0, 0, 0}
        };
        public static int currentPlayer = 1; //Toggles between 1 and 2
        public static int winner; // "
        public static bool singlePlayer;
        
        public static void DropToken(int column_number)
        {
            for(int row_number = 5; row_number >= 0; row_number--)
            {
                if(Board[row_number][column_number] == 0)
                {
                    Board[row_number][column_number] = currentPlayer;
                    return;
                }
            }
        } //Changes one of the spaces on "Board" relative to column number
        private void SwitchPlayers()
        {
            currentPlayer = (currentPlayer == 1) ? 2 : 1;
            Player_Textblock.Text = (currentPlayer == 1) ? "Current Player: Player 1" : "Current Player: Player 2";
        } //Toggles currentPlayer
        private bool CheckWin()
        {
            //Check up-down
            for(int row_i = 0; row_i < 3; row_i++)
            {
                for(int column_i = 0; column_i < 7; column_i++)
                {
                    if(Board[row_i][column_i] == currentPlayer)
                    {
                        if(Board[row_i + 1][column_i] == currentPlayer && Board[row_i + 2][column_i] == currentPlayer && Board[row_i + 3][column_i] == currentPlayer)
                        {
                            winner = currentPlayer;
                            return true;
                        }
                    }
                }
            }
            //Check left-right
            for (int row_i = 0; row_i < 6; row_i++)
            {
                for (int column_i = 0; column_i < 4; column_i++)
                {
                    if (Board[row_i][column_i] == currentPlayer)
                    {
                        if (Board[row_i][column_i + 1] == currentPlayer && Board[row_i][column_i + 2] == currentPlayer && Board[row_i][column_i + 3] == currentPlayer)
                        {
                            winner = currentPlayer;
                            return true;
                        }
                    }
                }
            }
            //Check left-down right-up
            for (int row_i = 3; row_i < 6; row_i++)
            {
                for (int column_i = 0; column_i < 4; column_i++)
                {
                    if (Board[row_i][column_i] == currentPlayer)
                    {
                        if (Board[row_i - 1][column_i + 1] == currentPlayer && Board[row_i - 2][column_i + 2] == currentPlayer && Board[row_i - 3][column_i + 3] == currentPlayer)
                        {
                            winner = currentPlayer;
                            return true;
                        }
                    }
                }
            }
            //Check right-down left-up
            for (int row_i = 0; row_i < 3; row_i++)
            {
                for (int column_i = 0; column_i < 4; column_i++)
                {
                    if (Board[row_i][column_i] == currentPlayer)
                    {
                        if (Board[row_i + 1][column_i + 1] == currentPlayer && Board[row_i + 2][column_i + 2] == currentPlayer && Board[row_i + 3][column_i + 3] == currentPlayer)
                        {
                            winner = currentPlayer;
                            return true;
                        }
                    }
                }
            }
            //If all else fails
            return false;
        } //Returns bool and changes winner var to currentPlayer
        private void EndGame()
        {
            b0.IsEnabled = false;
            b1.IsEnabled = false;
            b2.IsEnabled = false;
            b3.IsEnabled = false;
            b4.IsEnabled = false;
            b5.IsEnabled = false;
            b6.IsEnabled = false;
            MessageBox.Show("Player " + winner + " Wins!");
        } //"We're in the endgame now."
        private void ResetGame()
        {
            currentPlayer = 1;
            for(int row = 0; row < Board.Count; row++)
            {
                for(int column = 0; column < Board[0].Count; column++)
                {
                    Board[row][column] = 0;
                }
            }
            ButtonToggle(true);
            UpdatePics();
        } //New Game
        private void ButtonToggle(bool toggle)
        {
            b0.IsEnabled = toggle;
            b1.IsEnabled = toggle;
            b2.IsEnabled = toggle;
            b3.IsEnabled = toggle;
            b4.IsEnabled = toggle;
            b5.IsEnabled = toggle;
            b6.IsEnabled = toggle;
        }

        public static string[] pics = System.IO.Directory.GetFiles(@".\Resources\"); //Gets directories as strings
        private List<BitmapImage> tokenImages = new List<BitmapImage>()
        {
            new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, pics[0]))),
            new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, pics[1]))),
            new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, pics[2])))
        }; //Image sources
        private void UpdatePics()
        {
            i00.Source = tokenImages[Board[0][0]];
            i01.Source = tokenImages[Board[0][1]];
            i02.Source = tokenImages[Board[0][2]];
            i03.Source = tokenImages[Board[0][3]];
            i04.Source = tokenImages[Board[0][4]];
            i05.Source = tokenImages[Board[0][5]];
            i06.Source = tokenImages[Board[0][6]];
            i10.Source = tokenImages[Board[1][0]];
            i11.Source = tokenImages[Board[1][1]];
            i12.Source = tokenImages[Board[1][2]];
            i13.Source = tokenImages[Board[1][3]];
            i14.Source = tokenImages[Board[1][4]];
            i15.Source = tokenImages[Board[1][5]];
            i16.Source = tokenImages[Board[1][6]];
            i20.Source = tokenImages[Board[2][0]];
            i21.Source = tokenImages[Board[2][1]];
            i22.Source = tokenImages[Board[2][2]];
            i23.Source = tokenImages[Board[2][3]];
            i24.Source = tokenImages[Board[2][4]];
            i25.Source = tokenImages[Board[2][5]];
            i26.Source = tokenImages[Board[2][6]];
            i30.Source = tokenImages[Board[3][0]];
            i31.Source = tokenImages[Board[3][1]];
            i32.Source = tokenImages[Board[3][2]];
            i33.Source = tokenImages[Board[3][3]];
            i34.Source = tokenImages[Board[3][4]];
            i35.Source = tokenImages[Board[3][5]];
            i36.Source = tokenImages[Board[3][6]];
            i40.Source = tokenImages[Board[4][0]];
            i41.Source = tokenImages[Board[4][1]];
            i42.Source = tokenImages[Board[4][2]];
            i43.Source = tokenImages[Board[4][3]];
            i44.Source = tokenImages[Board[4][4]];
            i45.Source = tokenImages[Board[4][5]];
            i46.Source = tokenImages[Board[4][6]];
            i50.Source = tokenImages[Board[5][0]];
            i51.Source = tokenImages[Board[5][1]];
            i52.Source = tokenImages[Board[5][2]];
            i53.Source = tokenImages[Board[5][3]];
            i54.Source = tokenImages[Board[5][4]];
            i55.Source = tokenImages[Board[5][5]];
            i56.Source = tokenImages[Board[5][6]];
        } //Updates image sources on XAML

        //====================================================================================//

        public MainWindow()
        {
            InitializeComponent();
            UpdatePics();
        }
        private void b0_Click(object sender, RoutedEventArgs e)
        {
            DropToken(0);
            UpdatePics();
            if(CheckWin())
            {
                EndGame();
            }
            else
            {
                SwitchPlayers();
                if (singlePlayer)
                {
                    Jarvis.Go();
                    UpdatePics();
                    if (CheckWin())
                    {
                        EndGame();
                    }
                    SwitchPlayers();
                }
            }
        }
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            DropToken(1);
            UpdatePics();
            if (CheckWin())
            {
                EndGame();
            }
            else
            {
                if (!singlePlayer)
                {
                    SwitchPlayers();
                }
                else
                {
                    SwitchPlayers();
                    if (singlePlayer)
                    {
                        Jarvis.Go();
                        UpdatePics();
                        if (CheckWin())
                        {
                            EndGame();
                        }
                        SwitchPlayers();
                    }
                }
            }
        }
        private void b2_Click(object sender, RoutedEventArgs e)
        {
            DropToken(2);
            UpdatePics();
            if (CheckWin())
            {
                EndGame();
            }
            else
            {
                if (!singlePlayer)
                {
                    SwitchPlayers();
                }
                else
                {
                    SwitchPlayers();
                    if (singlePlayer)
                    {
                        Jarvis.Go();
                        UpdatePics();
                        if (CheckWin())
                        {
                            EndGame();
                        }
                        SwitchPlayers();
                    }
                }
            }
        }
        private void b3_Click(object sender, RoutedEventArgs e)
        {
            DropToken(3);
            UpdatePics();
            if (CheckWin())
            {
                EndGame();
            }
            else
            {
                if (!singlePlayer)
                {
                    SwitchPlayers();
                }
                else
                {
                    SwitchPlayers();
                    if (singlePlayer)
                    {
                        Jarvis.Go();
                        UpdatePics();
                        if (CheckWin())
                        {
                            EndGame();
                        }
                        SwitchPlayers();
                    }
                }
            }
        }
        private void b4_Click(object sender, RoutedEventArgs e)
        {
            DropToken(4);
            UpdatePics();
            if (CheckWin())
            {
                EndGame();
            }
            else
            {
                if (!singlePlayer)
                {
                    SwitchPlayers();
                }
                else
                {
                    SwitchPlayers();
                    if (singlePlayer)
                    {
                        Jarvis.Go();
                        UpdatePics();
                        if (CheckWin())
                        {
                            EndGame();
                        }
                        SwitchPlayers();
                    }
                }
            }
        }
        private void b5_Click(object sender, RoutedEventArgs e)
        {
            DropToken(5);
            UpdatePics();
            if (CheckWin())
            {
                EndGame();
            }
            else
            {
                if (!singlePlayer)
                {
                    SwitchPlayers();
                }
                else
                {
                    SwitchPlayers();
                    if (singlePlayer)
                    {
                        Jarvis.Go();
                        UpdatePics();
                        if (CheckWin())
                        {
                            EndGame();
                        }
                        SwitchPlayers();
                    }
                }
            }
        }
        private void b6_Click(object sender, RoutedEventArgs e)
        {
            DropToken(6);
            UpdatePics();
            if (CheckWin())
            {
                EndGame();
            }
            else
            {
                if (!singlePlayer)
                {
                    SwitchPlayers();
                }
                else
                {
                    SwitchPlayers();
                    if (singlePlayer)
                    {
                        Jarvis.Go();
                        UpdatePics();
                        if (CheckWin())
                        {
                            EndGame();
                        }
                        SwitchPlayers();
                    }
                }
            }
        }

        private void SingleP_Button_Click(object sender, RoutedEventArgs e)
        {
            singlePlayer = true;
            ResetGame();
            Jarvis.JarvisDifficulty = Difficulty_Box.SelectedIndex;
        }
        private void MultiP_Button_Click(object sender, RoutedEventArgs e)
        {
            singlePlayer = false;
            ResetGame();
        }
    }

    class Jarvis
    {
        public static int JarvisDifficulty; // 0 - Easy // 1 - Normal // 2 - Hard //
        public static Random rand = new Random();

        public static void Go()
        {
            //CHECK FOR JARVIS' 3s

            //Check up-down
            for (int row_i = 0; row_i < 4; row_i++)
            {
                for (int column_i = 0; column_i < 7; column_i++)
                {
                    if (MainWindow.Board[row_i][column_i] == 2)
                    {
                        if (MainWindow.Board[row_i + 1][column_i] == 2 && MainWindow.Board[row_i + 2][column_i] == 2)
                        {
                            if(WhereWillDrop(column_i) == row_i - 1)
                            {
                                MainWindow.DropToken(column_i);
                                return;
                            }
                        }
                    }
                }
            }
            //Check left-right
            for (int row_i = 0; row_i < 6; row_i++)
            {
                for (int column_i = 0; column_i < 5; column_i++)
                {
                    if (MainWindow.Board[row_i][column_i] == 2)
                    {
                        if (MainWindow.Board[row_i][column_i + 1] == 2 && MainWindow.Board[row_i][column_i + 2] == 2)
                        {
                            switch(column_i)
                            {
                                case 0:
                                case 4:
                                    if(WhereWillDrop(3) == row_i)
                                    {
                                        MainWindow.DropToken(3);
                                        return;
                                    }
                                    break;
                                default:
                                    if(WhereWillDrop(column_i - 1) == row_i)
                                    {
                                        MainWindow.DropToken(column_i - 1);
                                        return;
                                    }
                                    else if (WhereWillDrop(column_i + 3) == row_i)
                                    {
                                        MainWindow.DropToken(column_i + 3);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            //Check left-down right-up
            for (int row_i = 2; row_i < 6; row_i++)
            {
                for (int column_i = 0; column_i < 5; column_i++)
                {
                    if (MainWindow.Board[row_i][column_i] == 2)
                    {
                        if (MainWindow.Board[row_i - 1][column_i + 1] == 2 && MainWindow.Board[row_i - 2][column_i + 2] == 2)
                        {
                            switch(row_i)
                            {
                                case 2:
                                    if(column_i != 0 && WhereWillDrop(column_i - 1) == 3)
                                    {
                                        MainWindow.DropToken(column_i - 1);
                                        return;
                                    }
                                    break;
                                case 5:
                                    if(column_i != 4 && WhereWillDrop(column_i + 3) == 2) // <-- DO NOT GET RID OF THIS TWO
                                    {
                                        MainWindow.DropToken(column_i + 3);
                                        return;
                                    }
                                    break;
                                default:
                                    switch(column_i)
                                    {
                                        case 0:
                                            if(WhereWillDrop(3) == row_i - 3)
                                            {
                                                MainWindow.DropToken(3);
                                                return;
                                            }
                                            break;
                                        case 4:
                                            if(WhereWillDrop(3) == row_i + 1)
                                            {
                                                MainWindow.DropToken(3);
                                                return;
                                            }
                                            break;
                                        default:
                                            if (WhereWillDrop(column_i + 3) == row_i - 3)
                                            {
                                                MainWindow.DropToken(column_i + 3);
                                                return;
                                            }
                                            else if(WhereWillDrop(column_i - 1) == row_i + 1)
                                            {
                                                MainWindow.DropToken(column_i - 1);
                                                return;
                                            }
                                            break;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            //Check left-up right-down
            for (int row_i = 2; row_i < 6; row_i++)
            {
                for (int column_i = 2; column_i < 7; column_i++)
                {
                    if (MainWindow.Board[row_i][column_i] == 2)
                    {
                        if (MainWindow.Board[row_i - 1][column_i - 1] == 2 && MainWindow.Board[row_i - 2][column_i - 2] == 2)
                        {
                            switch (row_i)
                            {
                                case 2:
                                    if (column_i != 6 && WhereWillDrop(column_i + 1) == 3)
                                    {
                                        MainWindow.DropToken(column_i + 1);
                                        return;
                                    }
                                    break;
                                case 5:
                                    if (column_i != 2 && WhereWillDrop(column_i - 3) == 2) // <-- DO NOT GET RID OF THIS TWO
                                    {
                                        MainWindow.DropToken(column_i - 3);
                                        return;
                                    }
                                    break;
                                default:
                                    switch (column_i)
                                    {
                                        case 2:
                                            if (WhereWillDrop(3) == row_i + 1)
                                            {
                                                MainWindow.DropToken(3);
                                                return;
                                            }
                                            break;
                                        case 6:
                                            if (WhereWillDrop(3) == row_i - 3)
                                            {
                                                MainWindow.DropToken(3);
                                                return;
                                            }
                                            break;
                                        default:
                                            if (WhereWillDrop(column_i - 3) == row_i - 3)
                                            {
                                                MainWindow.DropToken(column_i - 3);
                                                return;
                                            }
                                            else if (WhereWillDrop(column_i + 1) == row_i + 1)
                                            {
                                                MainWindow.DropToken(column_i + 1);
                                                return;
                                            }
                                            break;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }

            //CHECK FOR JARVIS' 2-1s
            if (JarvisDifficulty > 0)
            {
                //Check left-right
                for (int row_i = 0; row_i < 6; row_i++)
                {
                    for (int column_i = 0; column_i < 4; column_i++)
                    {
                        if (MainWindow.Board[row_i][column_i] == 2)
                        {
                            if (MainWindow.Board[row_i][column_i + 1] == 2 && MainWindow.Board[row_i][column_i + 3] == 2)
                            {
                                if (WhereWillDrop(column_i + 2) == row_i)
                                {
                                    MainWindow.DropToken(column_i + 2);
                                    return;
                                }
                            }
                            else if (MainWindow.Board[row_i][column_i + 2] == 2 && MainWindow.Board[row_i][column_i + 3] == 2)
                            {
                                if (WhereWillDrop(column_i + 1) == row_i)
                                {
                                    MainWindow.DropToken(column_i + 1);
                                    return;
                                }
                            }
                        }
                    }
                }
                //Check left-down right-up
                for (int row_i = 3; row_i < 6; row_i++)
                {
                    for (int column_i = 0; column_i < 4; column_i++)
                    {
                        if (MainWindow.Board[row_i][column_i] == 2)
                        {
                            if (MainWindow.Board[row_i - 1][column_i + 1] == 2 && MainWindow.Board[row_i - 3][column_i + 3] == 2)
                            {
                                if (WhereWillDrop(column_i + 2) == row_i - 2)
                                {
                                    MainWindow.DropToken(column_i + 2);
                                    return;
                                }
                            }
                            else if (MainWindow.Board[row_i - 2][column_i + 2] == 2 && MainWindow.Board[row_i - 3][column_i + 3] == 2)
                            {
                                if (WhereWillDrop(column_i + 1) == row_i - 1)
                                {
                                    MainWindow.DropToken(column_i + 1);
                                    return;
                                }
                            }
                        }
                    }
                }
                //Check left-up right-down
                for (int row_i = 3; row_i < 6; row_i++)
                {
                    for (int column_i = 3; column_i < 7; column_i++)
                    {
                        if (MainWindow.Board[row_i][column_i] == 2)
                        {
                            if (MainWindow.Board[row_i - 1][column_i - 1] == 2 && MainWindow.Board[row_i - 3][column_i - 3] == 2)
                            {
                                if (WhereWillDrop(column_i - 2) == row_i - 2)
                                {
                                    MainWindow.DropToken(column_i - 2);
                                    return;
                                }
                            }
                            else if (MainWindow.Board[row_i - 2][column_i - 2] == 2 && MainWindow.Board[row_i - 3][column_i - 3] == 2)
                            {
                                if (WhereWillDrop(column_i - 1) == row_i - 1)
                                {
                                    MainWindow.DropToken(column_i - 1);
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            //CHECK FOR PLAYER's 3s
            if (JarvisDifficulty > 0)
            {
                //Check up-down
                for (int row_i = 0; row_i < 4; row_i++)
                {
                    for (int column_i = 0; column_i < 7; column_i++)
                    {
                        if (MainWindow.Board[row_i][column_i] == 1)
                        {
                            if (MainWindow.Board[row_i + 1][column_i] == 1 && MainWindow.Board[row_i + 2][column_i] == 1)
                            {
                                if (WhereWillDrop(column_i) == row_i - 1)
                                {
                                    MainWindow.DropToken(column_i);
                                    return;
                                }
                            }
                        }
                    }
                }
                //Check left-right
                for (int row_i = 0; row_i < 6; row_i++)
                {
                    for (int column_i = 0; column_i < 5; column_i++)
                    {
                        if (MainWindow.Board[row_i][column_i] == 1)
                        {
                            if (MainWindow.Board[row_i][column_i + 1] == 1 && MainWindow.Board[row_i][column_i + 2] == 1)
                            {
                                switch (column_i)
                                {
                                    case 0:
                                    case 4:
                                        if (WhereWillDrop(3) == row_i)
                                        {
                                            MainWindow.DropToken(3);
                                            return;
                                        }
                                        break;
                                    default:
                                        if (WhereWillDrop(column_i - 1) == row_i)
                                        {
                                            MainWindow.DropToken(column_i - 1);
                                            return;
                                        }
                                        else if (WhereWillDrop(column_i + 3) == row_i)
                                        {
                                            MainWindow.DropToken(column_i + 3);
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
                //Check left-down right-up
                for (int row_i = 2; row_i < 6; row_i++)
                {
                    for (int column_i = 0; column_i < 5; column_i++)
                    {
                        if (MainWindow.Board[row_i][column_i] == 1)
                        {
                            if (MainWindow.Board[row_i - 1][column_i + 1] == 1 && MainWindow.Board[row_i - 2][column_i + 2] == 1)
                            {
                                switch (row_i)
                                {
                                    case 2:
                                        if (column_i != 0 && WhereWillDrop(column_i - 1) == 3)
                                        {
                                            MainWindow.DropToken(column_i - 1);
                                            return;
                                        }
                                        break;
                                    case 5:
                                        if (column_i != 4 && WhereWillDrop(column_i + 3) == 2) // <-- DO NOT GET RID OF THIS TWO
                                        {
                                            MainWindow.DropToken(column_i + 3);
                                            return;
                                        }
                                        break;
                                    default:
                                        switch (column_i)
                                        {
                                            case 0:
                                                if (WhereWillDrop(3) == row_i - 3)
                                                {
                                                    MainWindow.DropToken(3);
                                                    return;
                                                }
                                                break;
                                            case 4:
                                                if (WhereWillDrop(3) == row_i + 1)
                                                {
                                                    MainWindow.DropToken(3);
                                                    return;
                                                }
                                                break;
                                            default:
                                                if (WhereWillDrop(column_i + 3) == row_i - 3)
                                                {
                                                    MainWindow.DropToken(column_i + 3);
                                                    return;
                                                }
                                                else if (WhereWillDrop(column_i - 1) == row_i + 1)
                                                {
                                                    MainWindow.DropToken(column_i - 1);
                                                    return;
                                                }
                                                break;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
                //Check left-up right-down
                for (int row_i = 2; row_i < 6; row_i++)
                {
                    for (int column_i = 2; column_i < 7; column_i++)
                    {
                        if (MainWindow.Board[row_i][column_i] == 1)
                        {
                            if (MainWindow.Board[row_i - 1][column_i - 1] == 1 && MainWindow.Board[row_i - 2][column_i - 2] == 1)
                            {
                                switch (row_i)
                                {
                                    case 2:
                                        if (column_i != 6 && WhereWillDrop(column_i + 1) == 3)
                                        {
                                            MainWindow.DropToken(column_i + 1);
                                            return;
                                        }
                                        break;
                                    case 5:
                                        if (column_i != 2 && WhereWillDrop(column_i - 3) == 2) // <-- DO NOT GET RID OF THIS TWO
                                        {
                                            MainWindow.DropToken(column_i - 3);
                                            return;
                                        }
                                        break;
                                    default:
                                        switch (column_i)
                                        {
                                            case 2:
                                                if (WhereWillDrop(3) == row_i + 1)
                                                {
                                                    MainWindow.DropToken(3);
                                                    return;
                                                }
                                                break;
                                            case 6:
                                                if (WhereWillDrop(3) == row_i - 3)
                                                {
                                                    MainWindow.DropToken(3);
                                                    return;
                                                }
                                                break;
                                            default:
                                                if (WhereWillDrop(column_i - 3) == row_i - 3)
                                                {
                                                    MainWindow.DropToken(column_i - 3);
                                                    return;
                                                }
                                                else if (WhereWillDrop(column_i + 1) == row_i + 1)
                                                {
                                                    MainWindow.DropToken(column_i + 1);
                                                    return;
                                                }
                                                break;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            //CHECK FOR PLAYER's 2-1s
            if (JarvisDifficulty == 2)
            {
                //Check left-right
                for (int row_i = 0; row_i < 6; row_i++)
                {
                    for (int column_i = 0; column_i < 4; column_i++)
                    {
                        if (MainWindow.Board[row_i][column_i] == 1)
                        {
                            if (MainWindow.Board[row_i][column_i + 1] == 1 && MainWindow.Board[row_i][column_i + 3] == 1)
                            {
                                if (WhereWillDrop(column_i + 2) == row_i)
                                {
                                    MainWindow.DropToken(column_i + 2);
                                    return;
                                }
                            }
                            else if (MainWindow.Board[row_i][column_i + 2] == 1 && MainWindow.Board[row_i][column_i + 3] == 1)
                            {
                                if (WhereWillDrop(column_i + 1) == row_i)
                                {
                                    MainWindow.DropToken(column_i + 1);
                                    return;
                                }
                            }
                        }
                    }
                }
                //Check left-down right-up
                for (int row_i = 3; row_i < 6; row_i++)
                {
                    for (int column_i = 0; column_i < 4; column_i++)
                    {
                        if (MainWindow.Board[row_i][column_i] == 1)
                        {
                            if (MainWindow.Board[row_i - 1][column_i + 1] == 1 && MainWindow.Board[row_i - 3][column_i + 3] == 1)
                            {
                                if (WhereWillDrop(column_i + 2) == row_i - 2)
                                {
                                    MainWindow.DropToken(column_i + 2);
                                    return;
                                }
                            }
                            else if (MainWindow.Board[row_i - 2][column_i + 2] == 1 && MainWindow.Board[row_i - 3][column_i + 3] == 1)
                            {
                                if (WhereWillDrop(column_i + 1) == row_i - 1)
                                {
                                    MainWindow.DropToken(column_i + 1);
                                    return;
                                }
                            }
                        }
                    }
                }
                //Check left-up right-down
                for (int row_i = 3; row_i < 6; row_i++)
                {
                    for (int column_i = 3; column_i < 7; column_i++)
                    {
                        if (MainWindow.Board[row_i][column_i] == 1)
                        {
                            if (MainWindow.Board[row_i - 1][column_i - 1] == 1 && MainWindow.Board[row_i - 3][column_i - 3] == 1)
                            {
                                if (WhereWillDrop(column_i - 2) == row_i - 2)
                                {
                                    MainWindow.DropToken(column_i - 2);
                                    return;
                                }
                            }
                            else if (MainWindow.Board[row_i - 2][column_i - 2] == 1 && MainWindow.Board[row_i - 3][column_i - 3] == 1)
                            {
                                if (WhereWillDrop(column_i - 1) == row_i - 1)
                                {
                                    MainWindow.DropToken(column_i - 1);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            
            //ELSE
            MainWindow.DropToken(rand.Next(0, 7));
            return;
        }
        public static int WhereWillDrop(int column_number)
        {
            for (int row_number = 5; row_number >= 0; row_number--)
            {
                if (MainWindow.Board[row_number][column_number] == 0)
                {
                    return row_number;
                }
            }
            return -3;
        }
    } //JARVIS (AKA AI)
}
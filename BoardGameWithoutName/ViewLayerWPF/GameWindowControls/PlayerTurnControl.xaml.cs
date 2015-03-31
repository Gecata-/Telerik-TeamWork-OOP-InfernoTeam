﻿using GameLogic.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ViewLayerWPF.GameWindowControls
{
    /// <summary>
    /// Interaction logic for PlayerTurnControl.xaml
    /// </summary>
    public partial class PlayerTurnControl : UserControl
    {
        private Game game;

        public PlayerTurnControl(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.game.EndOfTurn();
        }
    }
}

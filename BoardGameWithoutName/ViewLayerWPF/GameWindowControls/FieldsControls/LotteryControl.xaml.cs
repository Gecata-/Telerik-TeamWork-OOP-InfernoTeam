﻿using GameLogic.Map.Fields;
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

namespace ViewLayerWPF.GameWindowControls.FieldsControls
{
    /// <summary>
    /// Interaction logic for LotaryControl.xaml
    /// </summary>
    public partial class LotteryControl : UserControl
    {
        public LotteryControl(Lottery lottery)
        {
            InitializeComponent();
        }
    }
}

﻿using Alienseed.BaseNetworkServer.Accounting;
using FeenPhone.Client;
using FeenPhone.WPFApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FeenPhone.WPFApp.Controls
{
    /// <summary>
    /// Interaction logic for UserListWPF.xaml
    /// </summary>
    public partial class UserListWPF : UserControl
    {

        public UserListWPF()
        {
            InitializeComponent();
            UsersList.ItemsSource = UserStatusRepo.Users;
        }

    }
}

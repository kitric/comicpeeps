﻿using ComicPeeps.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPeeps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pnlContent.Controls.Add(new Home() { Dock = DockStyle.Fill });
        }
    }
}
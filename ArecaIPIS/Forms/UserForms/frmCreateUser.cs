﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.UserForms
{
    public partial class frmCreateUser : Form
    {
        public frmCreateUser()
        {
            InitializeComponent();
        }

        private frmHome parentForm;
        public frmCreateUser(frmHome parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }
    }
}

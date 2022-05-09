namespace Notepad
{
    public partial class frmNotepad : Form
    {
        /* 布尔变量b用于判断文件是新建的还是从磁盘打开的，
   true表示文件是从磁盘打开的，false表示文件是新建的，默认值为false*/
        bool b = false;
        /* 布尔变量s用于判断文件件是否被保存，
           true表示文件是已经被保存了，false表示文件未被保存，默认值为true*/
        bool s = true;
        public frmNotepad()
        {
            InitializeComponent();
        }



        //*************************************************************************
        // 多格式文本框的TextChanged事件代码
        //*************************************************************************
        private void rtxtNotepad_TextChanged(object sender, EventArgs e)
        {
            // 文本被修改后，设置s为false，表示文件未保存
            s = false;
        }

        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // 【新建】菜单代码
        //*************************************************************************
        private void tsmiNew_Click(object sender, EventArgs e)
        {
            // 判断当前文件是否从磁盘打开，或者新建时文档不为空，并且文件未被保存
            if (b == true || rtxtNotepad.Text.Trim() != "")
            {
                // 若文件未保存
                if (s == false)
                {
                    string result;
                    result = MessageBox.Show("文件尚未保存,是否保存?",
                        "保存文件", MessageBoxButtons.YesNoCancel).ToString();
                    switch (result)
                    {
                        case "Yes":
                            // 若文件是从磁盘打开的
                            if (b == true)
                            {
                                // 按文件打开的路径保存文件
                                rtxtNotepad.SaveFile(odlgNotepad.FileName);
                            }
                            // 若文件不是从磁盘打开的
                            else if (sdlgNotepad.ShowDialog() == DialogResult.OK)
                            {
                                rtxtNotepad.SaveFile(sdlgNotepad.FileName);
                            }
                            s = true;
                            rtxtNotepad.Text = "";
                            break;
                        case "No":
                            b = false;
                            rtxtNotepad.Text = "";
                            break;
                    }
                }
            }
        }

        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // 【打开】菜单代码
        //*************************************************************************
        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (b == true || rtxtNotepad.Text.Trim() != "")
            {
                if (s == false)
                {
                    string result;
                    result = MessageBox.Show("文件尚未保存,是否保存?",
                        "保存文件", MessageBoxButtons.YesNoCancel).ToString();
                    switch (result)
                    {
                        case "Yes":
                            if (b == true)
                            {
                                rtxtNotepad.SaveFile(odlgNotepad.FileName);
                            }
                            else if (sdlgNotepad.ShowDialog() == DialogResult.OK)
                            {
                                rtxtNotepad.SaveFile(sdlgNotepad.FileName);
                            }
                            s = true;
                            break;
                        case "No":
                            b = false;
                            rtxtNotepad.Text = "";
                            break;
                    }
                }
            }
            odlgNotepad.RestoreDirectory = true;
            if ((odlgNotepad.ShowDialog() == DialogResult.OK) && odlgNotepad.FileName != "")
            {
                rtxtNotepad.LoadFile(odlgNotepad.FileName);//打开代码语句
                b = true;
            }
            s = true;
        }
        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // 【保存】菜单代码
        //*************************************************************************
        private void tsmiSave_Click(object sender, EventArgs e)
        {//由于这个没有改Name属性，所以和图片不太一样，对照就行
         // 若文件从磁盘打开并且修改了其内容
            if (b == true && rtxtNotepad.Modified == true)
            {
                rtxtNotepad.SaveFile(odlgNotepad.FileName);
                s = true;
            }
            else if (b == false && rtxtNotepad.Text.Trim() != "" &&
                sdlgNotepad.ShowDialog() == DialogResult.OK)
            {
                rtxtNotepad.SaveFile(sdlgNotepad.FileName);//保存语句
                s = true;
                b = true;
                odlgNotepad.FileName = sdlgNotepad.FileName;
            }
        }

        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // 【另存为】菜单代码
        //*************************************************************************
        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            if (sdlgNotepad.ShowDialog() == DialogResult.OK)
            {
                rtxtNotepad.SaveFile(sdlgNotepad.FileName);
                s = true;
            }
        }

        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // 【退出】菜单代码
        //*************************************************************************
        private void tsmiClose_Click(object sender, EventArgs e)
        {
            Application.Exit();//程序结束
        }
        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // 【编辑】菜单各菜单项的单击代码
        //*************************************************************************

        // 【撤销】菜单代码
        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Undo();//撤销
        }

        // 【复制】菜单代码
        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Copy();//复制
        }

        // 【剪切】菜单代码
        private void tsmiCut_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Cut();//剪切
        }

        // 【粘贴】菜单代码
        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Paste();//粘贴
        }

        // 【全选】菜单代码
        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            rtxtNotepad.SelectAll();//全选
        }

        // 【日期】菜单代码
        private void tsmiDate_Click(object sender, EventArgs e)
        {
            rtxtNotepad.AppendText(System.DateTime.Now.ToString());//显示当前日期
        }

        //*************************************************************************
        // 【自动换行】菜单代码
        //*************************************************************************
        private void tsmiAuto_Click(object sender, EventArgs e)
        {
            if (tsmiAuto.Checked == false)
            {
                tsmiAuto.Checked = true;            // 选中该菜单项
                rtxtNotepad.WordWrap = true;        // 设置为自动换行
            }
            else
            {
                tsmiAuto.Checked = false;
                rtxtNotepad.WordWrap = false;
            }
        }
        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // 【字体】菜单代码
        //*************************************************************************
        private void tsmiFont_Click(object sender, EventArgs e)
        {
            fdlgNotepad.ShowColor = true;
            if (fdlgNotepad.ShowDialog() == DialogResult.OK)
            {
                rtxtNotepad.SelectionColor = fdlgNotepad.Color;
                rtxtNotepad.SelectionFont = fdlgNotepad.Font;
            }
        }
        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // 【工具栏】菜单代码（不是必须的）
        //*************************************************************************
        private void tsmiToolStrip_Click(object sender, EventArgs e)
        {
            Point point;
            if (tsmiToolStrip.Checked == true)
            {
                // 隐藏工具栏时，把坐标设为（0，24）,因为菜单的高度为24
                point = new Point(0, 24);
                tsmiToolStrip.Checked = false;
                tlsNotepad.Visible = false;
                // 设置多格式文本框左上角位置
                rtxtNotepad.Location = point;
                // 隐藏工具栏后，增加文本框高度
                rtxtNotepad.Height += tlsNotepad.Height;
            }
            else
            {
                /* 显示工具栏时，多格式文本框左上角位置的位置为（0，49），
                   因为工具栏的高度为25，加上菜单的高度24后为49 */
                point = new Point(0, 49);
                tsmiToolStrip.Checked = true;
                tlsNotepad.Visible = true;
                rtxtNotepad.Location = point;
                rtxtNotepad.Height -= tlsNotepad.Height;
            }
        }
        //*************************************************************************
        //*************************************************************************
        //*************************************************************************
        // 【状态栏】菜单代码
        //*************************************************************************
        private void tsmiStatusStrip_Click(object sender, EventArgs e)
        {
            if (tsmiStatusStrip.Checked == true)
            {
                tsmiStatusStrip.Checked = false;
                stsNotepad.Visible = false;
                rtxtNotepad.Height += stsNotepad.Height;
            }
            else
            {
                tsmiStatusStrip.Checked = true;
                stsNotepad.Visible = true;
                rtxtNotepad.Height -= stsNotepad.Height;
            }
        }
        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // 【关于记事本】菜单代码
        //*************************************************************************
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            frmAbout ob_FrmAbout = new frmAbout();
            ob_FrmAbout.Show();
        }
        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // 工具栏的ItemClicked事件代码
        //*************************************************************************
        private void tlsNotepad_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int n;
            // 变量n用来接收按下按钮的索引号从0开始
            n = tlsNotepad.Items.IndexOf(e.ClickedItem);
            switch (n)
            {
                case 0:
                    tsmiNew_Click(sender, e);
                    break;
                case 1:
                    tsmiOpen_Click(sender, e);
                    break;
                case 2:
                    tsmiSave_Click(sender, e);
                    break;
                case 3:
                    
                    break;
                case 4:
                    tsmiCut_Click(sender, e);
                    break;
                case 5:
                    tsmiCopy_Click(sender, e);
                    break;
                case 6:
                    tsmiPaste_Click(sender, e);
                    break;
            }
        }
        //*************************************************************************
        // 工具栏的ItemClicked事件代码
        //*************************************************************************

        //*************************************************************************
        // 计时器控件的Tick事件代码
        //*************************************************************************
        private void tmrNotepad_Tick(object sender, EventArgs e)
        {
            tssLbl2.Text = System.DateTime.Now.ToString();
        }
        //*************************************************************************
        //*************************************************************************



    }




}
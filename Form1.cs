namespace Notepad
{
    public partial class frmNotepad : Form
    {
        /* ��������b�����ж��ļ����½��Ļ��ǴӴ��̴򿪵ģ�
   true��ʾ�ļ��ǴӴ��̴򿪵ģ�false��ʾ�ļ����½��ģ�Ĭ��ֵΪfalse*/
        bool b = false;
        /* ��������s�����ж��ļ����Ƿ񱻱��棬
           true��ʾ�ļ����Ѿ��������ˣ�false��ʾ�ļ�δ�����棬Ĭ��ֵΪtrue*/
        bool s = true;
        public frmNotepad()
        {
            InitializeComponent();
        }



        //*************************************************************************
        // ���ʽ�ı����TextChanged�¼�����
        //*************************************************************************
        private void rtxtNotepad_TextChanged(object sender, EventArgs e)
        {
            // �ı����޸ĺ�����sΪfalse����ʾ�ļ�δ����
            s = false;
        }

        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // ���½����˵�����
        //*************************************************************************
        private void tsmiNew_Click(object sender, EventArgs e)
        {
            // �жϵ�ǰ�ļ��Ƿ�Ӵ��̴򿪣������½�ʱ�ĵ���Ϊ�գ������ļ�δ������
            if (b == true || rtxtNotepad.Text.Trim() != "")
            {
                // ���ļ�δ����
                if (s == false)
                {
                    string result;
                    result = MessageBox.Show("�ļ���δ����,�Ƿ񱣴�?",
                        "�����ļ�", MessageBoxButtons.YesNoCancel).ToString();
                    switch (result)
                    {
                        case "Yes":
                            // ���ļ��ǴӴ��̴򿪵�
                            if (b == true)
                            {
                                // ���ļ��򿪵�·�������ļ�
                                rtxtNotepad.SaveFile(odlgNotepad.FileName);
                            }
                            // ���ļ����ǴӴ��̴򿪵�
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
        // ���򿪡��˵�����
        //*************************************************************************
        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (b == true || rtxtNotepad.Text.Trim() != "")
            {
                if (s == false)
                {
                    string result;
                    result = MessageBox.Show("�ļ���δ����,�Ƿ񱣴�?",
                        "�����ļ�", MessageBoxButtons.YesNoCancel).ToString();
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
                rtxtNotepad.LoadFile(odlgNotepad.FileName);//�򿪴������
                b = true;
            }
            s = true;
        }
        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // �����桿�˵�����
        //*************************************************************************
        private void tsmiSave_Click(object sender, EventArgs e)
        {//�������û�и�Name���ԣ����Ժ�ͼƬ��̫һ�������վ���
         // ���ļ��Ӵ��̴򿪲����޸���������
            if (b == true && rtxtNotepad.Modified == true)
            {
                rtxtNotepad.SaveFile(odlgNotepad.FileName);
                s = true;
            }
            else if (b == false && rtxtNotepad.Text.Trim() != "" &&
                sdlgNotepad.ShowDialog() == DialogResult.OK)
            {
                rtxtNotepad.SaveFile(sdlgNotepad.FileName);//�������
                s = true;
                b = true;
                odlgNotepad.FileName = sdlgNotepad.FileName;
            }
        }

        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // �����Ϊ���˵�����
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
        // ���˳����˵�����
        //*************************************************************************
        private void tsmiClose_Click(object sender, EventArgs e)
        {
            Application.Exit();//�������
        }
        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // ���༭���˵����˵���ĵ�������
        //*************************************************************************

        // ���������˵�����
        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Undo();//����
        }

        // �����ơ��˵�����
        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Copy();//����
        }

        // �����С��˵�����
        private void tsmiCut_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Cut();//����
        }

        // ��ճ�����˵�����
        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Paste();//ճ��
        }

        // ��ȫѡ���˵�����
        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            rtxtNotepad.SelectAll();//ȫѡ
        }

        // �����ڡ��˵�����
        private void tsmiDate_Click(object sender, EventArgs e)
        {
            rtxtNotepad.AppendText(System.DateTime.Now.ToString());//��ʾ��ǰ����
        }

        //*************************************************************************
        // ���Զ����С��˵�����
        //*************************************************************************
        private void tsmiAuto_Click(object sender, EventArgs e)
        {
            if (tsmiAuto.Checked == false)
            {
                tsmiAuto.Checked = true;            // ѡ�иò˵���
                rtxtNotepad.WordWrap = true;        // ����Ϊ�Զ�����
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
        // �����塿�˵�����
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
        // �����������˵����루���Ǳ���ģ�
        //*************************************************************************
        private void tsmiToolStrip_Click(object sender, EventArgs e)
        {
            Point point;
            if (tsmiToolStrip.Checked == true)
            {
                // ���ع�����ʱ����������Ϊ��0��24��,��Ϊ�˵��ĸ߶�Ϊ24
                point = new Point(0, 24);
                tsmiToolStrip.Checked = false;
                tlsNotepad.Visible = false;
                // ���ö��ʽ�ı������Ͻ�λ��
                rtxtNotepad.Location = point;
                // ���ع������������ı���߶�
                rtxtNotepad.Height += tlsNotepad.Height;
            }
            else
            {
                /* ��ʾ������ʱ�����ʽ�ı������Ͻ�λ�õ�λ��Ϊ��0��49����
                   ��Ϊ�������ĸ߶�Ϊ25�����ϲ˵��ĸ߶�24��Ϊ49 */
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
        // ��״̬�����˵�����
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
        // �����ڼ��±����˵�����
        //*************************************************************************
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            frmAbout ob_FrmAbout = new frmAbout();
            ob_FrmAbout.Show();
        }
        //*************************************************************************
        //*************************************************************************

        //*************************************************************************
        // ��������ItemClicked�¼�����
        //*************************************************************************
        private void tlsNotepad_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int n;
            // ����n�������հ��°�ť�������Ŵ�0��ʼ
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
        // ��������ItemClicked�¼�����
        //*************************************************************************

        //*************************************************************************
        // ��ʱ���ؼ���Tick�¼�����
        //*************************************************************************
        private void tmrNotepad_Tick(object sender, EventArgs e)
        {
            tssLbl2.Text = System.DateTime.Now.ToString();
        }
        //*************************************************************************
        //*************************************************************************



    }




}
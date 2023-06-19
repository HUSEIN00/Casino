namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void p_click(object sender, EventArgs e)
        {
            MessageBox.Show((sender as Panel).Name);
        }
        private void p1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ImageMode()
        {
            for(int i = 0; i <= 5; i++)
            {
                var pb = panel2.Controls["p" + i.ToString()].Controls["pb" + i.ToString()] as PictureBox;
            }
        }
        private void крутитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Сделай ставку", "ошибочка");
                return;
            }
            Random rnd = new Random();
            int n = 0;
            int[] imagesNum = new int[6];
            for (int i = 1; i <= 5; i++)
            {
                n = rnd.Next(1, 5);
                var pb = panel2.Controls["p" + i.ToString()].Controls["pb" + i.ToString()] as PictureBox;
                pb.Image = Image.FromFile("Images\\" + n.ToString() + ".jpg");
                imagesNum[i] = n;
            }
            
            int balance = int.Parse(label2.Text);
            string st = "";
            int price = int.Parse(textBox1.Text);
            
            
            



            if (price > balance)
            {
                MessageBox.Show("У вас столько нет.", "Казино");
                textBox1.Clear();
                return;
            }

            int super = 0;
            int max = 0;
            var dict = new Dictionary<string, int>();
            foreach(var el in imagesNum)
            {
                if (dict.ContainsKey(el.ToString()) != true)
                {
                    dict.Add(el.ToString(), 1);
                }
                else
                {
                    dict[el.ToString()]++;
                }
            }
            foreach(var el in dict)
            {
                if(el.Value > max)
                {
                    max = el.Value;
                }
            }
            listBox1.Items.Add(max);



            switch (max)
            {
                case 3:
                    balance += price * 3;
                    label2.Text = balance.ToString();
                    
                    break;
                case 4:
                    balance += price * 4;
                    label2.Text = balance.ToString();
                    break;
                case 5:
                    balance += price * 25;
                    label2.Text = balance.ToString();
                    break;
                default:
                    balance -= price;
                    label2.Text = balance.ToString();
                    break;
            }
            if (checkBox1.Checked == false)
            {
                textBox1.Clear();
            }
            if(balance == 0)
            {
                MessageBox.Show("Казино всегда в плюсе", "Казино");
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ImageMode();
            
        }
    }
}
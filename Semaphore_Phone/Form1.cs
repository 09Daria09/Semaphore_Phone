using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semaphore_Phone
{
    public partial class Form1 : Form
    {
        private Thread searchThread;
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(0);
        public Form1()
        {
            InitializeComponent();

            searchThread = new Thread(SearchThreadProc);
            searchThread.Start();
            this.KeyPreview = true;
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            semaphore.Release();
        }

        private void SearchThreadProc()
        {
            while (true)
            {
                semaphore.Wait();

                string searchText = string.Empty;
                this.Invoke((MethodInvoker)delegate
                {
                    searchText = richTextBox1.Text;
                });

                string[] words = searchText.Split(' ');

                if (words.Length > 0)
                {
                    string lastWord = words[words.Length - 1];
                    string[] lines = File.ReadAllLines("Dictionary.txt");
                    string match = lines.FirstOrDefault(line => line.StartsWith(lastWord, StringComparison.OrdinalIgnoreCase));

                    if (match != null && match.Length > lastWord.Length)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            richTextBox1.SelectionStart = searchText.Length - lastWord.Length;
                            richTextBox1.SelectionLength = lastWord.Length;

                            string remainingText = match.Substring(lastWord.Length);
                            richTextBox1.SelectedText = remainingText;

                            richTextBox1.SelectionStart = richTextBox1.TextLength;
                        });
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            char keyChar = (char)e.KeyData;
            if(keyChar == '1')
            {
                button7.BackColor = Color.LightBlue;
            }
            if (char.ToLower(keyChar) == 'f' || char.ToUpper(keyChar) == 'F'|| keyChar == 188 || 
                char.ToLower(keyChar) == 'd' || char.ToUpper(keyChar) == 'D' || char.ToLower(keyChar) == 'u' || char.ToUpper(keyChar) == 'U'|| keyChar == '2')
            {
                button9.BackColor = Color.LightBlue;
            }
            if (char.ToLower(keyChar) == 'l' || char.ToUpper(keyChar) == 'L' || keyChar == 186 ||
                char.ToLower(keyChar) == 't' || char.ToUpper(keyChar) == 'T' || char.ToLower(keyChar) == 'p' || char.ToUpper(keyChar) == 'P' || keyChar == '3')
            {
                button10.BackColor = Color.LightBlue;
            }
            if (char.ToLower(keyChar) == 'b' || char.ToUpper(keyChar) == 'B' || char.ToLower(keyChar) == 'k' || char.ToUpper(keyChar) == 'K' ||
                char.ToLower(keyChar) == 'q' || char.ToUpper(keyChar) == 'Q' || char.ToLower(keyChar) == 'r' || char.ToUpper(keyChar) == 'R' || keyChar == '4')
            {
                button8.BackColor = Color.LightBlue;
            }
            if (char.ToLower(keyChar) == 'v' || char.ToUpper(keyChar) == 'V' || char.ToLower(keyChar) == 'y' || char.ToUpper(keyChar) == 'Y' ||
                char.ToLower(keyChar) == 'j' || char.ToUpper(keyChar) == 'J' || char.ToLower(keyChar) == 'g' || char.ToUpper(keyChar) == 'G' || keyChar == '5')
            {
                button13.BackColor = Color.LightBlue;
            }
            if (char.ToLower(keyChar) == 'h' || char.ToUpper(keyChar) == 'H' || char.ToLower(keyChar) == 'c' || char.ToUpper(keyChar) == 'C' ||
                char.ToLower(keyChar) == 'n' || char.ToUpper(keyChar) == 'N' || char.ToLower(keyChar) == 'e' || char.ToUpper(keyChar) == 'E' || keyChar == '6')
            {
                button12.BackColor = Color.LightBlue;
            }
            if (char.ToLower(keyChar) == 'a' || char.ToUpper(keyChar) == 'A' || char.ToLower(keyChar) == 'x' || char.ToUpper(keyChar) == 'X' ||
                keyChar == 219 || keyChar == '7')
            {
                button11.BackColor = Color.LightBlue;
            }
            if (char.ToLower(keyChar) == 'i' || char.ToUpper(keyChar) == 'I' || char.ToLower(keyChar) == 'o' || char.ToUpper(keyChar) == 'O'
                || char.ToLower(keyChar) == 's' || char.ToUpper(keyChar) == 'S' || keyChar == 221 || keyChar == '8')
            {
                button20.BackColor = Color.LightBlue;
            }
            if (char.ToLower(keyChar) == 'm' || char.ToUpper(keyChar) == 'M' || char.ToLower(keyChar) == 'z' || char.ToUpper(keyChar) == 'Z'
                || keyChar == 190 || keyChar == 222 || keyChar == '8')
            {
                button19.BackColor = Color.LightBlue;
            }
            if (keyChar == '0')
            {
                button17.BackColor = Color.LightBlue;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            char keyChar = (char)e.KeyData;
            if (keyChar == '1')
            {
                button7.BackColor = DefaultBackColor;
            }
            if (char.ToLower(keyChar) == 'f' || char.ToUpper(keyChar) == 'F' || keyChar == 188 ||
                char.ToLower(keyChar) == 'd' || char.ToUpper(keyChar) == 'D' || char.ToLower(keyChar) == 'u' || char.ToUpper(keyChar) == 'U' || keyChar == '2')
            {
                button9.BackColor = DefaultBackColor;
            }
            if (char.ToLower(keyChar) == 'l' || char.ToUpper(keyChar) == 'L' || keyChar == 186 ||
                char.ToLower(keyChar) == 't' || char.ToUpper(keyChar) == 'T' || char.ToLower(keyChar) == 'p' || char.ToUpper(keyChar) == 'P' || keyChar == '3')
            {
                button10.BackColor = DefaultBackColor;
            }
            if (char.ToLower(keyChar) == 'b' || char.ToUpper(keyChar) == 'B' || char.ToLower(keyChar) == 'k' || char.ToUpper(keyChar) == 'K' ||
                char.ToLower(keyChar) == 'q' || char.ToUpper(keyChar) == 'Q' || char.ToLower(keyChar) == 'r' || char.ToUpper(keyChar) == 'R' || keyChar == '4')
            {
                button8.BackColor = DefaultBackColor;
            }
            if (char.ToLower(keyChar) == 'v' || char.ToUpper(keyChar) == 'V' || char.ToLower(keyChar) == 'y' || char.ToUpper(keyChar) == 'Y' ||
                char.ToLower(keyChar) == 'j' || char.ToUpper(keyChar) == 'J' || char.ToLower(keyChar) == 'g' || char.ToUpper(keyChar) == 'G' || keyChar == '5')
            {
                button13.BackColor = DefaultBackColor;
            }
            if (char.ToLower(keyChar) == 'h' || char.ToUpper(keyChar) == 'H' || char.ToLower(keyChar) == 'c' || char.ToUpper(keyChar) == 'C' ||
                char.ToLower(keyChar) == 'n' || char.ToUpper(keyChar) == 'N' || char.ToLower(keyChar) == 'e' || char.ToUpper(keyChar) == 'E' || keyChar == '6')
            {
                button12.BackColor = DefaultBackColor;
            }
            if (char.ToLower(keyChar) == 'a' || char.ToUpper(keyChar) == 'A' || char.ToLower(keyChar) == 'x' || char.ToUpper(keyChar) == 'X' ||
                keyChar == 219 || keyChar == '7')
            {
                button11.BackColor = DefaultBackColor;
            }
            if (char.ToLower(keyChar) == 'i' || char.ToUpper(keyChar) == 'I' || char.ToLower(keyChar) == 'o' || char.ToUpper(keyChar) == 'O'
               || char.ToLower(keyChar) == 's' || char.ToUpper(keyChar) == 'S' || keyChar == 221 || keyChar == '8')
            {
                button20.BackColor = DefaultBackColor;
            }
            if (char.ToLower(keyChar) == 'm' || char.ToUpper(keyChar) == 'M' || char.ToLower(keyChar) == 'z' || char.ToUpper(keyChar) == 'Z'
                || keyChar == 190 || keyChar == 222 || keyChar == '8')
            {
                button19.BackColor = DefaultBackColor;
            }
            if (keyChar == '0')
            {
                button17.BackColor = DefaultBackColor;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}

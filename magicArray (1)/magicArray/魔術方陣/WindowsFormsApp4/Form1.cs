using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num = Convert.ToInt32(textBox1.Text);//輸入數字
            int result = Convert.ToInt32(Math.Floor(num/ 2));//計算第一個數字位置
            int[,] array = new int[Convert.ToInt32(num), Convert.ToInt32(num)];//二微陣列矩陣呼叫
           for (int i = 0; i < num; i++)
                for (int j = 0; j < num; j++)//將矩陣內容先設為0
                    array[i, j] = 0;
            int row = 0; //設行為0
            int col = result;//設第一個數字的列的位置
            int size = (int)num; //這個矩陣的長寬
            array[0, result] = 1; //設第一個數字位置為1 
            for(int i=2;i<=(num*num); i++) //從2開始
            {          
                if (row == -1) //如行在-1時執行
                { 
                    if (col == -1) //如行列都在-1 則 行+1
                        row += 1;
                    else if(col != -1)//如行在-1 列不在-1則代表需要去左行最底下
                    {
                        row = size - 1; //行變成，長度減一，也就放在最下面
                        col -= 1; //列-1，去左行
                    }                     
                }
                else if (col == -1 && row != -1)//如列在-1 行不在-1 則代表需要往右上移動
                {
                    row -= 1; //往上移動
                    col = size - 1;//去到最右邊
                }
                else if(array[row - 1, col - 1]!=0) //如這邊值不等於0，等於是被填入數字的話
                    row += 1;  //row往下一格
                else //如這邊沒有值 也行列皆不在0 則往左上
                {
                    row -= 1;//往上
                    col -= 1;//往左
                }
                array[row, col] = i; //寫入值
            }
        }
    }
}
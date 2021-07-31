using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testDrumsBeep
{
    public partial class Form1 : Form
    {
        private SoundPlayer Player = new SoundPlayer();
        private SoundPlayer Player2 = new SoundPlayer();


        public Form1()
        {
            InitializeComponent();
        
        }


        /*

        Pam[] note = { new Pam(), new Pam(), new Pam(), new Pam(),
                         new Pam(), new Pam(), new Pam(), new Pam(),
                         new Pam(2, new int[2] { 1, 1 }),new Pam(2, new int[2] { 1, 1 }),new Pam(2, new int[2] { 1, 1 }),new Pam(2, new int[2] { 1, 1 }) ,
                         new Pam(2, new int[2] { 0, 1 }),new Pam(2, new int[2] { 1, 0 }),new Pam(2, new int[2] { 1, 1 }),new Pam(2, new int[2] { 1, 1 }) ,
                         new Pam(4, new int[4] { 1, 1,1,1 }),new Pam(4, new int[4] { 1, 1,1,1 }),new Pam(4, new int[4] { 1, 1,1,1 }),new Pam(4, new int[4] { 1, 1,1,1 }),
                         new Pam(4, new int[4] { 1, 1,1,1 }),new Pam(4, new int[4] { 1, 1,1,1 }),new Pam(4, new int[4] { 1, 1,1,1 }),new Pam(4, new int[4] { 1, 1,1,1 })
                     };

        */


        List<Pam> NOTES = new List<Pam>();

        private void button1_Click(object sender, EventArgs e)
        {

            readNote("note3.txt");

            string path1 = @"C:\Users\Joud Abo 3azar\Downloads\Music\beep-21.wav";
            string path2 = @"C:\Users\Joud Abo 3azar\Downloads\Music\beep-22.wav";

            this.Player.SoundLocation = path1;
            this.Player2.SoundLocation = path2;

            int timer = 857;

           // int timer = 1700;
       
            //    int measure = 1;
            bool b=true;

            for (int i = 0; i < NOTES.Count; i++)
            {

                playPam (NOTES[i],timer,ref b);
            
            }

            /// 1111 2222 4444  old test

            /*
            playMeasure(timer, measure);
            playMeasure(timer, measure);


            playMeasure(timer, measure*2);
            playMeasure(timer, measure*2);

            playMeasure(timer, measure * 4);
            playMeasure(timer, measure * 4);
            */





                       /*
            for (int i = 1; i <=16; i++)
            {

                new System.Threading.Thread(() =>
                {
                    var c = new System.Windows.Media.MediaPlayer();
                    c.Open(new System.Uri(path1));
                    c.Play();
                }).Start();

                Thread.Sleep(timer/4);

                new System.Threading.Thread(() =>
                {
                    var c = new System.Windows.Media.MediaPlayer();
                    c.Open(new System.Uri(path2));
                    c.Play();
                }).Start();

                Thread.Sleep(timer/4);


            }
             
             */
        }

        private void readNote(string path)
        {


            string fileContent = File.ReadAllText(path);

            string[] integerStrings = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int[] integers = new int[integerStrings.Length];

            for (int n = 0; n < integerStrings.Length; n++)

                integers[n] = int.Parse(integerStrings[n]);


            
            int i = 0 ;
            
            while(i< integers.Length)
               {
                    int size = integers[i++];

                    int[] arr = new int[size];

                    for (int k = 0; k < size; k++)
                    {
                      arr[k] =   integers[i++];
                    }

                    Pam p = new Pam(size, arr);

                    NOTES.Add(p);

                }
        }

        


        private void playPam(Pam p ,int timer,ref bool  b)
        {

            for (int i =0; i < p.size; i++)
            {
                
                if(p.arr[i]!=0)
                {
                    if(b)
                      this.Player.Play();
                    else
                       this.Player2.Play();
                
                }

                Thread.Sleep(timer / p.size);
                b = !b;
            }

        }

     /*
      * private void playMeasure(int timer, int measure)
        {

            for (int i = 1; i <= 2 * measure; i++)
            {
                this.Player.Play();
                Thread.Sleep(timer / measure);
                this.Player2.Play();
                Thread.Sleep(timer / measure);

            }

        }
        */
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// СОСТОЯНИЯ ФИЛОСОФА (state):
// 0 - думает
// 1 - взял левую вилку
// 2 - взял правую вилку
// 3 - ест
// 4 - останавливается есть
// 5 - опустил правую вилку
// 6 - опустил левую вилку

namespace Philosophers
{
    class Philosopher
    {
        private int state;
        private int timer;
        private IStick LeftStick;
        private IStick RightStick; 
        public int State { get { return state; } set { state = value; } }
        public string Message 
        { 
            get 
            { 
                switch(state)
                {
                    case 0: return "Этот философ думает";
                    case 1: return "Этот философ берет левую вилку";
                    case 2: return "Этот философ берет правую вилку";
                    case 3: return "Этот философ ест";
                    case 4: return "Этот философ останавливается есть";
                    case 5: return "Этот философ кладет правую вилку";
                    case 6: return "Этот философ кладет левую вилку";
                    default: return "Философ в замешательстве";
                }
            } 
        }
        public Philosopher(Random rn, IStick left, IStick right)
        {
            state = rn.Next(0, 2);
            timer = 0;
            LeftStick = left;
            RightStick = right;
        }
        public void TakeLeftStick()
        {
            if (!LeftStick.IsUsing)
            {
                LeftStick.Take();
                state = 1;
            }
            else
                state = -1;
        }
        public void TakeRightStick()
        {
            if (!RightStick.IsUsing)
            {
                RightStick.Take();
                state = 2;
            }
            else
                state = -1;
        }
        public void PutLeftStick()
        {
            if (LeftStick.IsUsing)
            {
                LeftStick.Put();
                state = 6;         //кладет левую вилку
            }

        }
        public void PutRightStick()
        {
            if (RightStick.IsUsing)
            {
                RightStick.Put();
                state = 5;        //кладет правую вилку
            }
        }
        public void GoThinking()
        {
            state = 0;
        }
        public void GoEating()
        {
            state = 3; //кушает
        }
        public void StopEating()
        {
            state = 4; //останавливается кушать
        }
    }
}
